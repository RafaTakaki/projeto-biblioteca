using Library.Domain.Interface;
using MediatR;

namespace Library.Aplication.UseCases.UsuarioUseCases.UsuarioEmprestimos
{
    public class UsuarioEmprestimosHandler : IRequestHandler<UsuarioEmprestimosRequest, UsuarioEmprestimosResponse>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IGerenciadorTokenService _gerenciadorTokenService;

        public UsuarioEmprestimosHandler(IReservaRepository reservaRepository, IEmprestimoRepository emprestimoRepository, IGerenciadorTokenService gerenciadorTokenService)
        {
            _reservaRepository = reservaRepository;
            _emprestimoRepository = emprestimoRepository;
            _gerenciadorTokenService = gerenciadorTokenService;
        }

        public async Task<UsuarioEmprestimosResponse> Handle(UsuarioEmprestimosRequest request, CancellationToken cancellationToken)
        {
            var (userId, email) = await _gerenciadorTokenService.BuscarGuidTokenENome(request.JwtToken);
            var emprestimos = await _emprestimoRepository.BuscarEmprestimosPorIdUsuario(userId);
            var reservas = await _reservaRepository.BuscarReservasPorEmail(email);

            return new UsuarioEmprestimosResponse(emprestimos, reservas);
        }
    }
}