using MediatR;

namespace Library.Aplication.UseCases.EmprestimoUseCases.DevolucaoEmprestimo;

public class DevolucaoEmprestimoRequest : IRequest<DevolucaoEmprestimoResponse>
{
    public string IdEmprestimo { get; set; }

    public DevolucaoEmprestimoRequest(string idEmprestimo)
    {
        IdEmprestimo = idEmprestimo;
    }
}
