using Library.Domain.Interface;
using MediatR;

namespace Library.Aplication.UseCases.ReservaUseCases.BuscarReservasAtivas;

public class BuscarReservasAtivasHandler : IRequestHandler<BuscarReservasAtivasRequest, BuscarReservasAtivasResponse>
{
    private readonly IReservaRepository _reservaRepository;

    public BuscarReservasAtivasHandler(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public async Task<BuscarReservasAtivasResponse> Handle(BuscarReservasAtivasRequest request, CancellationToken cancellationToken)
    {
        var reservasAtivas = await _reservaRepository.BuscarReservasAtivas();

        return new BuscarReservasAtivasResponse(reservasAtivas);
    }
}
