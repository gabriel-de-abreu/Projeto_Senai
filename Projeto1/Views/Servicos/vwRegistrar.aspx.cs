using Projeto1.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto1.Views.Servicos
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void LoadServicesTable()
        {
            servicesGrid.DataSource = new ServicoDAO().ListarTodos("");
            servicesGrid.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadServicesTable();
        }
    }
}