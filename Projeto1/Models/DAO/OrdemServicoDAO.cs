﻿using MySql.Data.MySqlClient;
using Projeto1.Models.Database;
using Projeto1.Models.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projeto1.Models.DAO
{
    public class OrdemServicoDAO
    {
        private ConexaoBD con;
        public OrdemServicoDAO()
        {
            con = new ConexaoBD();
        }

        public DataTable ListarTodos()
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM OrdemServico;", con.Conn);
                sqlData.Fill(table);


                return table;
            }
            catch (Exception e) { return null; }
            finally
            {
                con.Conn.Close();
            }
        }

        public OrdemServico BuscarPorId(int id)
        {
            string comando = "SELECT * FROM OrdemServico WHERE idOrdemServico = @id; ";
            con.Command.CommandText = comando;
            con.Command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = con.Command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    ClienteDAO clienteDao = new ClienteDAO();
                    reader.Read();
                    return new OrdemServico()
                    {
                        Status = reader["statusOrdemServico"].ToString(),
                        DataSolicitacao = DateTime.Parse( reader["dataSolicitacaoOrdemServico"].ToString()).Date,
                        PrazoEntrega = DateTime.Parse(reader["prazoEntregaOrdemServico"].ToString()).Date,
                        Total = float.Parse(reader["totalOrdemServico"].ToString()),
                        Id = int.Parse(reader["idOrdemServico"].ToString()),
                        Cliente = clienteDao.BuscarPorId(int.Parse(reader["Cliente_idCliente"].ToString()))
                    };
                }
                else return null;
            }
            catch (Exception e) { return null; }
            finally
            {
                con.Conn.Close();
            }
        }
          
    }
}
