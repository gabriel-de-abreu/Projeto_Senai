using Projeto1.Models.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto1.Views.Servicos
{
    public partial class vwOrdemServico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empresa"] != null)
            {
                gdvOrderServices.DataSource = FillTable();
                gdvOrderServices.DataBind();
            }
        }

        private DataTable FillTable()
        {
            OrdemServicoDAO ordemServicoDao = new OrdemServicoDAO();
            return ordemServicoDao.ListarTodos();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
            Session["empresa"] = null;
        }
    }
}