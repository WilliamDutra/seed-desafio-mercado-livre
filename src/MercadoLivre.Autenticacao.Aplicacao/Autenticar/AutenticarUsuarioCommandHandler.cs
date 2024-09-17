using System;
using MercadoLivre.Autenticacao.Dominio;
using MercadoLivre.Dominio;

namespace MercadoLivre.Autenticacao.Aplicacao.Autenticar
{
    public class AutenticarUsuarioCommandHandler
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public AutenticarUsuarioCommandHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public CommandResult Handle(AutenticarUsuarioCommand command)
        {
            command.Validar();

            if (!command.EhValido)
                return new CommandResult(string.Join(",", command.Erros), false);

            var email = _usuarioRepositorio.ObterUsuarioPorEmail(command.Email);

            if (email == null)
                return new CommandResult("usuário não encontrado!", false);

            var senha = new Senha(command.Senha);
            

            return new CommandResult("usuário autenticado com sucesso!", true);
        }
    }
}