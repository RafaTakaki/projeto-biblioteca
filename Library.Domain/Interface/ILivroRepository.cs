using Library.Domain.Entities;

namespace Library.Domain.Interface
{
    public interface ILivroRepository
    {
        Task<bool> CadastrarLivro(Livro livro);
        Task<List<string>> ObterLivrosDisponiveis();

        Task<Livro?> ObterLivroPorTitulo(string titulo);
    }
}