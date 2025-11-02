using MediatR;

namespace Library.Aplication.UseCases.LivrosUseCases.LivrosDisponiveis
{
    public sealed record LivrosDisponiveisRequest() : IRequest<LivrosDisponiveisResponse>;
}