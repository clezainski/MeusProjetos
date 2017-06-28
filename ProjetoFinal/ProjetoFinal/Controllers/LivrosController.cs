using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.Models;
using System.Security.Claims;

namespace ProjetoFinal.Controllers
{
    public class LivrosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: Livros
        public ActionResult Index()
        {
            if (!User.IsInRole("Administrador"))
            {
                var user = db.Users.Find(getUserId());
                var livroes = db.Livroes.Include(l => l._literatura);
                return View(livroes.Where(x => x._literatura.Idade <= user.Idade).ToList());
            }
            else
            {
                var livroes = db.Livroes.Include(l => l._literatura);
                return View(livroes.ToList());
            }
        }

        //Adquire o usuário logado
        public string getUserId()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {                
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                    return userIdValue;
                }
            }
            return null;
        }

        // GET: Livros/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livroes.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Livros/Create
        public ActionResult Create()
        {
            ViewBag.LiteraturaID = new SelectList(db.Literaturas, "LiteraturaID", "Nome");
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LivroID,Nome,Autor,Descricao,LiteraturaID")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Livroes.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LiteraturaID = new SelectList(db.Literaturas, "LiteraturaID", "Nome", livro.LiteraturaID);
            return View(livro);
        }

        // GET: Livros/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livroes.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            ViewBag.LiteraturaID = new SelectList(db.Literaturas, "LiteraturaID", "Nome", livro.LiteraturaID);
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LivroID,Nome,Autor,Descricao,LiteraturaID")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LiteraturaID = new SelectList(db.Literaturas, "LiteraturaID", "Nome", livro.LiteraturaID);
            return View(livro);
        }

        // GET: Livros/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livroes.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // POST: Livros/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livro livro = db.Livroes.Find(id);
            db.Livroes.Remove(livro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Livros/Edit/5
        [Authorize]
        public ActionResult ListByGenero(int? id)
        {
            if (id != null)
            {

                if (!User.IsInRole("Administrador"))
                {
                    var user = db.Users.Find(getUserId());
                    var livroes = db.Livroes.Include(l => l._literatura);
                    return View(livroes.Where(x => x._literatura.Idade <= user.Idade && x._literatura.LiteraturaID == id).ToList());
                }
                else
                {
                    var listaDelivros = db.Livroes.Where(x => x._literatura.LiteraturaID == id).ToList();
                    return View(listaDelivros);
                }
            }
            else
            {
                ViewBag.Menssagem = "Não foram encontrados livros deste genêro literário";
                return View();
            }
        }        
    }
}
