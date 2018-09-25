using Projeto1.Models.DAO;
using Projeto1.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto1.Views.Pessoas
{
    public partial class vwEmpresa : System.Web.UI.Page
    {
        private Empresa GetEmpresaData()
        {
            return new Empresa()
            {
                Cnpj = txtCnpj.Text,
                Email = txtEmail.Text,
                RazaoSocial = txtRazSoc.Text,
                Senha = txtSenha.Text
            };

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (new EmpresaDAO().Inserir(GetEmpresaData()) != null)
            {
                lblResultado.Text = "Empresa Cadastrada com sucesso!";
            }
            else
            {
                lblResultado.Text = "Falha ao cadastrar empresa!";
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");

        }
    }
}