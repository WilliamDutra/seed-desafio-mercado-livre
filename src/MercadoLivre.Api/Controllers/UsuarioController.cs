using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MercadoLivre.Autenticacao.Aplicacao;
using MercadoLivre.Autenticacao.Aplicacao.Usuario;
using MercadoLivre.Autenticacao.Aplicacao.Autenticar;

namespace MercadoLivre.Api.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private CadastrarUsuarioCommandHandler _cadastrarUsuarioCommandHandler;

        private AutenticarUsuarioCommandHandler _autenticarUsuarioCommandHandler;

        public UsuarioController(CadastrarUsuarioCommandHandler cadastrarUsuarioCommandHandler, AutenticarUsuarioCommandHandler autenticarUsuarioCommandHandler)
        {
            _cadastrarUsuarioCommandHandler = cadastrarUsuarioCommandHandler;
            _autenticarUsuarioCommandHandler = autenticarUsuarioCommandHandler;
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

        [HttpPost]
        [Route("entrar")]
        public IActionResult Entrar(AutenticarUsuarioCommand command)
        {
            var resultado = _autenticarUsuarioCommandHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);
            return Ok(resultado.Mensagem);
        }


        [HttpGet]
        [Authorize]
        [Route("privado")]
        public string teste()
        {
            return "ok";
        }

    }
}
