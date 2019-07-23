using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TekkenGame.Models;

namespace TekkenGame.Controllers
{
    public class JogosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jogos
        public ActionResult Index()
        {
            var listaDeJogos = db.Jogos.ToList().OrderBy(a => a.Titulo);

            return View(listaDeJogos);
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Jogos jogos = db.Jogos.Find(id);

            if (jogos == null)
            {
                return RedirectToAction("Index");
            }
            return View(jogos);
        }

        [Authorize(Roles = "Admin")]
        // GET: Jogos/Create
        public ActionResult Create()
        {
            // gerar a lista de Personagens associadas ao Jogo
            ViewBag.ListaDePersonagens = db.Personagens.OrderBy(b => b.Nome).ToList();
            // gerar a lista de Plataformas associadas ao Jogo
            ViewBag.ListaDePlataformas = db.Plataformas.OrderBy(b => b.Nome).ToList();
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Logotipo,Resumo")] Jogos jogo, HttpPostedFileBase uploadFotografia, string[] checkBoxPersonagens, string[] checkBoxPlataformas)
        {
            /// avalia se o array com a lista de Personagens associadas
            /// ao Jogo é nula ou não
            if (checkBoxPersonagens == null)
            {
                ModelState.AddModelError("", "Necessita escolher pelo menos uma Personagem para associar ao Jogo");
                ViewBag.ListaDePersonagens = db.Personagens.OrderBy(a => a.Nome).ToList();
                return View(jogo);
            }

            // criar uma lista
            List<Personagens> ListaDePersonagensEscolhidas = new List<Personagens>();
            foreach (string item in checkBoxPersonagens)
            {
                // procurar Personagem
                Personagens persongens = db.Personagens.Find(Convert.ToInt32(item));
                // adicioná-lo à lista de personagens
                ListaDePersonagensEscolhidas.Add(persongens);
            }

            jogo.ListaDePersonagens = ListaDePersonagensEscolhidas;

            // ************************************************************************************************************************************

            /// avalia se o array com a lista de personagens associados
            /// ao Jogo é nula ou não
            if (checkBoxPlataformas == null)
            {
                ModelState.AddModelError("", "Necessita escolher pelo menos uma Personagem para associar ao Jogo");
                ViewBag.ListaDePlataformas = db.Plataformas.OrderBy(a => a.Nome).ToList();
                return View(jogo);
            }

            // criar uma lista
            List<Plataformas> ListaDePlataformasEscolhidas = new List<Plataformas>();
            foreach (string item in checkBoxPlataformas)
            {
                // procurar Personagem
                Plataformas plataformas = db.Plataformas.Find(Convert.ToInt32(item));
                // adicioná-lo à lista de plataformas
                ListaDePlataformasEscolhidas.Add(plataformas);
            }

            jogo.ListaDePlataformas = ListaDePlataformasEscolhidas;

            //***********************************************************************************************************************************
            int idNovoJogo = 0;
            try
            {
                // vai à BD, depois à tabela dos Jogos e calcula o ID máximo
                idNovoJogo = db.Jogos.Max(a => a.ID) + 1;
            }
            catch (Exception)
            {
                idNovoJogo = 1;
            }

            // guardar o ID do novo Jogo
            jogo.ID = idNovoJogo;

            // especificar o nome do ficheiro
            string nomeImagem = "Jogo_" + idNovoJogo + ".jpg";

            // variável aux
            string path = "";

            // validar se a imagem foi fornecida
            if (uploadFotografia != null)
            {
                // o ficheiro foi fornecido
                // criar o caminho completo até ao sítio onde o ficheiro será guardado
                path = Path.Combine(Server.MapPath("~/ImagemCapas/"), nomeImagem);

                jogo.Fotografia = nomeImagem;
            }
            else
            {
                // não foi fornecido qualquer ficheiro
                // gerar uma mensagem de erro
                ModelState.AddModelError("", "Não foi fornecida uma imagem.");

                // devolver o controlo à View
                return View(jogo);
            }

            if (ModelState.IsValid)
            {
                // add o novo Jogo à BD
                db.Jogos.Add(jogo);

                // faz 'commit' às alterações.
                db.SaveChanges();

                // escrever o ficheiro com a fotografia no disco rígido, na pasta 'imagens'
                uploadFotografia.SaveAs(path);
                return RedirectToAction("Index");
            }

            return View(jogo);
        }

        [Authorize(Roles = "Admin")]
        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // procura na BD o jogo cujo ID foi fornecido
            Jogos jogo = db.Jogos.Find(id);

            // proteção para o caso de não ter sido encontrado qualquer Jogo que tenha o ID fornecido
            if (jogo == null)
            {
                return RedirectToAction("Index");
            }

            // gerar a lista de Personagens associadas ao Jogo 
            ViewBag.ListaDePersonagens = db.Personagens.OrderBy(b => b.Nome).ToList();
            // gerar a lista de Plataformas associadas ao Jogo
            ViewBag.ListaDePlataformas = db.Plataformas.OrderBy(b => b.Nome).ToList();

            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Logotipo,Resumo,Fotografia")] Jogos jogo, HttpPostedFileBase uploadFotografia, string[] checkBoxPersonagens, string[] checkBoxPlataformas)
        {
            // ler da BD os dados existentes sobre o objeto que se pretende editar
            var vAnteriorDoJogo = db.Jogos.Include(b => b.ListaDePersonagens).Include(b => b.ListaDePlataformas).Where(b => b.ID == jogo.ID).SingleOrDefault();

            // há imagens para alterar????
            //    - logótipo ?
            //    - capa ?

            // há personagens para alterar?

            // e plataformas????

            // e depois, há q guardar os dados na bd





            // avaliar se os dados são 'bons'
            if (ModelState.IsValid)
            {
                vAnteriorDoJogo.Titulo = jogo.Titulo;
                vAnteriorDoJogo.Logotipo = jogo.Logotipo;
                vAnteriorDoJogo.Resumo = jogo.Resumo;
                vAnteriorDoJogo.Fotografia = jogo.Fotografia;
            }
            else
            {
                // gerar a lista de personagens associados ao Jogo
                ViewBag.ListaDePersonagens = db.Personagens.OrderBy(b => b.Nome).ToList();
                // gerar a lista de Plataformas associadas ao Jogo
                ViewBag.ListaDePlataformas = db.Plataformas.OrderBy(b => b.Nome).ToList();
                return View(jogo);
            }

            // tentar fazer o UPDATE
            if (TryUpdateModel(vAnteriorDoJogo, new string[] { nameof(vAnteriorDoJogo.Titulo), nameof(vAnteriorDoJogo.Logotipo), nameof(vAnteriorDoJogo.Resumo), nameof(vAnteriorDoJogo.Fotografia), nameof(vAnteriorDoJogo.ListaDePersonagens) }))
            {
                //*****************************************************************************************************
                // processar as personagens
                //*****************************************************************************************************
                // obter lista de personagens
                var personagens = db.Personagens.ToList();

                if (checkBoxPersonagens != null)
                {
                    foreach (var item in personagens)
                    {
                        if (checkBoxPersonagens.Contains(item.ID.ToString()))
                        {
                            if (!vAnteriorDoJogo.ListaDePersonagens.Contains(item))
                            {
                                vAnteriorDoJogo.ListaDePersonagens.Add(item);
                            }
                        }
                        else
                        {
                            // caso exista associação para uma opção que não foi escolhida,
                            // remove-se essa associação
                            vAnteriorDoJogo.ListaDePersonagens.Remove(item);
                        }
                    }
                }
                else
                {
                    // não existem opções escolhidas!
                    // vamos eliminar todas as associações
                    foreach (var item in personagens)
                    {
                        if (vAnteriorDoJogo.ListaDePersonagens.Contains(item))
                        {
                            vAnteriorDoJogo.ListaDePersonagens.Remove(item);
                        }
                    }
                }


                //*****************************************************************************************************
                // processar as plataformas
                //*****************************************************************************************************

                // fazer algo semelhante ao q foi feito com as personagens




                // guardar as alterações
                db.SaveChanges();

                // devolver controlo à View
                return RedirectToAction("Index");
            }

            // se cheguei aqui, é porque alguma coisa correu mal
            ModelState.AddModelError("", "Alguma coisa correu mal...");

            //gerar a lista de personagens associados ao Jogo
            ViewBag.ListaDePersonagens = db.Personagens.OrderBy(r => r.Nome).ToList();
            // gerar a lista de Plataformas associadas ao Jogo
            ViewBag.ListaDePlataformas = db.Plataformas.OrderBy(b => b.Nome).ToList();

            // ***************************************************************************************************************************

            // ler da BD o objeto que se pretende editar
            var jogoss = db.Jogos.Include(r => r.ListaDePlataformas).Where(r => r.ID == jogo.ID).SingleOrDefault();

            // avaliar se os dados são 'bons'
            if (ModelState.IsValid)
            {
                jogoss.Titulo = jogo.Titulo;
                jogoss.Logotipo = jogo.Logotipo;
                jogoss.Resumo = jogo.Resumo;
                jogoss.Fotografia = jogo.Fotografia;
            }
            else
            {
                // gerar a lista de personagens associados ao Jogo
                ViewBag.ListaDePlataformas = db.Plataformas.OrderBy(r => r.Nome).ToList();
                return View(jogo);
            }

            // tentar fazer o UPDATE
            if (TryUpdateModel(jogoss, new string[] { nameof(jogoss.Titulo), nameof(jogoss.Logotipo), nameof(jogoss.Resumo), nameof(jogoss.ListaDePlataformas) }))
            {
                // obter lista de personagens
                var plataformas = db.Plataformas.ToList();

                if (checkBoxPlataformas != null)
                {
                    foreach (var item in plataformas)
                    {
                        if (checkBoxPlataformas.Contains(item.ID.ToString()))
                        {
                            if (!jogoss.ListaDePlataformas.Contains(item))
                            {
                                jogoss.ListaDePlataformas.Add(item);
                            }
                        }
                        else
                        {
                            // caso exista associação para uma opção que não foi escolhida,
                            // remove-se essa associação
                            jogoss.ListaDePlataformas.Remove(item);
                        }
                    }
                }
                else
                {
                    // não existem opções escolhidas!
                    // vamos eliminar todas as associações
                    foreach (var item in plataformas)
                    {
                        if (jogoss.ListaDePlataformas.Contains(item))
                        {
                            jogoss.ListaDePlataformas.Remove(item);
                        }
                    }
                }

                // guardar as alterações
                db.SaveChanges();

                // devolver controlo à View
                return RedirectToAction("Index");
            }

            // se cheguei aqui, é porque alguma coisa correu mal
            ModelState.AddModelError("", "Alguma coisa correu mal...");

            //gerar a lista de personagens associados ao Jogo
            ViewBag.ListaDePlataformas = db.Plataformas.OrderBy(r => r.Nome).ToList();

            // ***************************************************************************************************************************

            string path = "";

            if (uploadFotografia == null)
            {
                db.Entry(jogo).State = EntityState.Modified;

                db.SaveChanges();
                ViewBag.Plataformas = db.Plataformas;
                return RedirectToAction("Index");
            }
            else
            {
                db.Entry(jogo).State = EntityState.Modified;

                string mimeType = uploadFotografia.ContentType;



                if (mimeType == "image/jpeg" || mimeType == "image/png")
                {
                    // o ficheiro é do tipo correto
                    /// 3º qual o nome que devo dar ao ficheiro?
                    Guid g;
                    g = Guid.NewGuid(); // obtem os dados para o nome do ficheiro

                    // e qual a extensão do ficheiro?
                    string extensao = Path.GetExtension(uploadFotografia.FileName).ToLower();

                    // montar novo nome
                    string nomeFicheiro = g.ToString() + extensao;

                    // onde guardar o ficheiro?
                    path = Path.Combine(Server.MapPath("~/ImagemCapas/"), nomeFicheiro);

                    /// 4º como o associar ao novo Jogo?
                    jogo.Fotografia = nomeFicheiro;


                }
                else
                {
                    // o ficheiro fornecido nao é válido 
                    // atributo por defeito ao jogo
                    return RedirectToAction("Index");
                    // jogo.Fotografia = "no-user.jpg";
                }

                if (ModelState.IsValid)
                {

                    uploadFotografia.SaveAs(path);
                    db.Entry(jogo).State = EntityState.Modified;

                    db.SaveChanges();
                    ViewBag.Plataformas = db.Plataformas;
                    return RedirectToAction("Index");

                }
                ViewBag.Plataformas = db.Plataformas;
            }
            return View(jogo);
        }

        [Authorize(Roles = "Admin")]
        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // pesquisar pelo jogo cujo ID foi fornecido
            Jogos jogos = db.Jogos.Find(id);

            // verificar se o jogo foi encontrado
            if (jogos == null)
            {
                return RedirectToAction("Index");
            }
            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Jogos jogo = db.Jogos.Find(id);
            try
            {
                foreach (var child in jogo.ListaDePersonagens.ToList())
                {
                    jogo.ListaDePersonagens.Remove(child);
                }

                foreach (var child in jogo.ListaDeComentarios.ToList())
                {
                    jogo.ListaDeComentarios.Remove(child);
                }

                foreach (var child in jogo.ListaDePlataformas.ToList())
                {
                    jogo.ListaDePlataformas.Remove(child);
                }

                // remove o jogo da BD
                db.Jogos.Remove(jogo);

                // 'Commit'
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", string.Format("Não é possível apagar o jogo nº {0} - {1}",
                                                            id, jogo.Titulo)
                );
            }

            // se cheguei aqui é porque houve um problema
            // devolvo os dados do Jogo à View
            return View(jogo);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
