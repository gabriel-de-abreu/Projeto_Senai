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
    public class ClienteDAO
    {
        private ConexaoBD con;
        public ClienteDAO()
        {
            con = new ConexaoBD();
        }

        public DataTable ListarTodos(string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM Cliente;", con.Conn);
                    sqlData.Fill(table);
                    return table;
                }
                else
                {
                    DataTable table = new DataTable();
                    MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM Cliente WHERE nomeCliente LIKE '%" + nome + "';", con.Conn);
                    sqlData.Fill(table);
                    return table;
                }
            }
            catch (Exception e) { return null; }
            finally
            {
                con.Conn.Close();
            }

        }
        public Cliente BuscarPorId(int id)
        {
            string comando = "SELECT * FROM Cliente WHERE idCliente = @id; ";
            con.Command.CommandText = comando;
            con.Command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = con.Command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return new Cliente()
                    {
                        Nome = reader["nomeCliente"].ToString(),
                        Cpf = reader["cpfCliente"].ToString(),
                        Rg = reader["rgCliente"].ToString(),
                        Email = reader["emailCliente"].ToString(),
                        Senha = reader["senhaCliente"].ToString(),
                        Id = Convert.ToInt32(reader["idCliente"].ToString())
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
        public Cliente Inserir(Cliente c)
        {
            if (c != null)
            {
                try
                {
                    string sql = "INSERT INTO Cliente (nomeCliente, cpfCliente, rgCliente, emailCliente, senhaCliente) VALUES (@nome, @cpf, @rg, @email, @senha);";
                    con.Command.CommandText = sql;
                    con.Command.Parameters.AddWithValue("@nome", c.Nome);
                    con.Command.Parameters.AddWithValue("@cpf", c.Cpf);
                    con.Command.Parameters.AddWithValue("@rg", c.Rg);
                    con.Command.Parameters.AddWithValue("@email", c.Email);
                    con.Command.Parameters.AddWithValue("@senha", c.Senha);

                    int retorno = con.Command.ExecuteNonQuery();
                    if (retorno > 0)
                    {
                        c.Id = (int)con.Command.LastInsertedId;
                        return c;
                    }
                    else return null;
                }
                catch (Exception e) { return null; }
                finally
                {
                    con.Conn.Close();
                }
            }
            else return c;
        }

        public Cliente Alterar(Cliente c)
        {
            try
            {
                string sql = "UPDATE Cliente SET nomeCliente = @nome, " +
                    "cpfCliente=@cpf, rgCliente=@rg, emailCliente=@email, senhaCliente=@senha WHERE idCliente =@id;";
                con.Command.CommandText = sql;
                con.Command.Parameters.AddWithValue("@nome", c.Nome);
                con.Command.Parameters.AddWithValue("@cpf", c.Cpf);
                con.Command.Parameters.AddWithValue("@rg", c.Rg);
                con.Command.Parameters.AddWithValue("@id", c.Id);
                con.Command.Parameters.AddWithValue("@email", c.Email);
                con.Command.Parameters.AddWithValue("@senha", c.Senha);
                int retorno = con.Command.ExecuteNonQuery();
                return retorno > 0 ? c : null;
            }
            catch (Exception e) { return null; }
            finally
            {
                con.Conn.Close();
            }
        }

        public Cliente Deletar(Cliente c)
        {
                try
                {
                    con.Command.CommandText = "DELETE FROM Cliente WHERE idCliente = @id;";
                    con.Command.Parameters.AddWithValue("@id", c.Id);
                    int retorno = con.Command.ExecuteNonQuery();
                    return retorno > 0 ? c : null;
                }
                catch (Exception e) { return null; }
                finally { con.Conn.Close(); }
        }

        public Cliente Login(Cliente c)
        {
            string sql = "SELECT * FROM Cliente WHERE emailCliente = @email AND senhaCliente = @senha;";
            con.Command.CommandText = sql;
            con.Command.Parameters.AddWithValue("@email", c.Email);
            con.Command.Parameters.AddWithValue("@senha", c.Senha);
            MySqlDataReader reader = con.Command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return new Cliente()
                    {
                        Nome = reader["nomeCliente"].ToString(),
                        Cpf = reader["cpfCliente"].ToString(),
                        Rg = reader["rgCliente"].ToString(),
                        Email = reader["emailCliente"].ToString(),
                        Senha = reader["senhaCliente"].ToString(),
                        Id = Convert.ToInt32(reader["idCliente"].ToString())
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