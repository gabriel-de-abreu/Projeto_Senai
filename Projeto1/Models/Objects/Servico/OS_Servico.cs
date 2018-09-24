using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.Objects
{
    public class OS_Servico
    {
        public int Quantidade { get; set; }
        public float Valor { get; set; }
        public int Prazo { get; set; }
        public OrdemServico OrdemServico { get; set; }
        public Servico Servico { get; set; }

    }
}