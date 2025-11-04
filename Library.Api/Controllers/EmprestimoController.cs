using System;
using System.Threading.Tasks;
using Library.Aplication.UseCases.EmprestimoUseCases.CriarEmprestimoLivro;
using Library.Aplication.UseCases.EmprestimoUseCases.DevolucaoEmprestimo;
using Library.Aplication.UseCases.EmprestimoUseCases.TodosEmprestimosAtivos;
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
    [HttpGet("TodosEmprestimosAtivos")]
    [SwaggerOperation(
        Summary = "Obtém todos os empréstimos ativos",
        Description = "Permite que um usuário logado obtenha todos os empréstimos de livros que estão ativos.")]
    public async Task<IActionResult> TodosEmprestimosAtivos()
    {
        try
        {
            var resultado = await _mediator.Send(new TodosEmprestimosAtivosRequest());
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("DevolucaoEmprestimo")]
    [SwaggerOperation(
        Summary = "Devolve um empréstimo de livro",
        Description = "Permite que um usuário logado devolva um empréstimo de um livro.")]
    public async Task<IActionResult> DevolucaoEmprestimo([FromBody] DevolucaoEmprestimoRequest request)
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
