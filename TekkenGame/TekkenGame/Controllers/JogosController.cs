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
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Logotipo,Resumo")] Jogos jogo, HttpPostedFileBase uploadFotografia)
        {
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

        [Authorize( Roles = "Admin")]
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

            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Logotipo,Resumo")] Jogos jogo, HttpPostedFileBase uploadFotografia)
        {
            string path = "";

            if (uploadFotografia == null)
            {
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
            }

            if (ModelState.IsValid)
            {

                uploadFotografia.SaveAs(path);
                db.Entry(jogo).State = EntityState.Modified;

                db.SaveChanges();
                ViewBag.Plataformas = db.Plataformas;
                return View(jogo);

            }
            ViewBag.Plataformas = db.Plataformas;
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
