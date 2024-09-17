using System;

namespace MercadoLivre.Autenticacao.Dominio
{
    public interface IUsuarioRepositorio
    {
        bool Autenticar(string email, string hashSenha);

        UsuarioLogin? ObterUsuarioPorEmail(string email);

        void Inserir(UsuarioLogin login);
    }
}
