using MediatR;

namespace Library.Aplication.UseCases.ReservaUseCases.ReservarLivro;

public record ReservarLivroRequest(string livro, string token) : IRequest<ReservarLivroResponse>;
