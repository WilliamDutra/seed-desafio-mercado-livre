using System;

namespace MercadoLivre.Dominio
{
    public class CommandResult
    {
        public string Mensagem { get; private set; }

        public bool Sucesso { get; private set; }

        public object Data { get; private set; }

        public CommandResult(string mensagem, bool sucesso)
        {
            Mensagem = mensagem;
            Sucesso = sucesso;
        }

        public CommandResult(string mensagem, bool sucesso, object data)
        {
            Mensagem = mensagem;
            Sucesso = sucesso;
            Data = data;
        }
    }
}
