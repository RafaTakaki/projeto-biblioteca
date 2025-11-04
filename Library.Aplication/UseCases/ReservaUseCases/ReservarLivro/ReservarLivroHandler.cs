using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interface;
using MediatR;

namespace Library.Aplication.UseCases.ReservaUseCases.ReservarLivro;

public class ReservarLivroHandler : IRequestHandler<ReservarLivroRequest, ReservarLivroResponse>
{
    private readonly IReservaRepository _reservaRepository;
    private readonly IGerenciadorTokenService _gerenciadorTokenService;
    private readonly ILivroRepository _livroRepository;

    public ReservarLivroHandler(IReservaRepository reservaRepository, IGerenciadorTokenService gerenciadorTokenService, ILivroRepository livroRepository)
    {
        _reservaRepository = reservaRepository;
        _gerenciadorTokenService = gerenciadorTokenService;
        _livroRepository = livroRepository;
    }

    public async Task<ReservarLivroResponse> Handle(ReservarLivroRequest request, CancellationToken cancellationToken)
    {
        var (idUsuario, email) = await _gerenciadorTokenService.BuscarGuidTokenENome(request.token);

        var livro = await _livroRepository.ObterLivroPorTitulo(request.livro);

        if (livro == null)
            return new ReservarLivroResponse(false, "Livro não encontrado");

        if (livro.QuantidadeDisponivel <= 0)
            return new ReservarLivroResponse(false, "Livro não disponível para reserva");

        var reserva = new Reserva
        (
            Guid.NewGuid().ToString(),
            idUsuario,
            email,
            livro.Id,
            livro.Titulo,
            DateTime.UtcNow.Date,
            DateTime.UtcNow.AddDays(5).Date,
            StatusReserva.Ativa
        );

        var resultado = await _reservaRepository.CadastrarReserva(reserva);

        if (!resultado)
        {
            throw new Exception("Erro ao cadastrar reserva");
        }
        return new ReservarLivroResponse(true, "Reserva realizada com sucesso");
    }
}
