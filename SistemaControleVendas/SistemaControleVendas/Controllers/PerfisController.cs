using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseModels;

namespace SistemaControleVendas.Controllers
{
    public class PerfisController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Perfis
        public ActionResult Index()
        {
            return View(db.Perfis.Where(x => x.Ativo == true).ToList());
        }

        // GET: Perfis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfis.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // GET: Perfis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerfilID,Nome,Descricao,Admin")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                Perfil temp = db.Perfis.FirstOrDefault(x => x.Nome.Equals(perfil.Nome));
                if (temp != null)
                {
                    if (temp.Ativo == false)
                    {
                        temp.Admin = perfil.Admin;
                        temp.Ativo = true;
                        db.Entry(temp).State = EntityState.Modified;
                        db.SaveChanges();
                        ViewBag.Menssagem = "Perfil " + perfil.Nome + " cadastrado com sucesso!";
                    }
                    else
                    {
                        ViewBag.Menssagem = "Perfil " + perfil.Nome + " já existe no sistema";
                    }

                }
                else
                {
                    perfil.Ativo = true;
                    db.Perfis.Add(perfil);
                    db.SaveChanges();
                    ViewBag.Menssagem = "Perfil " + perfil.Nome + " cadastrado com sucesso!";
                }
                return View();
            }

            return View(perfil);
        }

        // GET: Perfis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfis.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Perfis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerfilID,Nome,Descricao,Admin")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                perfil.Ativo = true;
                db.Entry(perfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfil);
        }

        // GET: Perfis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfis.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Perfis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfil perfil = db.Perfis.Find(id);
            perfil.Ativo = false;
            db.Entry(perfil).State = EntityState.Modified;
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
