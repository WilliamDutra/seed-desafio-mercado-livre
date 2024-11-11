using System;
using Npgsql;
using System.Data;
using MercadoLivre.Data;

namespace MercadoLivre.Aplicacao.ObterProduto
{
    public class ObterProdutoQueryHandler
    {
        private MercadoLivreDbContext _dbContext;

        public ObterProdutoQueryHandler(MercadoLivreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Produto> Handle(ObterProdutoQuery query)
        {
            var produtos = new List<Produto>();

            string select = @"select
								produto.id,
								produto.nome,
								produto.descricao,
								produto.valor,
								produto.categoria_id,
								categoria.nome categoria,
								categoria.descricao,
								pergunta.titulo,
								pergunta.descricao,
								count(avaliacao.produto_id) total_avaliacoes
							from 
								produto produto
							inner join
								categoria categoria
							on
								categoria.id = produto.categoria_id
							left join
								galeria galeria
							on
								galeria.produto_id = produto.id
							left join
								pergunta pergunta
							on
								pergunta.produto_id = produto.id
							left join
								avaliacao avaliacao
							on
								avaliacao.produto_id = produto.id
							where
								produto.id = @produto
							group by
								produto.id,
								produto.nome,
								produto.descricao,
								produto.valor,
								produto.categoria_id,
								categoria.nome,
								categoria.descricao,
								pergunta.titulo,
								pergunta.descricao";

            using (var command = new NpgsqlCommand())
            {
                command.Connection = _dbContext.Conexao;
                command.CommandText = select;
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new NpgsqlParameter("@produto", query.ProdutoId.ToString()));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    produtos.Add(new Produto
                    {
						Id = Guid.Parse(reader["id"].ToString()),
						Nome = reader["nome"].ToString(),
						Descricao = reader["descricao"].ToString(),
						Categoria = reader["categoria"].ToString(),
						Preco = decimal.Parse(reader["valor"].ToString()),
						TotalAvaliacoes = Convert.ToInt32(reader["total_avaliacoes"].ToString())
                    });
                }
				reader.Close();
            }

            return produtos;
        }
    }
}
