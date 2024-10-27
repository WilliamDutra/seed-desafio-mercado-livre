using System;

namespace MercadoLivre.Dominio
{
    public interface IProdutoRepositorio
    {
        Guid Salvar(Produto produto);

        Guid AdicionarFoto(Foto foto);

        void AdicionarGaleria(Galeria galeria);

    }
}
