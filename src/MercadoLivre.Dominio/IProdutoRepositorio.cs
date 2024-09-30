using System;

namespace MercadoLivre.Dominio
{
    public interface IProdutoRepositorio
    {
        Guid Salvar(Produto produto);
    }
}
