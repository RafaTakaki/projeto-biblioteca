using Library.Domain.Enums;
using Library.Domain.Interface;
using MediatR;

namespace Library.Aplication.UseCases.EmprestimoUseCases.DevolucaoEmprestimo;

public class DevolucaoEmprestimoHandler : IRequestHandler<DevolucaoEmprestimoRequest, DevolucaoEmprestimoResponse>
{
    public readonly IEmprestimoRepository _emprestimoRepository;
    public readonly ILivroRepository _livroRepository;

    public DevolucaoEmprestimoHandler(IEmprestimoRepository emprestimoRepository, ILivroRepository livroRepository)
    {
        _emprestimoRepository = emprestimoRepository;
        _livroRepository = livroRepository;
    }

    public async Task<DevolucaoEmprestimoResponse> Handle(DevolucaoEmprestimoRequest request, CancellationToken cancellationToken)
    {
        var emprestimo = await _emprestimoRepository.BuscarEmprestimoPorId(request.IdEmprestimo);

        if (emprestimo == null)
            return new DevolucaoEmprestimoResponse(false, "Empréstimo não encontrado.");

        emprestimo.DataDevolucaoReal = DateTime.UtcNow;
        emprestimo.Status = StatusEmprestimo.devolvido;

        await _emprestimoRepository.AtualizarEmprestimo(emprestimo);

        await _livroRepository.DevolverLivro(emprestimo.IdLivro);

        return new DevolucaoEmprestimoResponse(true, "Empréstimo devolvido com sucesso.");
    }
}
