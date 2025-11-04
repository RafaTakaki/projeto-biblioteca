using MediatR;

namespace Library.Aplication.UseCases.EmprestimoUseCases.CriarEmprestimoLivro;

public class CriarEmprestimoLivroRequest : IRequest<CriarEmprestimoLivroResponse>
{
    public string IdReserva { get; set; }

    public CriarEmprestimoLivroRequest(string idReserva)
    {
        IdReserva = idReserva;
    }
}
