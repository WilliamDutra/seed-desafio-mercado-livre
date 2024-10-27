using System;

namespace MercadoLivre.Dominio
{
    public class Foto
    {
        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public string Tipo { get; private set; }

        private Foto(Guid id, string nome, string tipo)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
        }

        public static Foto Criar(string nome, string tipo)
        {
            return new Foto(Guid.NewGuid(), nome, tipo);
        }

        public static Foto Restaurar(Guid id, string nome, string tipo)
        {
            return new Foto(id, nome, tipo);
        }
    }
}
