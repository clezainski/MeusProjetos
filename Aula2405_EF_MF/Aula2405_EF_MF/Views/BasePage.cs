using Aula2405_EF_MF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula2405_EF_MF.Views
{
    public class BasePage : System.Web.UI.Page
    {
        protected BaseDadosContainer contexto = new BaseDadosContainer();
    }
}