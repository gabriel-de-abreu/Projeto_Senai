using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.Objects
{
    public class Endereco
    {
        public String Rua { get; set; }
        public String Bairro { get; set; }
        public String Cep { get; set; }
        public String Complemento { get; set; }
        public int Numero { get; set; }
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
    }
}