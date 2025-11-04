using MediatR;

namespace Library.Aplication.UseCases.ReservaUseCases.BuscarReservasAtivas;

public record BuscarReservasAtivasRequest : IRequest<BuscarReservasAtivasResponse>;
