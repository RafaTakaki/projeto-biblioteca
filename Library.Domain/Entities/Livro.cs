using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Livro
    {
        Guid Id { get; set; }
        string Titulo { get; set; }
        string Autor { get; set; }
        string ISBN { get; set; }
        string Categoria { get; set; }
        int QuantidadeEstoque { get; set; }
        int QuantidadeDisponivel { get; set; }
        DateTime DataCadastro { get; set; }
    }
}