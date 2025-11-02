using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Aplication.UseCases.LivrosUseCases.CadastroLivros
{
    public sealed record CadastroLivrosResponse
    {
        public string Titulo { get; init; }
        public string Autor { get; init; }
        public string ISBN { get; init; }
        public string Categoria { get; init; }
        public int QuantidadeEstoque { get; init; }

        public CadastroLivrosResponse(
            string titulo,
            string autor,
            string isbn,
            string categoria,
            int quantidadeEstoque
        )
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            Categoria = categoria;
            QuantidadeEstoque = quantidadeEstoque;
        }
    }
}