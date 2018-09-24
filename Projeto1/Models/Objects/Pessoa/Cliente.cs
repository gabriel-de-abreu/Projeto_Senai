using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.Objects
{
    public class Cliente
    {
        public String Nome { get; set; }
        public String Cpf { get; set; }
        public String Rg { get; set; }
        public String Senha { get; set; }
        public String Email { get; set; }
        public int Id { get; set; }
    }
}