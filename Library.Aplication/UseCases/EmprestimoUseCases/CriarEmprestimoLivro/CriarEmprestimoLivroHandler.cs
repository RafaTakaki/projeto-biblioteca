using Library.Domain.Entities;
using Library.Domain.Interface;
using MediatR;

namespace Library.Aplication.UseCases.EmprestimoUseCases.CriarEmprestimoLivro;

public class CriarEmprestimoLivroHandler : IRequestHandler<CriarEmprestimoLivroRequest, CriarEmprestimoLivroResponse>
{
    private readonly IEmprestimoRepository _emprestimoRepository;
    private readonly IReservaRepository _reservaRepository;
    private readonly ILivroRepository _livroRepository;

    public CriarEmprestimoLivroHandler(IEmprestimoRepository emprestimoRepository, IReservaRepository reservaRepository, ILivroRepository livroRepository)
    {
        _emprestimoRepository = emprestimoRepository;
        _reservaRepository = reservaRepository;
        _livroRepository = livroRepository;
    }

    public async Task<CriarEmprestimoLivroResponse> Handle(CriarEmprestimoLivroRequest request, CancellationToken cancellationToken)
    {
        var reserva = await _reservaRepository.BuscarReservaPorId(request.IdReserva);
        
        var emprestimo = new Emprestimo(
            Guid.NewGuid().ToString(),
            reserva.IdUsuario,
            reserva.IdLivro,
            DateTime.UtcNow,
            DateTime.UtcNow.AddDays(14),
            null,
            "ativo"
        );
        var result = await _emprestimoRepository.CriarEmprestimo(emprestimo);

        if (!result)
            return new CriarEmprestimoLivroResponse
            {
                Sucesso = false,
                Mensagem = "Falha ao criar o empréstimo."
            };

        reserva.Status = "concluida";
        var resultAlterarReserva = await _reservaRepository.AtualizarReserva(request.IdReserva, "concluida");
        var ResultAlterarDisponibilidade = await _livroRepository.EmprestarLivro(reserva.IdLivro);

        if (!resultAlterarReserva || !ResultAlterarDisponibilidade)
            return new CriarEmprestimoLivroResponse
            {
                Sucesso = false,
                Mensagem = "Empréstimo criado, mas falha ao atualizar reserva ou disponibilidade do livro."
            };

        return new CriarEmprestimoLivroResponse
        {
            Sucesso = true,
            Mensagem = "Empréstimo criado com sucesso."
        };
    }
}
