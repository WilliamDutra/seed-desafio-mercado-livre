using MercadoLivre.Aplicacao.CadastrarProduto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Api.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private CadastrarProdutoCommandHandler _cadastrarProdutoHandler;

        public ProdutoController(CadastrarProdutoCommandHandler cadastrarProdutoHandler)
        {
            _cadastrarProdutoHandler = cadastrarProdutoHandler;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Cadastrar(CadastrarProdutoCommand command)
        {
            var id = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "id").Value);
            command.UsuarioId = id;
            var resultado = _cadastrarProdutoHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado);
            return Ok(resultado.Mensagem);
        }
    }
}
