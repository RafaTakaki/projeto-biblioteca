using System;
using System.Threading.Tasks;
using Library.Aplication.UseCases.EmprestimoUseCases.CriarEmprestimoLivro;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Api.Controllers;

[Route("[controller]")]
public class EmprestimoController : Controller
{
    IMediator _mediator;

    public EmprestimoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CriarEmprestimoLivro")]
    [SwaggerOperation(
        Summary = "Cria um empréstimo de livro",
        Description = "Permite que um usuário logado crie um empréstimo de um livro disponível na biblioteca.")]
    public async Task<IActionResult> CriarEmprestimoLivro([FromBody] CriarEmprestimoLivroRequest request)
    {
        try
        {
            var resultado = await _mediator.Send(request);
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
}
