using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Aplicacao.AdicionarImagemAoProduto
{
    public class AdicionarImagemAoProdutoCommandHandler
    {

        private IProdutoRepositorio _produtoRepositorio;

        public AdicionarImagemAoProdutoCommandHandler(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public CommandResult Handle(AdicionarImagemAoProdutoCommand command)
        {
            command.Validar();

            if (!command.EhValido)
                return new CommandResult(string.Join(",", command.Erros), false);

            var produtoId = command.ProdutoId;

            var galeria = Galeria.Criar(produtoId);

            foreach (var item in command.Arquivos)
            {
                galeria.AdicionarFoto(Foto.Criar(item.Name, item.Type));
            }

            _produtoRepositorio.AdicionarGaleria(galeria);
            

            return new CommandResult("galeria de fotos criadas com sucesso!", true);
        }

    }
}
