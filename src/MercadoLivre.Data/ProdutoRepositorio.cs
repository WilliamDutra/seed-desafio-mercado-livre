﻿using System;
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

        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            string insert = @"insert into avaliacao
                            (
	                            produto_id,
	                            usuario_id,
	                            titulo,
	                            descricao,
	                            nota
                            )
                            values
                            (
	                            @produto,
	                            @usuario,
	                            @titulo,
	                            @descricao,
	                            @nota
                            );";

            using (var command = new NpgsqlCommand())
            {
                command.CommandText = insert;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@produto", avaliacao.ProdutoId));
                command.Parameters.Add(new NpgsqlParameter("@usuario", avaliacao.UsuarioId));
                command.Parameters.Add(new NpgsqlParameter("@titulo", avaliacao.Titulo));
                command.Parameters.Add(new NpgsqlParameter("@descricao", avaliacao.Descricao));
                command.Parameters.Add(new NpgsqlParameter("@nota", avaliacao.Nota));
                command.ExecuteNonQuery();
            }

        }

        public Guid AdicionarFoto(Foto foto)
        {
            string insert = @"insert into foto
                            (
	                            id,
	                            nome,
	                            tipo
                            )
                            values
                            (
	                            @id,
	                            @nome,
	                            @tipo
                            );";

            using (var command = new NpgsqlCommand())
            {
                command.CommandText = insert;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@id", foto.Id));
                command.Parameters.Add(new NpgsqlParameter("@nome", foto.Nome));
                command.Parameters.Add(new NpgsqlParameter("@tipo", foto.Tipo));
                command.ExecuteNonQuery();
            }

            return foto.Id;

        }

        public void AdicionarGaleria(Galeria galeria)
        {
            string insert = @"insert into galeria
                            (
	                            produto_id,
	                            foto_id
                            )
                            values
                            (
	                            @produto,
	                            @foto
                            );";

            foreach (var foto in galeria.Fotos)
            {

                var fotoId = AdicionarFoto(foto);

                using (var command = new NpgsqlCommand())
                {
                    command.CommandText = insert;
                    command.Connection = _DbContext.Conexao;
                    command.Parameters.Add(new NpgsqlParameter("@produto", galeria.ProdutoId));
                    command.Parameters.Add(new NpgsqlParameter("@foto", fotoId));
                    command.ExecuteNonQuery();
                }

            }

        }

        public void AdicionarPergunta(Pergunta pergunta)
        {
            string insert = @"insert into pergunta 
                            (
	                            produto_id,
	                            usuario_id,
	                            titulo,
	                            descricao,
	                            data_pergunta
                            )
                            values
                            (
	                            @produto,
	                            @usuario,
	                            @titulo,
	                            @descricao,
	                            @data
                            );";

            using (var command = new NpgsqlCommand())
            {
                command.CommandText = insert;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@produto", pergunta.ProdutoId));
                command.Parameters.Add(new NpgsqlParameter("@usuario", pergunta.UsuarioId));
                command.Parameters.Add(new NpgsqlParameter("@titulo", pergunta.Titulo));
                command.Parameters.Add(new NpgsqlParameter("@descricao", pergunta.Descricao));
                command.Parameters.Add(new NpgsqlParameter("@data", pergunta.Data));
                command.ExecuteNonQuery();
            }

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
