using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto1.Models.Objects;
using Projeto1.Models.DAO;

namespace Projeto1.Views.Pessoas
{
    public partial class vwCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CadatrarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                Nome = txtNome.Text,
                Cpf = txtCpf.Text,
                Email = txtEmail.Text,
                Senha = txtSenha.Text,
                Rg = txtRg.Text
            };

            if(new ClienteDAO().Inserir(cliente) != null)
            {
                Resultado.Text = "Cliente inserido com sucesso!";
            }
            else
            {
                Resultado.Text = "Falha ao inserir cliente!";

            }

        }

    }
}