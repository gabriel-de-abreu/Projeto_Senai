using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.Database
{
    public class ConexaoBD
    {
        public MySqlConnection Conn { get; set; }
        public MySqlCommand Command { get; set; }

        public ConexaoBD()
        {
            string con = "Server=localhost;Database=exemplo;Uid=root;Pwd=venus";
            Conn = new MySqlConnection(con);
            Command = Conn.CreateCommand();
            Conn.Open();
        }
    }
}