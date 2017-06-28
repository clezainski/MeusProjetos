using Microsoft.Reporting.WebForms;
using ProjetoFinal.Models;
using ProjetoFinal.Relatorios.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal.Relatorios
{
    public partial class ListaDeUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dsRelatorioDeUsuarios dataSet = new dsRelatorioDeUsuarios();

                Relatorios.DataSets.dsRelatorioDeUsuariosTableAdapters.ListaUsuariosTableAdapter tableAdapter = new Relatorios.DataSets.dsRelatorioDeUsuariosTableAdapters.ListaUsuariosTableAdapter();

                tableAdapter.Fill(dataSet.ListaUsuarios);


                ReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ReportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Relatorios\Layouts\ListaUsuarios.rdlc";
                ReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", (System.Data.DataTable)dataSet.ListaUsuarios));

                ReportViewer.LocalReport.Refresh();
            }
        }
    }
}