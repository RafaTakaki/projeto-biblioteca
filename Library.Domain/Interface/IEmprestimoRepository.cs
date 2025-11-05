using Library.Domain.Entities;

namespace Library.Domain.Interface;

public interface IEmprestimoRepository
{
    Task<bool> CriarEmprestimo(Emprestimo emprestimo);
    Task<Emprestimo> BuscarEmprestimoPorId(string idEmprestimo);
    Task<bool> AtualizarEmprestimo(Emprestimo emprestimo);
    Task<List<Emprestimo>> ObterTodosEmprestimosAtivos();
    Task<List<Emprestimo>> BuscarEmprestimosPorIdUsuario(string idUsuario);
}
