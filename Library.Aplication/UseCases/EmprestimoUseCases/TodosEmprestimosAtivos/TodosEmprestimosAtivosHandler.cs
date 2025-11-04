using Library.Domain.Interface;
using MediatR;

namespace Library.Aplication.UseCases.EmprestimoUseCases.TodosEmprestimosAtivos;

public class TodosEmprestimosAtivosHandler : IRequestHandler<TodosEmprestimosAtivosRequest, TodosEmprestimosAtivosResponse>
{
    private readonly IEmprestimoRepository _emprestimoRepository;

    public TodosEmprestimosAtivosHandler(IEmprestimoRepository emprestimoRepository)
    {
        _emprestimoRepository = emprestimoRepository;
    }
    public async Task<TodosEmprestimosAtivosResponse> Handle(TodosEmprestimosAtivosRequest request, CancellationToken cancellationToken)
    {
        var emprestimosAtivos = await _emprestimoRepository.ObterTodosEmprestimosAtivos();

        var response = new TodosEmprestimosAtivosResponse(emprestimosAtivos);


        return response;
    }
}
