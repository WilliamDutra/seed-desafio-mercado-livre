using System;

namespace MercadoLivre.Dominio
{
    public class Avaliacao
    {
        public Guid ProdutoId { get; private set; }

        public Guid UsuarioId { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public int Nota { get; private set; }

        public Avaliacao(Guid produtoId, Guid usuarioId, string titulo, string descricao, int nota)
        {
            ProdutoId = produtoId;
            UsuarioId = usuarioId;
            Titulo = titulo;
            Descricao = descricao;
            Nota = nota;
        }
    }
}
