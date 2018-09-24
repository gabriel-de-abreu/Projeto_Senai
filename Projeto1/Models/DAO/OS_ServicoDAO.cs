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
    public class OS_ServicoDAO
    {
        private ConexaoBD con;
        public OS_ServicoDAO()
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

        public OS_Servico BuscarPorId(Servico servico)
        {
            string comando = "SELECT * FROM Servico_OrdemServico WHERE Servico_idServico = @id; ";
            con.Command.CommandText = comando;
            con.Command.Parameters.AddWithValue("@id", servico.Id);
            MySqlDataReader reader = con.Command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    ServicoDAO servicoDao = new ServicoDAO();
                    OrdemServicoDAO ordemServicoDao = new OrdemServicoDAO();

                    reader.Read();
                    return new OS_Servico()
                    {
                        Valor = float.Parse(reader["valorServico_OrdemServico"].ToString()),
                        Prazo = int.Parse(reader["prazoServico_OrdemServico"].ToString()),
                        Quantidade = Convert.ToInt32(reader["quantidadeServico_OrdemServico"].ToString()),
                        OrdemServico = ordemServicoDao.BuscarPorId(Convert.ToInt32(reader["OrdemServico_idOrdemServico"].ToString()))

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

        public OS_Servico BuscarPorId(OrdemServico ordemServico)
        {

            string comando = "SELECT * FROM Servico_OrdemServico WHERE OrdemServico_idOrdemServico = @id; ";
            con.Command.CommandText = comando;
            con.Command.Parameters.AddWithValue("@id", ordemServico.Id);
            MySqlDataReader reader = con.Command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    ServicoDAO servicoDao = new ServicoDAO();
                    OrdemServicoDAO ordemServicoDao = new OrdemServicoDAO();
                    reader.Read();
                    return new OS_Servico()
                    {
                        Valor = float.Parse(reader["valorServico_OrdemServico"].ToString()),
                        Prazo = int.Parse(reader["prazoServico_OrdemServico"].ToString()),
                        Quantidade = Convert.ToInt32(reader["quantidadeServico_OrdemServico"].ToString()),
                        OrdemServico = ordemServicoDao.BuscarPorId(Convert.ToInt32(reader["OrdemServico_idOrdemServico"].ToString()))
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

        public OS_Servico Insere(OS_Servico osServico)
        {
            int retorno = 0;
            try
            {
                string sql = "INSERT INTO Servico_OrdemServico (quantidadeServico_OrdemServico, valorServico_OrdemServico," +
                " prazoServico_OrdemServico, Servico_idServico, OrdemServico_idOrdemServico) VALUES" +
                " (@quantidade, @valor, @prazo, @idServico, @idOrdemServico);";
                con.Command.CommandText = sql;
                con.Command.Parameters.AddWithValue("@quantidade", osServico.Quantidade);
                con.Command.Parameters.AddWithValue("@valor", osServico.Valor);
                con.Command.Parameters.AddWithValue("@prazo", osServico.Prazo);
                con.Command.Parameters.AddWithValue("@idServico", osServico.Servico.Id);
                con.Command.Parameters.AddWithValue("@idOrdemServico", osServico.OrdemServico.Id);

                retorno = con.Command.ExecuteNonQuery();


                return retorno > 0 ? osServico : null;

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Conn.Close();
            }
        }

        public OS_Servico GeraOS_Servico(OrdemServico ordServ, Servico servico, int quantidade)
        {

            OS_Servico os = new OS_Servico()
            {
                OrdemServico = ordServ,
                Servico = servico,
                Quantidade = quantidade,
                Prazo = ordServ.PrazoEntrega,
                Valor = servico.Valor,
            };
            return os;
        }

    }
}