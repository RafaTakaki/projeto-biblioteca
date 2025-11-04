using Library.Domain.Entities;
using Library.Domain.Interface;
using MongoDB.Driver;

namespace Library.Persistence.Repositories;

public class ReservaRepository : IReservaRepository
{
    private readonly IMongoCollection<Reserva> _reservas;

    public ReservaRepository(IMongoDatabase database)
    {
        _reservas = database.GetCollection<Reserva>("Reservas");
    }

    public Task<List<Reserva>> BuscarReservasAtivas()
    {
        var filtro = Builders<Reserva>.Filter.Eq(r => r.Status, "ativa");
        return _reservas.Find(filtro).ToListAsync();
    }

    public Task<List<Reserva>> BuscarReservasPorEmail(string email)
    {
        var filtro = Builders<Reserva>.Filter.Eq(r => r.EmailUsuario, email);
        return _reservas.Find(filtro).ToListAsync();
    }

    public async Task<bool> CadastrarReserva(Reserva reserva)
    {
        try
        {
            await _reservas.InsertOneAsync(reserva);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar reserva: {ex.Message}");
            return false;
        }
    }

}
