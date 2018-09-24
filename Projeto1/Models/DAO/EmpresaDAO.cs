using MySql.Data.MySqlClient;
using Projeto1.Models.Database;
using Projeto1.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.DAO
{
    public class EmpresaDAO
    {
        private ConexaoBD con;
        public EmpresaDAO()
        {
            con = new ConexaoBD();
        }

        public Empresa Inserir(Empresa emp)
        {
            if (emp != null)
            {
                try
                {
                    string sql = "INSERT INTO Empresa (razaoSocialEmpresa, cnpjEmpresa, senhaEmpresa, emailEmpresa) VALUES "
                        + "(@razaoSocial, @cnpj, @senha, @email);";
                    con.Command.CommandText = sql;
                    con.Command.Parameters.AddWithValue("@razaoSocial", emp.RazaoSocial);
                    con.Command.Parameters.AddWithValue("@cnpj", emp.Cnpj);
                    con.Command.Parameters.AddWithValue("@email", emp.Email);
                    con.Command.Parameters.AddWithValue("@senha", emp.Senha);
                    int retorno = con.Command.ExecuteNonQuery();
                    if (retorno > 0)
                    {
                        emp.Id = (int)con.Command.LastInsertedId;
                        return emp;
                    }
                    else return null;
                }
                catch (Exception e) { return null; }
                finally
                {
                    con.Conn.Close();
                }
            }
            else return emp;
        }

        public Empresa Alterar(Empresa emp)
        {
            try
            {
                string sql = "UPDATE Empresa SET razaoSocialEmpresa = @razaoSocial, cnpjEmpresa = @cnpj," +
                    "emailEmpresa=@email, senhaEmpresa=@senha WHERE idEmpresa =@id;";
                con.Command.CommandText = sql;
                con.Command.Parameters.AddWithValue("@razaoSocial", emp.RazaoSocial);
                con.Command.Parameters.AddWithValue("@cnpj", emp.Cnpj);
                con.Command.Parameters.AddWithValue("@email", emp.Email);
                con.Command.Parameters.AddWithValue("@senha", emp.Senha);
                int retorno = con.Command.ExecuteNonQuery();
                return retorno > 0 ? emp : null;
            }
            catch (Exception e) { return null; }
            finally
            {
                con.Conn.Close();
            }
        }

        public Empresa Deletar(Empresa emp)
        {
            try
            {
                con.Command.CommandText = "DELETE FROM Empresa WHERE idEmpresa = @id;";
                con.Command.Parameters.AddWithValue("@id", emp.Id);
                int retorno = con.Command.ExecuteNonQuery();
                return retorno > 0 ? emp : null;
            }
            catch (Exception e) { return null; }
            finally { con.Conn.Close(); }
        }



        public Empresa Login(Empresa emp)
        {
            string sql = "SELECT * FROM Empresa WHERE emailEmpresa = @email AND senhaEmpresa = @senha;";
            con.Command.CommandText = sql;
            con.Command.Parameters.AddWithValue("@email", emp.Email);
            con.Command.Parameters.AddWithValue("@senha", emp.Senha);
            MySqlDataReader reader = con.Command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return new Empresa()
                    {
                        RazaoSocial = reader["razaoSocialEmpresa"].ToString(),
                        Cnpj = reader["cnpjEmpresa"].ToString(),
                        Email = reader["emailEmpresa"].ToString(),
                        Senha = reader["senhaEmpresa"].ToString(),
                        Id = Convert.ToInt32(reader["idEmpresa"].ToString())
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