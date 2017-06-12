using Aula1206.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula1206.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            List<Categoria> categorias = new List<Categoria>();
            categorias.Add(new Models.Categoria() { Nome = "Carros" });
            categorias.Add(new Models.Categoria() { Nome = "Motos" });
            categorias.Add(new Models.Categoria() { Nome = "Aviões" });
            categorias.Add(new Models.Categoria() { Nome = "Barcos" });
            categorias.Add(new Models.Categoria() { Nome = "Caminhões" });

            //List<string> categorias = new List<string>();
            ////categorias.Add("carros");
            ////categorias.Add("motos");
            ////categorias.Add("aviões");
            ////categorias.Add("caminhões");
            ////categorias.Add("barcos");

            ViewBag.listaCategorias = categorias;

            return View(categorias);
        }
        //get somente carrega a pagina do formulário
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            return View(categoria);
        }
    }
}