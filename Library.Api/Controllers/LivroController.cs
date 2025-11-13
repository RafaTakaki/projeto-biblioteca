using System.Threading.Tasks;
using Library.Aplication.UseCases.LivrosUseCases.CadastroLivros;
using Library.Aplication.UseCases.LivrosUseCases.LivrosDisponiveis;
using Library.Aplication.UseCases.LivrosUseCases.VerificarDisponibilidadeLivro;
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

    [HttpGet("ObterLivrosDisponiveis")]
    [SwaggerOperation(
        Summary = "Obtém todos os livros Disponiveis",
        Description = "Obtém todos os livros disponiveis no sistema.")]
    public async Task<IActionResult> BuscarTodosOsLivrosDisponiveis()
    {
        var livros = await _mediator.Send(new LivrosDisponiveisRequest());
        return Ok(livros);
    }

    [HttpGet("VerificarDisponibilidadeLivro/{livroId}")]
    [Authorize(Roles = nameof(TipoUsuario.administrador))]
    [SwaggerOperation(
        Summary = "Verifica a disponibilidade de um livro",
        Description = "Verifica se um livro está disponível para empréstimo.")]
    public async Task<IActionResult> VerificarDisponibilidadeLivro(string livroId)
    {
        var resultado = await _mediator.Send(new VerificarDisponibilidadeLivroRequest(livroId));
        if (!resultado.Disponivel)
            return NotFound("Livro não disponível");

        return Ok(resultado.QuantidadeDisponivel);
    }

}
