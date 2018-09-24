using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.Objects
{
    public class Cliente
    {
        String Nome { get; set; }
        String Cpf { get; set; }
        String Rg { get; set; }
        String Senha { get; set; }
        String Email { get; set; }
        Endereco Endereco { get; set; }
    }
}