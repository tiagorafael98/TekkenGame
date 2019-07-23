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
    public class PersonagensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personagens
        public ActionResult Index()
        {
            // obter a lista das personagens por ordem alfabética
            // em SQL: SELECT * FROM Personagens ORDER BY Nome;
            var listaDePersonagens = db.Personagens.ToList().OrderBy(a => a.Nome);

            return View(listaDePersonagens);
        }

        // GET: Personagens/Details/5
        public ActionResult Details(int? id)
        {
            // se se escrever 'int?' é possível não fornecer o valor para o ID e não há erro

            // proteção para o caso de não ter sido fornecido um ID válido
            if (id == null)
            {
                // se não houve ID, volta ao Index
                return RedirectToAction("Index");
            }

            // procura na BD a personagem cujo ID foi fornecido
            Personagens personagens = db.Personagens.Find(id);

            // se a personagem não for encontrada

            if (personagens == null)
            {
                // redireciona ao Index
                return RedirectToAction("Index");
            }

            // entrega à View os dados da personagem encontrada
            return View(personagens);
        }

        [Authorize(Roles = "Admin")]
        // GET: Personagens/Create
        public ActionResult Create()
        {
            //gerar a lista de Jogos associados à Personagem
            ViewBag.ListaDeJogos = db.Jogos.OrderBy(b => b.Titulo).ToList();
            // apresenta a View para se inserir uma nova Personagem
            return View();
        }

        // POST: Personagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Origem,TipoLuta,Fotografia,Biografia")] Personagens personagem, HttpPostedFileBase uploadFotografia, string[] checkBoxJogos)
        {
            // avalia se o array com a lista de Jogos associados
            // à Personagem é nula ou não
            if (checkBoxJogos == null)
            {
                ModelState.AddModelError("", "Necessita escolher pelo menos um jogo para associar à Personagem");
                ViewBag.ListaDeJogos = db.Jogos.OrderBy(a => a.Titulo).ToList();
                return View(personagem);
            }

            // criar uma lista
            List<Jogos> ListaDeJogosEscolhidas = new List<Jogos>();
            foreach (string item in checkBoxJogos)
            {
                // procurar Jogo
                Jogos jogos = db.Jogos.Find(Convert.ToInt32(item));
                // adicioná-lo à lista de jogos
                ListaDeJogosEscolhidas.Add(jogos);
            }

            personagem.ListaDeJogos = ListaDeJogosEscolhidas;

            // escrever os dados de uma nova Personagem na BD
            // especificar o ID da nova Personagem através de um TRY/CATCH
            int idNovaPersonagem = 0;

            try
            {
                // vai à BD, depois à tabela das Personagens e calcula o ID máximo
                idNovaPersonagem = db.Personagens.Max(a => a.ID) + 1;
            }
            catch (Exception)
            {
                idNovaPersonagem = 1;
            }

            // guardar o ID da nova Personagem
            personagem.ID = idNovaPersonagem;

            // especificar o nome do ficheiro
            string nomeImagem = "Personagem_" + idNovaPersonagem + ".jpg";

            // variável auxiliar
            string path = "";

            // validar se a imagem foi fornecida
            if (uploadFotografia != null)
            {
                // o ficheiro foi fornecido
                // criar o caminho completo até ao sítio onde o ficheiro será guardado
                path = Path.Combine(Server.MapPath("~/ImagemPers/"), nomeImagem);

                // guardar o nome do ficheiro na BD
                personagem.Fotografia = nomeImagem;
            }
            else
            {
                // não foi fornecido um ficheiro
                // gerar uma mensagem de erro
                ModelState.AddModelError("", "Não foi fornecida uma imagem.");

                // devolver o controlo à View
                return View(personagem);
            }

            // ModelState.IsValid -> confronta os dados fornecidos da View com as exigências do Modelo
            if (ModelState.IsValid)
            {
                // adicionar a nova personagem à BD
                db.Personagens.Add(personagem);
                // faz 'commit' às alterações
                db.SaveChanges();

                // escrever o ficheiro com a fotografia no disco rígido, na pasta 'imagens'
                uploadFotografia.SaveAs(path);

                // retorna ao index
                return RedirectToAction("Index");
            }

            return View(personagem);
        }

        [Authorize(Roles = "Admin")]
        // GET: Personagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                // se o ID não for encontrado ou não existir, volta ao Index
                return RedirectToAction("Index");
            }

            // procura na BD a personagem cujo ID foi fornecido
            Personagens personagem = db.Personagens.Find(id);

            // proteção para caso de não ter sido encontrado qualquer Personagem que tenha o ID fornecido
            if (personagem == null)
            {
                // retorna para o index
                return RedirectToAction("Index");
            }

            //gerar a lista de Jogos associados à Personagem
            ViewBag.ListaDeJogos = db.Jogos.OrderBy(b => b.Titulo).ToList();

            return View(personagem);
        }

        // POST: Personagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Origem,TipoLuta,Fotografia,Biografia")] Personagens personagem, HttpPostedFileBase uploadFotografia, string[] checkBoxJogos)
        {
            // ler da BD o objeto que se pretende editar
            var personagens = db.Personagens.Include(b => b.ListaDeJogos).Where(b => b.ID == personagem.ID).SingleOrDefault();

            // avaliar se os dados são 'bons'
            if (ModelState.IsValid)
            {
                personagens.Nome = personagem.Nome;
                personagens.Origem = personagem.Origem;
                personagens.TipoLuta = personagem.TipoLuta;
                personagens.Fotografia = personagem.Fotografia;
                personagens.Biografia = personagem.Biografia;
            }
            else
            {
                // gerar a lista de personagens associados ao Jogo
                ViewBag.ListaDeJogos = db.Jogos.OrderBy(b => b.Titulo).ToList();
                return View(personagem);
            }

            // tentar fazer o UPDATE
            if (TryUpdateModel(personagens, new string[] { nameof(personagens.Nome), nameof(personagens.Origem), nameof(personagens.TipoLuta), nameof(personagens.Fotografia), nameof(personagens.Biografia), nameof(personagens.ListaDeJogos)}))
            {
                // obter lista de personagens
                var jogos = db.Jogos.ToList();

                if (checkBoxJogos != null)
                {
                    foreach (var item in jogos)
                    {
                        if (checkBoxJogos.Contains(item.ID.ToString()))
                        {
                            if (!personagens.ListaDeJogos.Contains(item))
                            {
                                personagens.ListaDeJogos.Add(item);
                            }
                        }
                        else
                        {
                            // caso exista associação para uma opção que não foi escolhida,
                            // remove-se essa associação
                            personagens.ListaDeJogos.Remove(item);
                        }
                    }
                }
                else
                {
                    // não existem opções escolhidas!
                    // vamos eliminar todas as associações
                    foreach (var item in jogos)
                    {
                        if (personagens.ListaDeJogos.Contains(item))
                        {
                            personagens.ListaDeJogos.Remove(item);
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
            ViewBag.ListaDeJogos = db.Personagens.OrderBy(r => r.Nome).ToList();

            string path = "";

            if (uploadFotografia == null)
            {
                db.Entry(personagem).State = EntityState.Modified;

                db.SaveChanges();
                ViewBag.Jogos = db.Jogos;
                return RedirectToAction("Index");
            }
            else
            {
                db.Entry(personagem).State = EntityState.Modified;

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
                    path = Path.Combine(Server.MapPath("~/ImagemPers/"), nomeFicheiro);

                    /// 4º como o associar ao novo Jogo?
                    personagem.Fotografia = nomeFicheiro;
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
                    db.Entry(personagem).State = EntityState.Modified;

                    db.SaveChanges();
                    ViewBag.Jogos = db.Jogos;
                    return RedirectToAction("Details", "Personagens", new { id = personagem.ID });

                }

                ViewBag.Jogos = db.Jogos;
            }
            return View(personagem);
        }

        [Authorize(Roles = "Admin")]
        /// <summary>
        /// apresenta na View os dados de uma personagem,
        /// com vista à eventual eliminação
        /// </summary>
        /// <param name="id">identificador da Personagem a apagar</param>
        /// <returns></returns>
        // GET: Personagens/Delete/5
        public ActionResult Delete(int? id)
        {
            // verificar se foi fornecido um ID válido
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            // pesquisar pela personagem cuja ID foi fornecido
            Personagens personagens = db.Personagens.Find(id);

            // verificar se a personagem foi encontrada
            if (personagens == null)
            {
                return RedirectToAction("Index");
            }
            return View(personagens);
        }

        // POST: Personagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personagens personagem = db.Personagens.Find(id);
            try
            {
                foreach (var child in personagem.ListaDeJogos.ToList())
                {
                    personagem.ListaDeJogos.Remove(child);
                }

                foreach (var child in personagem.ListaDeComentarios.ToList())
                {
                    personagem.ListaDeComentarios.Remove(child);
                }

                // remove a personagem da BD
                db.Personagens.Remove(personagem);

                // faz 'commit'
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", string.Format("Não é possível apagar a personagem {1}",
                                                           id, personagem.Nome));
            }
            // se cheguei aqui é porque houve um problema
            // devolvo os dados da Personagem à View
            return View(personagem);
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
