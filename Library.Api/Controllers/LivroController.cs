using System.Threading.Tasks;
using Library.Aplication.UseCases.LivrosUseCases.CadastroLivros;
using Library.Aplication.UseCases.LivrosUseCases.LivrosDisponiveis;
using Library.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Api.Controllers;

[Route("[controller]")]
public class LivroController : ControllerBase
{
    IMediator _mediator;

    public LivroController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CriarLivro")]
    [Authorize(Roles = nameof(TipoUsuario.administrador))]
    [SwaggerOperation(
        Summary = "Cria um novo livro",
        Description = "Cria um novo livro no sistema.")]
    public async Task<IActionResult> Create([FromBody] CadastroLivrosRequest request)
    {
        var livro = await _mediator.Send(request);
        return Ok(livro);
    }

    [HttpGet("ObterLivros")]
    [Authorize(Roles = nameof(TipoUsuario.administrador))]
    [SwaggerOperation(
        Summary = "Obtém todos os livros",
        Description = "Obtém todos os livros disponiveis no sistema.")]
    public async Task<IActionResult> BuscarTodosOsLivrosDisponiveis()
    {
        var livros = await _mediator.Send(new LivrosDisponiveisRequest());
        return Ok(livros);
    }
}
