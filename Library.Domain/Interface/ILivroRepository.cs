using Library.Domain.Entities;

namespace Library.Domain.Interface
{
    public interface ILivroRepository
    {
        Task<bool> CadastrarLivro(Livro livro);
    }
}