using Microsoft.AspNet.Identity.EntityFramework;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinal.Controllers
{
    //Somente usuários administradores tem acesso a controle
    [Authorize(Roles = "Administrador")]
    public class RoleController : Controller
    {
        ApplicationDbContext context;
        public RoleController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Remove(IdentityRole Role)
        {
            context.Roles.Remove(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = context.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                if (role.Name.Equals("Administrador"))
                {
                    ViewBag.Menssagem =
                       "Não é possivel alterar o perfil de Administrador do sistema.";
                    return View(role);
                }
                else
                {
                    context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = context.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(IdentityRole role)
        {
            var temp = context.Roles.Find(role.Id);
            if (temp.Name.Equals("Administrador"))
            {
                ViewBag.Menssagem =
                        "Não é possivel excluir o perfil de Administrador do sistema.";
                return View(temp);
            }
            else
            {
                if (temp.Users.Count != 0)
                {
                    ViewBag.Menssagem =
                        "Não foi possivel excluir o perfil " + temp.Name + ".\nEste perfil possui usuários cadastrados.";
                    return View(temp);
                }
                else
                {
                    context.Roles.Remove(temp);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }                        
        }
    }
}