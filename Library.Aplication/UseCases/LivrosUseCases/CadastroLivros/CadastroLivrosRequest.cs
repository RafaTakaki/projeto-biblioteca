using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Library.Aplication.UseCases.LivrosUseCases.CadastroLivros
{
    public sealed record CadastroLivrosRequest(
        string Titulo,
        string Autor,
        string? ISBN,
        string Categoria,
        int QuantidadeEstoque
    ) : IRequest<CadastroLivrosResponse>;
}