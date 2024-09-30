using System;

namespace MercadoLivre.Dominio
{
    public interface ICategoriaRepositorio
    {
        Guid Salvar(Categoria categoria);

        Guid Adicionar(Subcategoria subcategoria);

        Categoria? ObterCategoriaPorNome(string nome);

        Categoria? ObterCategoriaPorId(Guid id);

    }
}
