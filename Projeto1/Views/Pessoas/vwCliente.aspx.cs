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
        private void CarregaCliente(Cliente cliente)
        {
            idCliente.Text = cliente.Id.ToString();;
            txtNome.Text = cliente.Nome;
            txtCpf.Text = cliente.Cpf;
            txtEmail.Text = cliente.Email;
            txtRg.Text = cliente.Rg;
        }

        private void LimpaCliente()
        {
            txtNome.Text = "";
            txtCpf.Text = "";
            txtEmail.Text = "";
            txtRg.Text = "";
            txtSenha.Text = "";
        }

        private int GetClientId()
        {
            int id = -1;
            try
            {
                return Convert.ToInt32(idCliente.Text);
            }
            catch (Exception)
            {
                Resultado.Text = "Id inválido!";
                return id;
            }
        }
        private Cliente GetClientData()
        {
            return new Cliente()
            {
                Nome = txtNome.Text,
                Cpf = txtCpf.Text,
                Email = txtEmail.Text,
                Senha = txtSenha.Text,
                Rg = txtRg.Text
            };
        }

        private void LoadClientTable()
        {
            gridClientes.DataSource = new ClienteDAO().ListarTodos("");
            gridClientes.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadClientTable();
        }

        protected void CadatrarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = GetClientData();

            if (new ClienteDAO().Inserir(cliente) != null)
            {
                Resultado.Text = "Cliente inserido com sucesso!";
            }
            else
            {
                Resultado.Text = "Falha ao inserir cliente!";

            }
            LoadClientTable();
        }

        private void BuscaCliente(int id)
        {
            Cliente cliente = new ClienteDAO().BuscarPorId(id);
            if (cliente != null)
            {
                CarregaCliente(cliente);
                Resultado.Text = "Cliente encontrado com sucesso!";
            }
            else
            {
                LimpaCliente();
                Resultado.Text = "Cliente não encontrado!";

            }
        }
        protected void ConsultarCliente_Click(object sender, EventArgs e)
        {
            int id = GetClientId();

            if (id == -1)
            {
                return;
            }
            BuscaCliente(id);
        }

        protected void AtualizarCliente_Click(object sender, EventArgs e)
        {
            int id = GetClientId();
            if (id == -1)
            {
                return;
            }

            Cliente cliente = GetClientData();
            cliente.Id = id;
            if (new ClienteDAO().Alterar(cliente) != null)
            {
                Resultado.Text = "Cliente atualizado com sucesso!";
            }
            else
            {
                Resultado.Text = "Não foi possível alterar!";
            }
            LoadClientTable();

        }

        protected void DeletarCliente_Click(object sender, EventArgs e)
        {
            int id = GetClientId();
            if (id == -1)
            {
                return;
            }
            if (new ClienteDAO().Deletar(new Cliente() { Id = id }) != null)
            {
                Resultado.Text = "Cliente Deletado com sucesso!";
            }
            else
            {
                Resultado.Text = "Não foi possível deletar";
            }
            LoadClientTable();

        }

        protected void gridClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    BuscaCliente(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    return;
            }
        }
    }
}