using CadastroCorrentista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroCorrentista.Controllers
{
    public class BasePage : System.Web.UI.Page
    {
        protected static BaseDadosBancariosContainer contexto = new BaseDadosBancariosContainer();
    }
}