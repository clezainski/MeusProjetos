using Aula1406.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            List<Categoria> categorias = new List<Categoria>();
            return View(categorias);
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Categoria categoria)//(FormCollection campos) recuperar campo a campo, sem a necessidade de uma classe especifica
        {
            if (ModelState.IsValid)
            {
                //insert 
            }
            return View(categoria);
        }


        public ActionResult Edit(int? id)
        {
            //verificar se veio id
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Pesquisa na fonte de dados o objeto a editar

            //Categoria categoria = null;
            Categoria categoria = new Categoria() {
                CategoriaID = id.Value,
                Nome = "Carros",
                Descricao = "Super carros",
                Ativo = true
            };

            //Se objeto não foi encontrado na fonte de dados
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                //update
                try
                {
                    //fazer update na fonte de dados
                    //redirecionar
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return View(categoria);
        }

        //GET
        public ActionResult Delete (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Categoria categoria = null;
            Categoria categoria = new Categoria()
            {
                CategoriaID = id.Value,
                Nome = "Carros",
                Descricao = "Super carros",
                Ativo = true
            };

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]//volta tela delete
        public ActionResult DeleteConfirmed(int id)
        {
            //pesquisar objeto por id

            //alterar status do objeto para deleted ou ativo para falso

            TempData ["Mensagem"]= "Categoria excluida com sucesso!";
            return RedirectToAction("Index");
        }
    }
}