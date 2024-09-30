using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Aplicacao.CadastrarProduto
{
    public class CadastrarProdutoCommandHandler
    {
        private IProdutoRepositorio _produtoRepositorio;

        public CadastrarProdutoCommandHandler(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public CommandResult Handle(CadastrarProdutoCommand command)
        {

            command.Validar();

            if (!command.EhValido)
                return new CommandResult(string.Join(",", command.Erros), false);

            var produto = Produto.Criar(command.Nome, command.Descricao, command.Valor, command.Quantidade, command.CategoriaId, command.UsuarioId);
            _produtoRepositorio.Salvar(produto);

            return new CommandResult("produto cadastrado com sucesso!", true);
        }

    }
}
