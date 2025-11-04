using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interface;
using MongoDB.Driver;

namespace Library.Persistence.Repositories;

public class EmprestimoRepository : IEmprestimoRepository
{
    private readonly IMongoCollection<Emprestimo> _emprestimos;
    public EmprestimoRepository(IMongoDatabase database)
    {
        _emprestimos = database.GetCollection<Emprestimo>("Emprestimos");
    }

    public async Task<bool> CriarEmprestimo(Emprestimo emprestimo) =>
        await _emprestimos.InsertOneAsync(emprestimo).ContinueWith(task => task.IsCompletedSuccessfully);

    public async Task<Emprestimo> BuscarEmprestimoPorId(string idEmprestimo) =>
        await _emprestimos.Find(e => e.Id == idEmprestimo).FirstOrDefaultAsync();

    public async Task<bool> AtualizarEmprestimo(Emprestimo emprestimo)
    {
        var filtro = Builders<Emprestimo>.Filter.Eq(e => e.Id, emprestimo.Id);
        var resultado = await _emprestimos.ReplaceOneAsync(filtro, emprestimo);
        return resultado.ModifiedCount > 0;
    }
    
    public async Task<List<Emprestimo>> ObterTodosEmprestimosAtivos()
    {
        var filtro = Builders<Emprestimo>.Filter.Eq(e => e.Status, StatusEmprestimo.ativo);
        return await _emprestimos.Find(filtro).ToListAsync();
    }
}
