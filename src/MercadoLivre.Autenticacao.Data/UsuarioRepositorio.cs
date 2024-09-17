using MercadoLivre.Autenticacao.Dominio;

namespace MercadoLivre.Autenticacao.Data
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public bool Autenticar(string email, string hashSenha)
        {
            throw new NotImplementedException();
        }

        public UsuarioLogin? ObterUsuarioPorEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}