using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.Objects
{
    public class Servico
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public float Valor { get; set; }
        public int TempoMedio { get; set; }
    }
}