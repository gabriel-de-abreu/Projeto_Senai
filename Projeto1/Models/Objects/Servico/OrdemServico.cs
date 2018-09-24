using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.Objects
{
    public class OrdemServico
    {
        int Id { get; set; }
        DateTime DataSolicitacao { get; set; }
        int PrazoEntrega { get; set; }
        float Total { get; set; }
        String Status { get; set; }
    }
}