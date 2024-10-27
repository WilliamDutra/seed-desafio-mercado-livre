using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Aplicacao.AvaliarProduto
{
    public class AvaliarProdutoCommandHandler
    {
        private IProdutoRepositorio _produtoRepositorio;

        public AvaliarProdutoCommandHandler(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public CommandResult Handle(AvaliarProdutoCommand command)
        {

            command.Validar();

            if (!command.EhValido)
                return new CommandResult(string.Join(",", command.Erros), false);

            var avaliacao = new Avaliacao(command.ProdutoId, command.UsuarioId, command.Titulo, command.Descricao, command.Nota);

            _produtoRepositorio.AdicionarAvaliacao(avaliacao);

            return new CommandResult("avaliação adiciona com sucesso!", true);
        }

    }
}
