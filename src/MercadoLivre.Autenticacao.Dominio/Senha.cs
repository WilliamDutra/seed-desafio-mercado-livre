using System;
using BCrypt.Net;
using static BCrypt.Net.BCrypt;


namespace MercadoLivre.Autenticacao.Dominio
{
    public class Senha
    {
        public string Valor { get; private set; }

        public string Hash { get; set; }

        public Senha(string valor)
        {
            Valor = valor;
        }


    }
}
