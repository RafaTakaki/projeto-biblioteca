using Library.Domain.Entities;

namespace Library.Domain.Interface;

public interface IReservaRepository
{
    Task<List<Reserva>> BuscarReservasAtivas();
    Task<List<Reserva>> BuscarReservasPorEmail(string email);
    Task<Reserva> BuscarReservaPorId(string reservaId);
    Task<bool> CadastrarReserva(Reserva reserva);
    Task<bool> AtualizarReserva(string IdReserva, string status);
}