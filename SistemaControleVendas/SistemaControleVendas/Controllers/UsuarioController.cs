using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaControleVendas.Controllers
{
    public class UsuarioController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(db.contasDeUsuario.ToList());
        }

        public ActionResult Registro()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario conta)
        {
            if (ModelState.IsValid)
            {
                conta.Ativo = true;
                db.contasDeUsuario.Add(conta);
                db.SaveChanges();
                Session.Clear();
                ModelState.Clear();
                ViewBag.Menssagem = conta.Nome + " " + conta.Sobrenome + " sua conta foi criada com sucesso!";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            var user = db.contasDeUsuario.FirstOrDefault(x => x.NomeUsuario.Equals(usuario.NomeUsuario) && x.Senha.Equals(usuario.Senha));
            if (user != null)
            {
                Session["UserID"] = user.UsuarioID.ToString();
                Session["Username"] = user.NomeUsuario.ToString();
                if (user.Administrador == true)
                {
                    Session["Level"] = "admin";
                }
                else
                {
                    Session["Level"] = "common";
                }
                return RedirectToAction("Logado");
            }
            else
            {
                ModelState.AddModelError("", "Usuário ou senha incorreto.");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Logado()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var usuario = db.contasDeUsuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
    }
}