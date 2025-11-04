using Library.Domain.Entities;
using Library.Domain.Interface;
using MediatR;

namespace Library.Aplication.UseCases.UsuarioUseCases.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public CreateUserHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request,
    CancellationToken cancellationToken)
    {
        var user = new Usuario
        (
            request.Nome,
            request.Email,
            request.Senha,
            request.Apelido,
            request.DataNascimento
        );

        var response = await _usuarioRepository.CriarUsuario(user);

        if (!response)
        {
            throw new Exception("Erro ao criar usuário");
        }

        return new CreateUserResponse
        (
            user.Nome,
            user.Email,
            user.Apelido,
            user.DataNascimento
        );


    }
}
