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
        <div>
            <div class="input-main">
                <div class="input">
                    <label>Id:</label>
                    <asp:TextBox ID="Id" runat="server"></asp:TextBox>
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
                    <asp:Button ID="Cadatrar" runat="server" Text="Cadastrar" />
                    <asp:Button ID="Consultar" runat="server" Text="Consultar" />
                    <asp:Button ID="Atualizar" runat="server" Text="Atualizar" />
                    <asp:Button ID="Deletar" runat="server" Text="Deletar" />
                </div>
            </div>
        </div>

    </form>
</body>
</html>
