using MediatR;

namespace Library.Aplication.UseCases.UsuarioUseCases.UsuarioEmprestimos;

public class UsuarioEmprestimosRequest : IRequest<UsuarioEmprestimosResponse>
{
    public string JwtToken { get; set; }

    public UsuarioEmprestimosRequest(string jwtToken)
    {
        JwtToken = jwtToken;
    }
}
