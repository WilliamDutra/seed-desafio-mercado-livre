using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Aplicacao.PerguntarSobreProduto
{
    public class PerguntarSobreOProdutoCommandHandler 
    {
        private IProdutoRepositorio _produtoRepositorio;

        public PerguntarSobreOProdutoCommandHandler(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public CommandResult Handle(PerguntarSobreOProdutoCommand command)
        {
            command.Validar();

            if (!command.EhValido)
                return new CommandResult(string.Join(",", command.Erros), false);

            var pergunta = new Pergunta(command.ProdutoId, command.UsuarioId, command.Titulo, command.Descricao);

            _produtoRepositorio.AdicionarPergunta(pergunta);

            return new CommandResult("pergunta realizada com sucesso!", false);
        }
    }
}
