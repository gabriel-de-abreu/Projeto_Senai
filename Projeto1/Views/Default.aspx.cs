using Projeto1.Models.DAO;
using Projeto1.Models.Objects;
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
            Response.Redirect("~/Views/Pessoas/vwEmpresa.aspx");

        }

        protected void Logar_Click(object sender, EventArgs e)
        {

            Cliente cliente = new ClienteDAO().Login(new Cliente() { Email = Login.Text, Senha = Senha.Text });
            if (cliente != null)
            {
                Session["client"] = cliente;
                Response.Redirect("~/Views/Servicos/vwRegistrar.aspx");
            }
            else
            {
                lblResultado.Text = "Login ou Senha Inválidos";
            }
        }

        protected void LogarEmpresa_Click(object sender, EventArgs e)
        {
            Empresa empresa = new EmpresaDAO().Login(new Empresa() { Email = Login.Text, Senha = Senha.Text });
            if (empresa != null)
            {
                Session["empresa"] = empresa;
                Response.Redirect("~/Views/Servicos/vwOrdemServico.aspx");
            }
            else
            {
                lblResultado.Text = "Login ou Senha Inválidos";

            }
        }
    }
}