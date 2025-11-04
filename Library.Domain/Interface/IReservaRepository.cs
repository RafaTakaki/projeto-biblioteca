using Library.Domain.Entities;

namespace Library.Domain.Interface;

public interface IReservaRepository
{
    Task<List<Reserva>> BuscarReservasAtivas();
    Task<List<Reserva>> BuscarReservasPorEmail(string email);
    Task<bool> CadastrarReserva(Reserva reserva);
}