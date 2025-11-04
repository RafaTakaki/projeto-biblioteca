using Library.Domain.Entities;

namespace Library.Domain.Interface;

public interface IEmprestimoRepository
{
    Task<bool> CriarEmprestimo(Emprestimo emprestimo);
}
