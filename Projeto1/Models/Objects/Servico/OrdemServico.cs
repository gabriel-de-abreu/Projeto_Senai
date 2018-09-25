using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.Objects
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime PrazoEntrega { get; set; }
        public float Total { get; set; }
        public String Status { get; set; }
        public List<Servico> Servicos { get; set; }

        public OrdemServico()
        {
            Servicos = new List<Servico>();
            Cliente = new Cliente();
        }

    }

    
}