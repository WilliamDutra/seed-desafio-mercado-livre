using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Aplicacao.CriarSubcategoria
{
    public class CriarSubcategoriaCommandHandler
    {
        private ICategoriaRepositorio _categoriaRepositorio;

        public CriarSubcategoriaCommandHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public CommandResult Handle(CriarSubcategoriaCommand command)
        {
            command.Validar();

            if (!command.EhValido)
                return new CommandResult(string.Join(",", command.Erros), false);

            var categoria = _categoriaRepositorio.ObterCategoriaPorId(command.CategoriaId);

            if (categoria == null)
                return new CommandResult("A categoria não existe!", false);

            var subcategoria = Subcategoria.Criar(command.Nome, categoria.Id);
            _categoriaRepositorio.Adicionar(subcategoria);

            return new CommandResult("subcategoria criada com sucesso!", true);
        }
    }
}
