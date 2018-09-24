using MySql.Data.MySqlClient;
using Projeto1.Models.Database;
using Projeto1.Models.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projeto1.Models.DAO
{
    public class RegistroDAO
    {
        private ConexaoBD con;
        public RegistroDAO()
        {
            con = new ConexaoBD();
        }


        public DataTable ListarTodos()
        {
            try
            {
                DataTable table = new DataTable();

                MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM Servico_OrdemServico;", con.Conn);
                sqlData.Fill(table);
                return table;
            }
            catch (Exception e) { return null; }
            finally
            {
                con.Conn.Close();
            }
        }

        public Registro BuscarPorId(Servico servico)
        {
            string comando = "SELECT * FROM Servico_OrdemServico WHERE Servico_idServico = @id; ";
            con.Command.CommandText = comando;
            con.Command.Parameters.AddWithValue("@id", servico.Id);
            MySqlDataReader reader = con.Command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return new Registro()
                    {
                        Valor = float.Parse(reader["valorServico_OrdemServico"].ToString()),
                        Prazo = DateTime.Parse(reader["prazoServico_OrdemServico"].ToString()).Date,
                        Quantidade = Convert.ToInt32(reader["quantidadeServico_OrdemServico"].ToString()),
                        IdServico = Convert.ToInt32(reader["Servico_idServico"].ToString()),
                        IdOrdemServico = Convert.ToInt32(reader["OrdemServico_idOrdemServico"].ToString())
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

        public Registro BuscarPorId(OrdemServico ordemServico)
        {
            string comando = "SELECT * FROM Servico_OrdemServico WHERE OrdemServico_idOrdemServico = @id; ";
            con.Command.CommandText = comando;
            con.Command.Parameters.AddWithValue("@id", ordemServico.Id);
            MySqlDataReader reader = con.Command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return new Registro()
                    {
                        Valor = float.Parse(reader["valorServico_OrdemServico"].ToString()),
                        Prazo = DateTime.Parse(reader["prazoServico_OrdemServico"].ToString()).Date,
                        Quantidade = Convert.ToInt32(reader["quantidadeServico_OrdemServico"].ToString()),
                        IdServico = Convert.ToInt32(reader["Servico_idServico"].ToString()),
                        IdOrdemServico = Convert.ToInt32(reader["OrdemServico_idOrdemServico"].ToString())
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