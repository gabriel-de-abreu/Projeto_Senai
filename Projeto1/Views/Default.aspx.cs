using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto1.Views
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CadastrarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pessoas/vwCliente.aspx");
        }

        protected void CadastrarEmpresa_Click(object sender, EventArgs e)
        {

        }
    }
}