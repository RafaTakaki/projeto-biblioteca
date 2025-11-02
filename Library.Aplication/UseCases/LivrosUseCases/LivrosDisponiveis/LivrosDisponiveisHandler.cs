using Library.Domain.Interface;
using MediatR;

namespace Library.Aplication.UseCases.LivrosUseCases.LivrosDisponiveis
{
    public class LivrosDisponiveisHandler : IRequestHandler<LivrosDisponiveisRequest, LivrosDisponiveisResponse>
    {
        private readonly ILivroRepository _livroRepository;

        public LivrosDisponiveisHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<LivrosDisponiveisResponse> Handle(LivrosDisponiveisRequest request, CancellationToken cancellationToken)
        {
            var livros = await _livroRepository.ObterLivrosDisponiveis();
            return new LivrosDisponiveisResponse { livrosDisponiveis = livros };
        }
    }
}