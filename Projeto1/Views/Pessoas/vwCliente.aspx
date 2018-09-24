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
                        <asp:Button ID="ConsultarCliente" runat="server" Text="Consultar" OnClick="ConsultarCliente_Click" />
                        <asp:Button ID="AtualizarCliente" runat="server" Text="Atualizar" OnClick="AtualizarCliente_Click" />
                        <asp:Button ID="DeletarCliente" runat="server" Text="Deletar" OnClick="DeletarCliente_Click" />
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

        <div class="box float-left">
            <asp:GridView ID="gridClientes" runat="server" AutoGenerateColumns="False" OnRowCommand="gridClientes_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idCliente") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("idCliente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nomeCliente") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("nomeCliente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CPF">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("cpfCliente") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("cpfCliente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="RG">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("rgCliente") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("rgCliente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("emailCliente") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("emailCliente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="clientSelect" runat="server" CommandName="Select" CommandArgument='<%# Bind("idCliente") %>'>Selecionar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
