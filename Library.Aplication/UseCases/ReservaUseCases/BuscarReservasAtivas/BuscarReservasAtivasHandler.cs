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
        // TODO tratar as datas para o formato "dd/MM/yyyy"
        // TODO tratar os enums para usar o name ao invés do ordinal
        
        var reservasAtivas = await _reservaRepository.BuscarReservasAtivas();

        return new BuscarReservasAtivasResponse(reservasAtivas);
    }
}
