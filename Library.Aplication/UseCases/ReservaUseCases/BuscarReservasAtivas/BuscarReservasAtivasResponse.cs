using Library.Domain.Entities;

namespace Library.Aplication.UseCases.ReservaUseCases.BuscarReservasAtivas;

public record BuscarReservasAtivasResponse
{
    public List<Reserva> ReservasAtivas { get; init; }

    public BuscarReservasAtivasResponse(List<Reserva> reservasAtivas)
    {
        ReservasAtivas = reservasAtivas;
    }
}
