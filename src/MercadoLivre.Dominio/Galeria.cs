using System;

namespace MercadoLivre.Dominio
{
    public class Galeria
    {
        public Guid ProdutoId { get; private set; }

        private List<Foto> _Fotos = new List<Foto>();

        public IReadOnlyCollection<Foto> Fotos => _Fotos;

        private Galeria(Guid produtoId)
        {
            ProdutoId = produtoId;
        }

        public void AdicionarFoto(Foto foto)
        {
            _Fotos.Add(foto);
        }

        public static Galeria Criar(Guid produtoId)
        {
            return new Galeria(produtoId);
        }

        public static Galeria Restaurar(Guid produtoId)
        {
            return new Galeria(produtoId);
        }
    }
}
