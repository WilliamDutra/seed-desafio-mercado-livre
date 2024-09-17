using System;

namespace MercadoLivre.Autenticacao.Dominio
{
    public class UsuarioLogin
    {
        public string Login { get; private set; }

        public string Senha { get; private set; }

        public DateTime LogadoEm { get; set; }

        private UsuarioLogin(string login, Senha senha, DateTime logadoEm)
        {
            Login = login;
            Senha = senha.Valor;
            LogadoEm = logadoEm;
        }

        public static UsuarioLogin Criar(string login, Senha senha)
        {
            return new UsuarioLogin(login, senha, DateTime.Now);
        }

        public static UsuarioLogin Restaurar(string login, string hasPass,  DateTime logadoEm)
        {
            return new UsuarioLogin(login, new Senha(hasPass), logadoEm);
        }
    }
}
