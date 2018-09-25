﻿using Projeto1.Models.DAO;
using Projeto1.Models.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto1.Views.Servicos
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void LoadService(Servico servico)
        {
            txtId.Text = servico.Id.ToString();
            txtNome.Text = servico.Nome;
            txtValor.Text = servico.Valor.ToString();
            txtTempo.Text = servico.TempoMedio.ToString();
        }
        private void LoadServicesTable()
        {
            servicesGrid.DataSource = new ServicoDAO().ListarTodos("");
            servicesGrid.DataBind();
        }
        private void LoadOsTable()
        {
            gridOs.DataSource = Session["dataServices"] as DataTable;
            gridOs.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dataServices"] == null)
            {
                Session["dataServices"] = SetupTable();
            }
            LoadServicesTable();
            LoadOsTable();

        }

        private void BuscarServico(int id)
        {
            Servico servico = new ServicoDAO().BuscarPorId(id);
            if (servico != null)
            {
                LoadService(servico);
            }
            else
            {
                //
            }
        }
        protected void servicesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    BuscarServico(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    break;
            }
        }


        private DataTable SetupTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("idService", typeof(int));
            table.Columns.Add("nameService", typeof(String));
            table.Columns.Add("timeService", typeof(int));
            table.Columns.Add("dateService", typeof(DateTime));
            table.Columns.Add("quantityService", typeof(int));
            table.Columns.Add("valueService", typeof(float));
            return table;
        }
        private void AddRow(int id)
        {
            DataTable table = Session["dataServices"] as DataTable;
            table.Rows.Add(id, txtNome.Text, Convert.ToInt32(txtTempo.Text) * Convert.ToInt32(txtQuantidade.Text), DateTime.Now, Convert.ToInt32(txtQuantidade.Text),
                Convert.ToDouble(txtValor.Text) * Convert.ToInt32(txtQuantidade.Text));
            LoadOsTable();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            AddRow(Convert.ToInt32(txtId.Text));
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            OS_Servico oss = new OS_Servico();
            OS_ServicoDAO ossDao = new OS_ServicoDAO();
            ServicoDAO servicoDao = new ServicoDAO();
            OrdemServico ordemServico = new OrdemServico();
            ordemServico.Servicos = new List<Servico>();
            OrdemServicoDAO osDao = new OrdemServicoDAO();
            DataTable table = Session["dataServices"] as DataTable;
            Cliente cliente = Session["client"] as Cliente;

            int hora = 0;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ordemServico.Servicos.Add(servicoDao.BuscarPorId(int.Parse(table.Rows[i]["idService"].ToString())));
                ordemServico.Total += ordemServico.Servicos[i].Valor;
                ordemServico.DataSolicitacao = DateTime.Parse(table.Rows[i]["dateService"].ToString());
                hora += int.Parse(table.Rows[i]["timeService"].ToString());
                ordemServico.Cliente.Id = 1;//cliente.Id;
                ordemServico.Status = txtStatus.Text;
                ordemServico.PrazoEntrega = ordemServico.DataSolicitacao.AddHours(hora);
            }
            ordemServico = osDao.Insere(ordemServico);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                oss = ossDao.GeraOS_Servico(ordemServico, ordemServico.Servicos[i], int.Parse(table.Rows[i]["quantityService"].ToString()));
                ossDao.Insere(oss);
            }

        }
    }


}