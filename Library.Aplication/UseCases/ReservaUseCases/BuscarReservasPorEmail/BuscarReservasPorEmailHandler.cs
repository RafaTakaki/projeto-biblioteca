using Library.Domain.Interface;
using MediatR;

namespace Library.Aplication.UseCases.ReservaUseCases.BuscarReservasPorEmail;

public class BuscarReservasPorEmailHandler : IRequestHandler<BuscarReservasPorEmailRequest, BuscarReservasPorEmailResponse>
{
    private readonly IReservaRepository _reservaRepository;

    public BuscarReservasPorEmailHandler(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public Task<BuscarReservasPorEmailResponse> Handle(BuscarReservasPorEmailRequest request, CancellationToken cancellationToken)
    {
        var reservas = _reservaRepository.BuscarReservasPorEmail(request.Email);
        if (reservas == null)
            throw new Exception("Erro ao buscar reservas");

        return Task.FromResult(new BuscarReservasPorEmailResponse(reservas.Result));

    }
}