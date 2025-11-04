using Library.Domain.Entities;
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
}
