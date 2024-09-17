using System;

namespace MercadoLivre.Dominio
{
    public abstract class Command
    {
        public List<string> Erros { get; protected set; } = new List<string>();

        public bool EhValido { get; protected set; }

        public abstract void Validar();

        protected void AdicionaErro(string erro)
        {
            Erros.Add(erro);
        }

    }
}
