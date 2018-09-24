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
                if (nome.Equals("1"))
                {
                    string sql = "INSERT INTO Servico (nomeServico, valorServico, tempoMedioServico) VALUES (@nome, @valor, @tempo);";
                    con.Command.CommandText = sql;
                    con.Command.Parameters.AddWithValue("@nome", "Conserto motor");
                    con.Command.Parameters.AddWithValue("@valor", 250);
                    con.Command.Parameters.AddWithValue("@tempo", 8);
                    con.Command.ExecuteNonQuery();

                    sql = "INSERT INTO Servico (nomeServico, valorServico, tempoMedioServico) VALUES (@nome, @valor, @tempo);";
                    con.Command.CommandText = sql;
                    con.Command.Parameters.AddWithValue("@nome", "Conserto televisão");
                    con.Command.Parameters.AddWithValue("@valor", 100);
                    con.Command.Parameters.AddWithValue("@tempo", 2);
                    con.Command.ExecuteNonQuery();

                    sql = "INSERT INTO Servico (nomeServico, valorServico, tempoMedioServico) VALUES (@nome, @valor, @tempo);";
                    con.Command.CommandText = sql;
                    con.Command.Parameters.AddWithValue("@nome", "Conserto ferradura");
                    con.Command.Parameters.AddWithValue("@valor", 25);
                    con.Command.Parameters.AddWithValue("@tempo", 1);
                    con.Command.ExecuteNonQuery();

                    sql = "INSERT INTO Servico (nomeServico, valorServico, tempoMedioServico) VALUES (@nome, @valor, @tempo);";
                    con.Command.CommandText = sql;
                    con.Command.Parameters.AddWithValue("@nome", "Geração de energia infinita de graça");
                    con.Command.Parameters.AddWithValue("@valor", 0);
                    con.Command.Parameters.AddWithValue("@tempo", 999);
                    con.Command.ExecuteNonQuery();

                    sql = "INSERT INTO Servico (nomeServico, valorServico, tempoMedioServico) VALUES (@nome, @valor, @tempo);";
                    con.Command.CommandText = sql;
                    con.Command.Parameters.AddWithValue("@nome", "Conserto pratos");
                    con.Command.Parameters.AddWithValue("@valor", 10);
                    con.Command.Parameters.AddWithValue("@tempo", 1);
                    con.Command.ExecuteNonQuery();

                    sql = "INSERT INTO Servico (nomeServico, valorServico, tempoMedioServico) VALUES (@nome, @valor, @tempo);";
                    con.Command.CommandText = sql;
                    con.Command.Parameters.AddWithValue("@nome", "Conserto encanamento");
                    con.Command.Parameters.AddWithValue("@valor", 1000);
                    con.Command.Parameters.AddWithValue("@tempo", 8);
                    con.Command.ExecuteNonQuery();
                }

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
            string comando = "SELECT * FROM Servico WHERE idServico = @id; ";
            con.Command.CommandText = comando;
            con.Command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = con.Command.ExecuteReader();
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