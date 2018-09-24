<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwRegistrar.aspx.cs" Inherits="Projeto1.Views.Servicos.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="box input-main float-left">
            <asp:GridView ID="servicesGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="servicesGrid_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idServico") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("idServico") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nomeServico") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("nomeServico") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("valorServico") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("valorServico") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tempo Médio">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("tempoMedioServico") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("tempoMedioServico") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnSelect" runat="server" CommandName="Select" CommandArgument='<%# Bind("idServico") %>'>Selecionar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="input-main box float-left">
            <div class="input">
                <label>Id:</label>
                <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            </div>
            <div class="input">
                <label>Nome:</label>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </div>
            <div class=" input">
                <label>Valor:</label>
                <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
            </div>
            <div class=" input">
                <label>Tempo Médio:</label>
                <asp:TextBox ID="txtTempo" runat="server"></asp:TextBox>
            </div>
            <div class=" input">
                <label>Data da Solicitação:</label>
                <asp:TextBox ID="txtData" runat="server"></asp:TextBox>
            </div>
            <div class=" input">
                <label>Status:</label>
                <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>
            </div>
            <div class=" input">
                <label>Quantidade:</label>
                <asp:TextBox ID="txtQuantidade" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="input-main">
            <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
        </div>
        <div class="line"></div>
        <div class="input-main">
            <asp:GridView ID="gridOs" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="idService" HeaderText="ID" />
                    <asp:BoundField DataField="nameService" HeaderText="Nome" />
                    <asp:BoundField DataField="quantityService" HeaderText="Quantidade" />
                    <asp:BoundField DataField="dateService" HeaderText="Data" />
                    <asp:BoundField DataField="valueService" HeaderText="Valor" />
                    <asp:BoundField DataField="timeService" HeaderText="Tempo Médio" />
                </Columns>
            </asp:GridView>
        </div>
        <div class ="input-main simple-margin">
            <asp:Button ID="Button1" runat="server" Text="Registrar" />
        </div>
        <div class="line"></div>
    </form>
</body>
</html>
