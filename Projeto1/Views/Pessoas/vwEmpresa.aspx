<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwEmpresa.aspx.cs" Inherits="Projeto1.Views.Pessoas.vwEmpresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../Styles.css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <div class="input">
                <label>CNPJ: </label>
                <asp:TextBox ID="txtCnpj" runat="server"></asp:TextBox>
            </div>
            <div class="input">
                <label>Razão Social:</label>
                <asp:TextBox ID="txtRazSoc" runat="server"></asp:TextBox>
            </div>
            <div class="input">
                <label>Email:</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            <div class="input">
                <label>Senha:</label>
                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="input-buttom-margin">
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            </div>
        </div>
        <div class ="line"></div>
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        <div class ="line"></div>
        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
    </form>
</body>
</html>
