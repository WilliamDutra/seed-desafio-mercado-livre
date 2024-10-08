﻿using System;

namespace MercadoLivre.Dominio
{
    public class Produto
    {
        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public decimal Valor { get; private set; }

        public int Quantidade { get; private set; }

        public Guid CategoriaId { get; private set; }

        public DateTime CriadoEm { get; private set; }

        public Guid UsuarioId { get; private set; }

        private Produto(Guid id, string nome, string descricao, decimal valor, int quantidade, Guid categoriaId, Guid usuarioId, DateTime criadoEm)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Quantidade = quantidade;
            CategoriaId = categoriaId;
            UsuarioId = usuarioId;
            CriadoEm = criadoEm;
        }

        public static Produto Criar(string nome, string descricao, decimal valor, int quantidade, Guid usuarioId, Guid categoriaId)
        {
            return new Produto(Guid.NewGuid(), nome, descricao, valor, quantidade, categoriaId, usuarioId, DateTime.Now);
        }

        public static Produto Restaurar(Guid id, string nome, string descricao, decimal valor, int quantidade, Guid categoriaId, Guid usuarioId, DateTime criadoEm)
        {
            return new Produto(id, nome, descricao, valor, quantidade, categoriaId, usuarioId, criadoEm);
        }

    }
}
