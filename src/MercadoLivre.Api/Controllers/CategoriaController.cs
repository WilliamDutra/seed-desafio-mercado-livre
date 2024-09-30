using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MercadoLivre.Aplicacao.CriarCategoria;
using MercadoLivre.Aplicacao.CriarSubcategoria;

namespace MercadoLivre.Api.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private CriarCategoriaCommandHandler _criarCategoriaHandler;

        private CriarSubcategoriaCommandHandler _criarSubcategoriaHandler;

        public CategoriaController(CriarCategoriaCommandHandler criarCategoriaHandler, CriarSubcategoriaCommandHandler criarSubcategoriaHandler)
        {
            _criarCategoriaHandler = criarCategoriaHandler;
            _criarSubcategoriaHandler = criarSubcategoriaHandler;
        }

        [HttpPost]
        public IActionResult Salvar(CriarCategoriaCommand command)
        {
            var resultado = _criarCategoriaHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);
            return Ok(resultado.Mensagem);
        }

        [HttpPost]
        [Route("subcategoria")]
        public IActionResult AdicionarSubcategoria(CriarSubcategoriaCommand command)
        {
            var resultado = _criarSubcategoriaHandler.Handle(command);
            if(!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);
            return Ok(resultado.Mensagem);
        }

    }
}
