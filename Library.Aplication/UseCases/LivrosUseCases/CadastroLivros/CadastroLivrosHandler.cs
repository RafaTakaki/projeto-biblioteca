using Library.Domain.Entities;
using Library.Domain.Interface;
using MediatR;

namespace Library.Aplication.UseCases.LivrosUseCases.CadastroLivros
{
    public class CadastroLivrosHandler : IRequestHandler<CadastroLivrosRequest, CadastroLivrosResponse>
    {

        private readonly ILivroRepository _livroRepository;

        public CadastroLivrosHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<CadastroLivrosResponse> Handle(CadastroLivrosRequest request,
        CancellationToken cancellationToken)
        {
            var livro = new Livro
            (
                request.Titulo,
                request.Autor,
                request.ISBN,
                request.Categoria,
                request.QuantidadeEstoque
            );

            var response = await _livroRepository.CadastrarLivro(livro);

            if (!response)
            {
                throw new Exception("Erro ao cadastrar livro");
            }

            return new CadastroLivrosResponse
            (
                livro.Titulo,
                livro.Autor,
                livro.ISBN,
                livro.Categoria,
                livro.QuantidadeEstoque
            );
        }
    }
}