using Library.Domain.Entities;
using Library.Domain.Enums;
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
        var filtro = Builders<Reserva>.Filter.Eq(r => r.Status, StatusReserva.Ativa);
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

    public async Task<Reserva> BuscarReservaPorId(string reservaId)
    {
        var filtro = Builders<Reserva>.Filter.Eq(r => r.Id, reservaId);
        return await _reservas.Find(filtro).FirstOrDefaultAsync();
    }

    public async Task<bool> ConcluirReserva(string reservaId)
    {
        var filtro = Builders<Reserva>.Filter.Eq(r => r.Id, reservaId);
        var update = Builders<Reserva>.Update.Set(r => r.Status, StatusReserva.Concluida);
        var resultado = await _reservas.UpdateOneAsync(filtro, update);
        return resultado.ModifiedCount > 0;
    }

    public async Task<bool> AtualizarReserva(string IdReserva, StatusReserva status)
    {
        var filtro = Builders<Reserva>.Filter.Eq(r => r.Id, IdReserva);
        var update = Builders<Reserva>.Update.Set(r => r.Status, status);
        var resultado = _reservas.UpdateOneAsync(filtro, update);
        return await resultado.ContinueWith(t => t.Result.ModifiedCount > 0);
    }
}
