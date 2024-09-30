using System;

namespace MercadoLivre.Dominio
{
    public class Subcategoria
    {
        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public Guid CategoriaId { get; private set; }

        private Subcategoria(Guid id, string nome, Guid categoriaId)
        {
            Id = id;
            Nome = nome;
            CategoriaId = categoriaId;
        }

        public static Subcategoria Criar(string nome, Guid categoriaId)
        {
            return new Subcategoria(Guid.NewGuid(), nome, categoriaId);
        }

        public static Subcategoria Restaurar(Guid id, string nome, Guid categoriaId)
        {
            return new Subcategoria(id, nome, categoriaId);
        }

    }
}
