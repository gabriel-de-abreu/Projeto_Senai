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
            idCliente.Text = cliente.Id.ToString(); ;
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

        private int GetAddressId()
        {
            int id = -1;
            try
            {
                return Convert.ToInt32(enderecoId.Text);
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
            LoadAddressTable();
        }

        private void LoadAddressTable()
        {

            int id = GetClientId();
            if (id != -1)
            {
                gridEnderecos.DataSource = new EnderecoDAO().Buscar(new Cliente() { Id = id });
                gridEnderecos.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadClientTable();
            LoadAddressTable();
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
            LoadAddressTable();
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

        private Endereco GetAddressData()
        {
            return new Endereco()
            {
                Bairro = Bairro.Text,
                Cep = Cep.Text,
                Cliente = new ClienteDAO().BuscarPorId(GetClientId()),
                Complemento = Complemento.Text,
                Numero = Convert.ToInt32(Numero.Text),
                Rua = Rua.Text
            };

        }

        private void SetAddressData(Endereco endereco)
        {
            enderecoId.Text = endereco.Id.ToString();
            Bairro.Text = endereco.Bairro;
            Cep.Text = endereco.Cep;
            Complemento.Text = endereco.Complemento;
            Numero.Text = endereco.Numero.ToString();
            Rua.Text = endereco.Rua;
        }

        protected void CadastrarEndereco_Click(object sender, EventArgs e)
        {
            if (new EnderecoDAO().Inserir(GetAddressData(), new ClienteDAO().BuscarPorId(GetClientId())) != null)
            {
                Resultado.Text = "Endereço Adicionado com Sucesso!";
            }
            else
            {
                Resultado.Text = "Falha ao adicionar endereço!";
            }
            LoadAddressTable();
        }

        private void BuscarEndereco(int id)
        {
            Endereco endereco = new EnderecoDAO().Buscar(new Endereco() { Id = id });
            if (endereco != null)
            {
                Resultado.Text = "Endereço encontrado!";
                SetAddressData(endereco);
            }
            else
            {
                Resultado.Text = "Endereço não encontrado!";

            }
        }
        protected void ConsultarEndereco_Click(object sender, EventArgs e)
        {
            int id = GetAddressId();
            if (id == -1)
            {
                return;
            }
            BuscarEndereco(id);
        }

        protected void AtualizarEndereco_Click(object sender, EventArgs e)
        {
            int id = GetAddressId();
            if (id == -1)
            {
                return;
            }
            Endereco endereco = GetAddressData();
            endereco.Id = id;
            if (new EnderecoDAO().Alterar(endereco) != null)
            {
                Resultado.Text = "Endereço alterado com sucesso!";
            }
            else
            {
                Resultado.Text = "Não foi possível alterar!";
            }
            LoadAddressTable();
        }

        protected void DeletarEndereco_Click(object sender, EventArgs e)
        {
            int id = GetAddressId();
            int clientId = GetClientId();
            if (id == -1 || clientId == -1)
            {
                return;
            }
            if (new EnderecoDAO().Remover(new Endereco() { Id = id }, new Cliente() { Id = clientId }) != null)
            {
                Resultado.Text = "Endereço Removido com sucesso!";
            }
            else
            {
                Resultado.Text = "Não foi possível remover!";

            }
            LoadAddressTable();

        }

        protected void gridEnderecos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    BuscarEndereco(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    return;
            }
        }

        protected void VoltarLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }
    }
}