using Library.Domain.Entities;

namespace Library.Aplication.UseCases.UsuarioUseCases.UsuarioEmprestimos;

public class UsuarioEmprestimosResponse
{
    public List<Emprestimo> Emprestimos { get; set; }
    public List<Reserva> Reservas { get; set; }

    public UsuarioEmprestimosResponse(List<Emprestimo> emprestimos, List<Reserva> reservas)
    {
        Emprestimos = emprestimos;
        Reservas = reservas;
    }
}
