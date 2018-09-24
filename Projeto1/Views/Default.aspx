<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Projeto1.Views.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="Styles.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class ="input-main">
                <div class="input">
                    <label>Login:</label>
                    <asp:TextBox ID="Login" runat="server"></asp:TextBox>
                </div>  
                <div class="input">
                    <label>Senha:</label>
                    <asp:TextBox ID="Senha" runat="server"></asp:TextBox>
                </div>
                <div class="input-buttom">
                    <asp:Button ID="Logar" runat="server" Text="Logar" />
                </div>
            </div>
            <div class =" input-main">
                <asp:Button ID="CadastrarCliente" runat="server" Text="Cadastro de Cliente" />
                <asp:Button ID="CadastrarEmpresa" runat="server" Text="Cadastro de Empresa" />
            </div>
        </div>
    </form>
</body>
</html>
