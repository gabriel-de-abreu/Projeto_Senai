using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.Objects
{
    public class Empresa
    {
        public String RazaoSocial { get; set; }
        public String Cnpj { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public int Id { get; set; }
    }
}