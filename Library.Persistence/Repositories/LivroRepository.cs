using Library.Domain.Entities;
using Library.Domain.Interface;
using MongoDB.Driver;

namespace Library.Persistence.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly IMongoCollection<Livro> _livros;
    public LivroRepository(IMongoDatabase database)
    {
        _livros = database.GetCollection<Livro>("Livros");
    }

    public async Task<bool> CadastrarLivro(Livro livro)
    {
        try
        {
            await _livros.InsertOneAsync(livro);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar livro: {ex.Message}");
            return false;
        }
    }

    public async Task<List<string>> ObterLivrosDisponiveis()
    {
        var filter = Builders<Livro>.Filter.Where(l => l.QuantidadeDisponivel > 0);
        var livrosDisponiveis = _livros.Find(filter).ToListAsync().Result;
        var titulos = livrosDisponiveis.Select(l => l.Titulo).ToList();
        return await Task.FromResult(titulos);
    }

    public async Task<Livro?> ObterLivroPorTitulo(string titulo)
    {
        var filter = Builders<Livro>.Filter.Eq(l => l.Titulo, titulo);
        var livro = await _livros.Find(filter).FirstOrDefaultAsync();
        return livro;
    }

    public async Task<bool> EmprestarLivro(string livroId)
    {
        var filter = Builders<Livro>.Filter.Eq(l => l.Id, livroId);
        var update = Builders<Livro>.Update.Inc(l => l.QuantidadeDisponivel, -1);
        var result = await _livros.UpdateOneAsync(filter, update);
        return result.ModifiedCount > 0;
    }
    
    public async Task<bool> DevolverLivro(string livroId)
    {
        var filter = Builders<Livro>.Filter.Eq(l => l.Id, livroId);
        var update = Builders<Livro>.Update.Inc(l => l.QuantidadeDisponivel, 1);
        var result = await _livros.UpdateOneAsync(filter, update);
        return result.ModifiedCount > 0;
    }
}