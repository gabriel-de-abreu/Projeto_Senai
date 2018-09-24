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
    public class EnderecoDAO { 
     private ConexaoBD con;
    public EnderecoDAO()
    {
        con = new ConexaoBD();
    }

    public Endereco Inserir(Endereco end, Cliente c)
    {
        if (end != null)
        {
            try
            {
                string sql = "INSERT INTO Endereco (ruaEndereco, bairroEndereco, cepEndereco, complementoEndereco," 
                        + " numeroEndereco, Cliente_idCliente) VALUES (@rua, @bairro, @cep, @complemento, @numero,  @idCliente);";
                con.Command.CommandText = sql;
                con.Command.Parameters.AddWithValue("@rua", end.Rua);
                con.Command.Parameters.AddWithValue("@bairro", end.Bairro);
                con.Command.Parameters.AddWithValue("@cep", end.Cep);
                con.Command.Parameters.AddWithValue("@complemento", end.Complemento);
                con.Command.Parameters.AddWithValue("@numero", end.Numero);
                con.Command.Parameters.AddWithValue("@idCliente", c.Id);
                int retorno = con.Command.ExecuteNonQuery();
                if (retorno > 0)
                {
                    end.Id = (int)con.Command.LastInsertedId;
                    return end;
                }
                else return null;
            }
            catch (Exception e) { return null; }
            finally
            {
                con.Conn.Close();
            }
        }
        else return end;
    }
    public Endereco Buscar(Endereco end)
    {
        if (end != null)
        {
            try
            {
                Endereco table = new Endereco();
                string sql = "SELECT * FROM Endereco WHERE idEndereco=@id;";
                con.Command.CommandText = sql;
                con.Command.Parameters.AddWithValue("@id", end.Id);
                MySqlDataReader reader = con.Command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return new Endereco()
                    {
                        Rua = reader["ruaEndereco"].ToString(),
                        Bairro = (reader["bairroEndereco"].ToString()),
                        Numero = Convert.ToInt32(reader["numeroEndereco"]),
                        Complemento = reader["complementoEndereco"].ToString(),
                        Cep = reader["cepEndereco"].ToString(),
                        ClienteId = Convert.ToInt32(reader["Cliente_idCliente"]),
                        Id = Convert.ToInt32(reader["idEndereco"])
                    };
                }
                else return null;
   
            }
            catch (Exception e) { return null; }
            finally { con.Conn.Close(); }
        }
        return null;
    }

    public DataTable Buscar(Cliente c)
    {
        if (c != null)
        {
            try
            {
                DataTable table = new DataTable();
                string sql = "SELECT * FROM Endereco WHERE Cliente_idCliente=" + c.Id + ";";
                //  con.Command.CommandText = sql;
                //  con.Command.Parameters.AddWithValue("@idCliente", c.Id);
                MySqlDataAdapter sqlData = new MySqlDataAdapter(sql, con.Conn);
                sqlData.Fill(table);
                return table;
            }
            catch (Exception e) { return null; }
            finally { con.Conn.Close(); }
        }
        return null;
    }

    public Endereco Alterar(Endereco end)
    {
        if (end != null)
        {
            try
            {
                string sql = "UPDATE Endereco SET ruaEndereco=@rua, bairroEndereco=@bairro, cepEndereco=@cep,"
                        + " complementoEndereco=@complemento, numeroEndereco=@numero WHERE idEndereco=@id;";
                con.Command.CommandText = sql;
                con.Command.Parameters.AddWithValue("@rua", end.Rua);
                con.Command.Parameters.AddWithValue("@bairro", end.Bairro);
                con.Command.Parameters.AddWithValue("@cep", end.Cep);
                con.Command.Parameters.AddWithValue("@complemento", end.Complemento);
                con.Command.Parameters.AddWithValue("@numero", end.Numero);
                con.Command.Parameters.AddWithValue("@id", end.Id);
                int retorno = con.Command.ExecuteNonQuery();
                return retorno > 0 ? end : null;
            }
            catch (Exception e) { return null; }
            finally
            {
                con.Conn.Close();
            }
        }
        else return end;
    }

    public Endereco Remover(Endereco end, Cliente c)
    {
        try
        {
            con.Command.CommandText = "DELETE FROM Endereco WHERE idEndereco = @id;";
            con.Command.Parameters.AddWithValue("@id", end.Id);
            int retorno = con.Command.ExecuteNonQuery();
            return retorno > 0 ? end : null;
        }
        catch (Exception e) { return null; }
        finally { con.Conn.Close(); }
    }
}
}