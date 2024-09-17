using System;

namespace MercadoLivre.Autenticacao.Dominio
{
    public class UsuarioLogin
    {
        public Guid Id { get; private set; }

        public string Login { get; private set; }

        public string Senha { get; private set; }

        public DateTime LogadoEm { get; set; }

        private UsuarioLogin(Guid id, string login, Senha senha, DateTime logadoEm)
        {
            Id = id;
            Login = login;
            Senha = senha.Valor;
            LogadoEm = logadoEm;
        }

        public static UsuarioLogin Criar(string login, Senha senha)
        {
            return new UsuarioLogin(Guid.NewGuid(), login, senha, DateTime.Now);
        }

        public static UsuarioLogin Restaurar(Guid id, string login, string hasPass,  DateTime logadoEm)
        {
            return new UsuarioLogin(id, login, new Senha(hasPass), logadoEm);
        }
    }
}
