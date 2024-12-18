﻿using MercadoLivre.Aplicacao.AdicionarImagemAoProduto;
using MercadoLivre.Aplicacao.AvaliarProduto;
using MercadoLivre.Aplicacao.CadastrarProduto;
using MercadoLivre.Aplicacao.ObterProduto;
using MercadoLivre.Aplicacao.PerguntarSobreProduto;
using MercadoLivre.Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace MercadoLivre.Api.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private CadastrarProdutoCommandHandler _cadastrarProdutoHandler;

        private AdicionarImagemAoProdutoCommandHandler _adicionarImageAoProdutoHandler;

        private AvaliarProdutoCommandHandler _avaliarProdutoHandler;

        private PerguntarSobreOProdutoCommandHandler _perguntarSobreOProdutoHandler;

        private ObterProdutoQueryHandler _obterProdutoHandler;

        public ProdutoController(CadastrarProdutoCommandHandler cadastrarProdutoHandler, AdicionarImagemAoProdutoCommandHandler adicionarImageAoProdutoHandler, AvaliarProdutoCommandHandler avaliarProdutoHandler, PerguntarSobreOProdutoCommandHandler perguntarSobreOProdutoHandler, ObterProdutoQueryHandler obterProdutoHandler)
        {
            _cadastrarProdutoHandler = cadastrarProdutoHandler;
            _adicionarImageAoProdutoHandler = adicionarImageAoProdutoHandler;
            _avaliarProdutoHandler = avaliarProdutoHandler;
            _perguntarSobreOProdutoHandler = perguntarSobreOProdutoHandler;
            _obterProdutoHandler = obterProdutoHandler;
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

        [HttpPost]
        [Authorize]
        [Route("avaliar")]
        public IActionResult AvaliarProduto(AvaliarProdutoCommand command)
        {
            var resultado = _avaliarProdutoHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado);
            return Ok(resultado);
        }

        [HttpPost]
        [Authorize]
        [Route("perguntar")]
        public IActionResult PerguntarSobreProduto(PerguntarSobreOProdutoCommand command)
        {
            var resultado = _perguntarSobreOProdutoHandler.Handle(command);
            if (!resultado.Sucesso)
                return BadRequest(resultado);
            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult ObterDetalhes([FromQuery] Guid id)
        {
            var querie = new ObterProdutoQuery();
            querie.ProdutoId = id;
            var resultado = _obterProdutoHandler.Handle(querie); 
            return Ok(resultado);
        }

    }
}
