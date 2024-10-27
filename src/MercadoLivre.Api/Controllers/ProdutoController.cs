using MercadoLivre.Aplicacao.AdicionarImagemAoProduto;
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

        private AdicionarImagemAoProdutoCommandHandler _adicionarImageAoProdutoHandler;

        public ProdutoController(CadastrarProdutoCommandHandler cadastrarProdutoHandler, AdicionarImagemAoProdutoCommandHandler adicionarImageAoProdutoHandler)
        {
            _cadastrarProdutoHandler = cadastrarProdutoHandler;
            _adicionarImageAoProdutoHandler = adicionarImageAoProdutoHandler;
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

        [HttpPost]
        [Authorize]
        [Route("galeria")]
        public IActionResult AdicionarImagem(Guid produtoId, IEnumerable<IFormFile> arquivos)
        {
            var command = new AdicionarImagemAoProdutoCommand();
            command.ProdutoId = produtoId;

            foreach (var arquivo in arquivos)
            {
                command.AdicionarArquivo(arquivo.OpenReadStream(), arquivo.FileName, arquivo.ContentType);
            }

            var resultado = _adicionarImageAoProdutoHandler.Handle(command);

            if (!resultado.Sucesso)
                return BadRequest(resultado);
            return Ok(resultado);
        }

    }
}
