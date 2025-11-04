using MediatR;

namespace Library.Aplication.UseCases.ReservaUseCases.BuscarReservasPorEmail;

public record BuscarReservasPorEmailRequest(string Email) : IRequest<BuscarReservasPorEmailResponse>;