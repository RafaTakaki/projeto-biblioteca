using System.Threading.Tasks;
using Library.Aplication.UseCases.LivrosUseCases.CadastroLivros;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Library.Api.Controllers
{
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        IMediator _mediator;

        public LivroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //debito: implementar para apenas admin e funcionario
        [HttpPost("CriarLivro")]
        [SwaggerOperation(
            Summary = "Cria um novo livro",
            Description = "Cria um novo livro no sistema.")]
        public async Task<IActionResult> Create([FromBody] CadastroLivrosRequest request)
        {
            var livro = await _mediator.Send(request);
            return Ok(livro);
        }
    }
}