using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class LiteraturasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Literaturas
        [Authorize]
        public ActionResult Index(int? idade)
        {
            if (idade == null)
            {
                idade = 0;
            }
            return View(db.Literaturas.Where(x => x.Idade >= idade).ToList());
        }

        // GET: Literaturas/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Literatura literatura = db.Literaturas.Find(id);
            if (literatura == null)
            {
                return HttpNotFound();
            }
            return View(literatura);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Literaturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Literaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LiteraturaID,Nome,Idade")] Literatura literatura)
        {
            if (ModelState.IsValid)
            {
                db.Literaturas.Add(literatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(literatura);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Literaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Literatura literatura = db.Literaturas.Find(id);
            if (literatura == null)
            {
                return HttpNotFound();
            }
            return View(literatura);
        }

        // POST: Literaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LiteraturaID,Nome,Idade")] Literatura literatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(literatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(literatura);
        }

        // GET: Literaturas/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Literatura literatura = db.Literaturas.Find(id);
            if (literatura == null)
            {
                return HttpNotFound();
            }
            return View(literatura);
        }

        // POST: Literaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrador")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Literatura literatura = db.Literaturas.Find(id);
            db.Literaturas.Remove(literatura);
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
    }
}
