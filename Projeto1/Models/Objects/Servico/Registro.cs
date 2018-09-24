using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.Objects
{
    public class Registro
    {
        public int Quantidade { get; set; }
        public float Valor { get; set; }
        public DateTime Prazo { get; set; }
        public int IdServico { get; set; }
        public int IdOrdemServico { get; set; }
    }
}