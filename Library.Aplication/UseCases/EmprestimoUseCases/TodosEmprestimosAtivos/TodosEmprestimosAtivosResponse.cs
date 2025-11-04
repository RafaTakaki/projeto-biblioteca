using Library.Domain.Entities;

namespace Library.Aplication.UseCases.EmprestimoUseCases.TodosEmprestimosAtivos;

public class TodosEmprestimosAtivosResponse
{
    public List<Emprestimo> EmprestimosAtivos { get; set; }

    public TodosEmprestimosAtivosResponse(List<Emprestimo> emprestimosAtivos)
    {
        EmprestimosAtivos = emprestimosAtivos;
    }
}
