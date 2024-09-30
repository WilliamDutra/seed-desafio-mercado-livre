using System;
using Npgsql;
using MercadoLivre.Dominio;
using System.Collections.Generic;

namespace MercadoLivre.Data
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private MercadoLivreDbContext _DbContext;

        public CategoriaRepositorio(MercadoLivreDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public Guid Adicionar(Subcategoria subcategoria)
        {
            string insert = @"insert into subcategoria
                            (
	                            id,
	                            nome,
	                            categoria_id
                            )
                            values
                            (
	                            @id, 
	                            @nome,
	                            @categoria_id
                            )";

            using (var command = new NpgsqlCommand())
            {
                command.CommandText = insert;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@id", subcategoria.Id));
                command.Parameters.Add(new NpgsqlParameter("@nome", subcategoria.Nome));
                command.Parameters.Add(new NpgsqlParameter("@categoria_id", subcategoria.CategoriaId));
                command.ExecuteNonQuery();
            }

            return subcategoria.Id;
        }

        public Categoria? ObterCategoriaPorId(Guid id)
        {
            Categoria? categoria = null;

            string select = @"select 
	                            id,
	                            nome,
	                            descricao
                            from 
	                            categoria where id = @id";

            using (var command = new NpgsqlCommand())
            {
                command.CommandText = select;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@id", id.ToString()));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var cat = Categoria.Restaurar(Guid.Parse(reader["id"].ToString()), reader["nome"].ToString(), reader["descricao"].ToString());
                    categoria = cat;
                }
                reader.Close();
            }
            return categoria;
        }

        public Categoria? ObterCategoriaPorNome(string nome)
        {
            Categoria? categoria = null;

            string select = @"select 
	                            id,
	                            nome,
	                            descricao
                            from 
	                            categoria where nome = @nome";

            using (var command = new NpgsqlCommand())
            {
                command.CommandText = select;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@nome", nome));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var cat = Categoria.Restaurar(Guid.Parse(reader["id"].ToString()), reader["nome"].ToString(), reader["descricao"].ToString());
                    categoria = cat;
                }
                reader.Close();
            }
            return categoria;
        }

        public Guid Salvar(Categoria categoria)
        {
            string insert = @"insert into categoria
                            (
	                            id,
	                            nome,
	                            descricao
                            )
                            values
                            (
	                            @id, 
	                            @nome,
	                            @descricao
                            )";

            using (var command = new NpgsqlCommand())
            {
                command.CommandText = insert;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@id", categoria.Id));
                command.Parameters.Add(new NpgsqlParameter("@nome", categoria.Nome));
                command.Parameters.Add(new NpgsqlParameter("@descricao", categoria.Descricao));
                command.ExecuteNonQuery();
            }

            return categoria.Id;
        }
    }
}
