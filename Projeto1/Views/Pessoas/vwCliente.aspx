<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwCliente.aspx.cs" Inherits="Projeto1.Views.Pessoas.vwCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="input-main">
            <div class="float-left box box-border">
                <div class="input-main">
                    <div class="input">
                        <label>Id:</label>
                        <asp:TextBox ID="idCliente" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>Nome:</label>
                        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>RG:</label>
                        <asp:TextBox ID="txtRg" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>CPF:</label>
                        <asp:TextBox ID="txtCpf" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>Email:</label>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>Senha:</label>
                        <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox>
                    </div>
                    <div class="input-main">
                        <asp:Button ID="CadatrarCliente" runat="server" Text="Cadastrar" OnClick="CadatrarCliente_Click" />
                        <asp:Button ID="ConsultarCliente" runat="server" Text="Consultar" />
                        <asp:Button ID="AtualizarCliente" runat="server" Text="Atualizar" />
                        <asp:Button ID="DeletarCliente" runat="server" Text="Deletar" />
                    </div>
                </div>
            </div>
            <div class="box box-left float-left">
                <div class="input-main">
                    <div class="input">
                        <label>Id:</label>
                        <asp:TextBox ID="enderecoId" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>Rua:</label>
                        <asp:TextBox ID="Rua" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>Número:</label>
                        <asp:TextBox ID="Numero" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>Bairro:</label>
                        <asp:TextBox ID="Bairro" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>CEP:</label>
                        <asp:TextBox ID="Cep" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>Complemento:</label>
                        <asp:TextBox ID="Complemento" runat="server"></asp:TextBox>
                    </div>
                    <div class="input-main">
                        <asp:Button ID="CadastrarEndereco" runat="server" Text="Cadastrar" />
                        <asp:Button ID="ConsultarEndereco" runat="server" Text="Consultar" />
                        <asp:Button ID="AtualizarEndereco" runat="server" Text="Atualizar" />
                        <asp:Button ID="DeletarEndereco" runat="server" Text="Deletar" />
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="line"></div>
        <div class="input-main ">
            <asp:Label ID="Resultado" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="line"></div>
    </form>

</body>
</html>
