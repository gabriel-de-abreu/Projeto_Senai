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
    public class ServicoDAO
    {
        private ConexaoBD con;
        public ServicoDAO()
        {
            con = new ConexaoBD();
        }
        
        public DataTable ListarTodos(string nome)
        {
            try
            {
                DataTable table = new DataTable();
                

                    if (string.IsNullOrEmpty(nome))
                { 

                    MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM Servico;", con.Conn);
                    sqlData.Fill(table);
                }
                else
                {
                    MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM Servico WHERE nomeServico LIKE '%" + nome + "';", con.Conn);
                    sqlData.Fill(table);
                }
                return table;
            }
            catch (Exception e) { return null; }
            finally
            {
                con.Conn.Close();
            }
        }

        public Servico BuscarPorId(int id)
        {
            con.Conn.Close();
            con.Conn.Open();
            string comando = "SELECT * FROM Servico WHERE idServico = @id; ";
            con.Command.CommandText = comando;
            con.Command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = con.Command.ExecuteReader();
            con.Command.Parameters.Clear();
            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return new Servico()
                    {
                        Nome = reader["nomeServico"].ToString(),
                        Valor = float.Parse(reader["valorServico"].ToString()),
                        TempoMedio = Convert.ToInt32(reader["tempoMedioServico"].ToString()),
                        Id = Convert.ToInt32(reader["idServico"].ToString())
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