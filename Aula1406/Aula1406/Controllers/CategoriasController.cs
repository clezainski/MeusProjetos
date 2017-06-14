using Aula1406.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula1406.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias (GET = carregamento da pagina, pela primeira vez)
        public ActionResult Index()
        {
            //Retornar a lista de objetos cadastrados
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            if(model)
            return View(categoria);
        }
    }
}