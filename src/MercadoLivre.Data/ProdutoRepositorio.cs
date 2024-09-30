using System;
using MercadoLivre.Dominio;
using Npgsql;

namespace MercadoLivre.Data
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private MercadoLivreDbContext _DbContext;

        public ProdutoRepositorio(MercadoLivreDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public Guid Salvar(Produto produto)
        {
			string insert = @"insert into produto
							(
								id,
								nome,
								descricao,
								valor,
								quantidade,
								categoria_id,
								cadastrado_em,
                                usuario_id
							)
							values
							(
								@id,
								@nome,
								@descricao,
								@valor,
								@quantidade,
								@categoria_id,
								@cadastrado_em,
                                @usuario
							)";

            using (var command = new NpgsqlCommand())
            {
                command.CommandText = insert;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@id", produto.Id));
                command.Parameters.Add(new NpgsqlParameter("@nome", produto.Nome));
                command.Parameters.Add(new NpgsqlParameter("@descricao", produto.Descricao));
                command.Parameters.Add(new NpgsqlParameter("@valor", produto.Valor));
                command.Parameters.Add(new NpgsqlParameter("@quantidade", produto.Quantidade));
                command.Parameters.Add(new NpgsqlParameter("@categoria_id", produto.CategoriaId));
                command.Parameters.Add(new NpgsqlParameter("@cadastrado_em", produto.CriadoEm));
                command.Parameters.Add(new NpgsqlParameter("@usuario", produto.UsuarioId.ToString()));
                command.ExecuteNonQuery();
            }

            return produto.Id;
        }
    }
}
