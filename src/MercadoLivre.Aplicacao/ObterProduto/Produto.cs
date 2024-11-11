using System;

namespace MercadoLivre.Aplicacao.ObterProduto
{
    public class Produto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public string Categoria { get; set; }

        public int TotalAvaliacoes { get; set; }
    }
}
