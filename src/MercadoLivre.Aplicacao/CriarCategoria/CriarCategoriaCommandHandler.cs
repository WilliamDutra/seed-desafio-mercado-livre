using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Aplicacao.CriarCategoria
{
    public class CriarCategoriaCommandHandler 
    {
        private ICategoriaRepositorio _categoriaRepositorio;

        public CriarCategoriaCommandHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public CommandResult Handle(CriarCategoriaCommand command)
        {
            command.Validar();

            if (!command.EhValido)
                return new CommandResult(string.Join(",", command.Erros), false);

            var categoriaEncontrada = _categoriaRepositorio.ObterCategoriaPorNome(command.Nome);

            if (categoriaEncontrada != null)
                return new CommandResult("Já existe uma categoria com esse mesmo nome!", false);

            var categoria = Categoria.Criar(command.Nome, command.Descricao);
            _categoriaRepositorio.Salvar(categoria);

            return new CommandResult("A categoria foi criado com sucesso!", true);
        }
    }
}
