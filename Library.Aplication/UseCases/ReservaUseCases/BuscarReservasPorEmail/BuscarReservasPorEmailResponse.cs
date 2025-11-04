using Library.Domain.Entities;

namespace Library.Aplication.UseCases.ReservaUseCases.BuscarReservasPorEmail;

public class BuscarReservasPorEmailResponse
{
    public List<Reserva> Reservas { get; set; }
    public BuscarReservasPorEmailResponse(List<Reserva> reservas)
    {
        Reservas = reservas;
    }
}
