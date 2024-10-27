using System;

namespace MercadoLivre.Dominio
{
    public class Pergunta
    {
        public Guid ProdutoId { get; private set; }

        public Guid UsuarioId { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public DateTime Data { get; private set; }

        public Pergunta(Guid produtoId, Guid usuarioId, string titulo, string descricao)
        {
            ProdutoId = produtoId;
            UsuarioId = usuarioId;
            Titulo = titulo;
            Descricao = descricao;
            Data = DateTime.Now;
        }
    }
}
