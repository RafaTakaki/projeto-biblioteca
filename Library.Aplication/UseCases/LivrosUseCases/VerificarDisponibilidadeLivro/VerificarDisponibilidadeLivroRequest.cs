using MediatR;

namespace Library.Aplication.UseCases.LivrosUseCases.VerificarDisponibilidadeLivro;

public record VerificarDisponibilidadeLivroRequest(string livroId) : IRequest<VerificarDisponibilidadeLivroResponse>;