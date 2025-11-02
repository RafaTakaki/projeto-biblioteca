using Library.Domain.Entities;
using Library.Domain.Interface;
using MongoDB.Driver;

namespace Library.Persistence.Repositories
{
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
    }
}