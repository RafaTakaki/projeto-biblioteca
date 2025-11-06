using Library.Domain.Interface;
using MediatR;

namespace Library.Aplication.UseCases.LivrosUseCases.VerificarDisponibilidadeLivro;

public class VerificarDisponibilidadeLivroHandler : IRequestHandler<VerificarDisponibilidadeLivroRequest, VerificarDisponibilidadeLivroResponse>
{
    private readonly ILivroRepository _livroRepository;

    public VerificarDisponibilidadeLivroHandler(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public async Task<VerificarDisponibilidadeLivroResponse> Handle(VerificarDisponibilidadeLivroRequest request, CancellationToken cancellationToken)
    {
        var livro = await _livroRepository.ObterPorIdAsync(request.livroId);

        if (livro == null)
        {
            return new VerificarDisponibilidadeLivroResponse(false, 0);
        }

        bool disponivel = livro.QuantidadeDisponivel > 0;
        return new VerificarDisponibilidadeLivroResponse(disponivel, livro.QuantidadeDisponivel);
    }
}
