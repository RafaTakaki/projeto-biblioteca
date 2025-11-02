using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Aplication.UseCases.LivrosUseCases.LivrosDisponiveis
{
    public sealed record LivrosDisponiveisResponse
    {
        public List<string> livrosDisponiveis { get; set; } = new List<string>();
    }
}