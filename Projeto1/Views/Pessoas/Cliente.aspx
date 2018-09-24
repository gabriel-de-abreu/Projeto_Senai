<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Projeto1.Views.Pessoas.Cliente" %>

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
                        <asp:TextBox ID="Nome" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>RG:</label>
                        <asp:TextBox ID="Rg" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>CPF:</label>
                        <asp:TextBox ID="Cpf" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>Email:</label>
                        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                    </div>
                    <div class="input">
                        <label>Senha:</label>
                        <asp:TextBox ID="Senha" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="CadatrarCliente" runat="server" Text="Cadastrar" />
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
                    <div>
                        <asp:Button ID="Button1" runat="server" Text="Cadastrar" />
                        <asp:Button ID="Button2" runat="server" Text="Consultar" />
                        <asp:Button ID="Button3" runat="server" Text="Atualizar" />
                        <asp:Button ID="Button4" runat="server" Text="Deletar" />
                    </div>
                </div>
            </div>
        </div>
        <div class="clea clearfix"></div>
        <div class="line">
        </div>
    </form>

</body>
</html>
