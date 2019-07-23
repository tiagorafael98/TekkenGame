using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TekkenGame.Models;

namespace TekkenGame.Controllers
{
    public class ComentariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comentarios
        public ActionResult Index()
        {
            var comentarios = db.Comentarios.Include(c => c.Jogo).Include(c => c.Utilizadores);
            return View(comentarios.ToList());
        }

        // GET: Comentarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {
                return RedirectToAction("Index");
            }
            return View(comentarios);
        }

        [Authorize(Roles = "Admin, Utilizador")]
        // GET: Comentarios/Create
        public ActionResult Create()
        {
            ViewBag.JogoFK = new SelectList(db.Jogos, "ID", "Titulo");
            ViewBag.UtilizadoresFK = new SelectList(db.Utilizadores, "ID", "UserName");
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Texto,JogoFK")] Comentarios comentarios, string Username)
        {

            int idNovoComentario = 0;
            try
            {
                // vai à BD, depois à tabela dos Jogos e calcula o ID máximo
                idNovoComentario = db.Comentarios.Max(a => a.ID) + 1;
            }
            catch (Exception)
            {
                idNovoComentario = 1;
            }

            // guardar o ID do novo Jogo
            comentarios.ID = idNovoComentario;

            comentarios.DataComentario = DateTime.Now;

            List<Utilizadores> todos = db.Utilizadores.ToList();
            foreach (Utilizadores u in todos)
            {
                if (u.UserName == Username)
                {
                    comentarios.UtilizadoresFK = u.ID;
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                db.Comentarios.Add(comentarios);
                db.SaveChanges();
                return RedirectToAction("Details", "Jogos", new { ID = comentarios.JogoFK });
            }

            var errors = ModelState
    .Where(x => x.Value.Errors.Count > 0)
    .Select(x => new { x.Key, x.Value.Errors })
    .ToArray();

            ViewBag.JogoFK = new SelectList(db.Jogos, "ID", "Titulo", comentarios.JogoFK);
            ViewBag.UtilizadoresFK = new SelectList(db.Utilizadores, "ID", "UserName", comentarios.UtilizadoresFK);
            //return RedirectToAction("Details", "Jogos", new { ID = comentario.JogoFK });
            return RedirectToAction("Index", "Jogos");
        }

        //[Authorize(Roles = "Admin, Utilizador")]
        // GET: Comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Jogos");
            }
            Comentarios comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return RedirectToAction("Index", "Jogo");
            }
            //---------------------------------------------------------------------
            if (comentario.Utilizadores.UserName.Equals(User.Identity.Name) )
            {
                return View(comentario);
            }

            // se aqui cheguei, é pq o user não tem autorização para editar o comentário
            return RedirectToAction("Index", "Jogo");
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Texto,DataComentario,JogoFK,UtilizadoresFK")] Comentarios comentario)
        {
            if (ModelState.IsValid)
            {
                comentario.DataComentario = DateTime.Now;
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();

                // reenviar o user para o jogo de onde o comentário diz respeito
                return RedirectToAction("Index");
            }
       
            return View(comentario);
        }

        //GET: Comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Jogos");
            }
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {
                return RedirectToAction("Index", "Jogos");
            }
            return View(comentarios);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentarios comentarios = db.Comentarios.Find(id);
            try
            {
                // remove o comentário da memória
                db.Comentarios.Remove(comentarios);
                // commit na BD
                db.SaveChanges();
                // redirecionar para a página inicial
                return RedirectToAction("Index", "Jogos");
            }
            catch (Exception)
            {
                // mensagem de erro
                ModelState.AddModelError("", "Não foi possível remover.");
            }
            return View(comentarios);
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
