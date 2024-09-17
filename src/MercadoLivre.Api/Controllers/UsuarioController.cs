using MercadoLivre.Autenticacao.Aplicacao.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Api.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private CadastrarUsuarioCommandHandler _cadastrarUsuarioCommandHandler;

        public UsuarioController(CadastrarUsuarioCommandHandler cadastrarUsuarioCommandHandler)
        {
            _cadastrarUsuarioCommandHandler = cadastrarUsuarioCommandHandler;
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Salvar(CadastrarUsuarioCommand command)
        {
            var resultado = _cadastrarUsuarioCommandHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);
            return Ok(resultado.Mensagem);
        }
    }
}
