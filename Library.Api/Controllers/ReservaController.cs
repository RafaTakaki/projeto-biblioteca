using System;
using System.Threading.Tasks;
using Library.Aplication.UseCases.ReservaUseCases.BuscarReservasAtivas;
using Library.Aplication.UseCases.ReservaUseCases.BuscarReservasPorEmail;
using Library.Aplication.UseCases.ReservaUseCases.ReservarLivro;
using Library.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservaController : Controller
{
    IMediator _mediator;

    public ReservaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("ReservarLivro")]
    [Authorize(Roles = nameof(TipoUsuario.usuario_comum))]
    [SwaggerOperation(
        Summary = "Reserva um livro",
        Description = "Permite que um usuário logado reserve um livro disponível na biblioteca.")]
    public async Task<IActionResult> ReservarLivro([FromBody] ReservarLivroRequest request)
    {
        try
        {
            var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();
            var newRequest = request with { token = jwtToken };
            var resultado = await _mediator.Send(newRequest);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.Mensagem);
            }
            return Ok(resultado.Mensagem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("BuscarTodasReservasAtivas")]
    [Authorize(Roles = nameof(TipoUsuario.administrador))]
    [SwaggerOperation(
        Summary = "Busca todas as reservas ativas",
        Description = "Retorna uma lista de todas as reservas ativas feitas pelos usuários.")]
    public async Task<IActionResult> BuscarTodasReservasAtivas()
    {
        try
        {
            var resultado = await _mediator.Send(new BuscarReservasAtivasRequest());
            if (resultado.ReservasAtivas == null)
                return NotFound("Nenhuma reserva ativa encontrada.");

            return Ok(resultado.ReservasAtivas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("BuscarReservasPorEmail")]
    [Authorize(Roles = nameof(TipoUsuario.administrador))]
    [SwaggerOperation(
        Summary = "Busca reservas por email",
        Description = "Retorna uma lista de reservas feitas por um usuário com base no seu email.")]
    public async Task<IActionResult> BuscarReservasPorEmail([FromBody] string email)
    {
        try
        {
            var resultado = await _mediator.Send(new BuscarReservasPorEmailRequest(email));
            if (resultado.Reservas == null)
                return NotFound("Nenhuma reserva encontrada para este email.");

            return Ok(resultado.Reservas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
