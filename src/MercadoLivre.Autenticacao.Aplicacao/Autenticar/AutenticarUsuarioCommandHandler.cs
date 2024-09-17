using System;
using MercadoLivre.Autenticacao.Dominio;
using MercadoLivre.Dominio;

namespace MercadoLivre.Autenticacao.Aplicacao.Autenticar
{
    public class AutenticarUsuarioCommandHandler
    {
        private TokenService tokenService;

        private IUsuarioRepositorio _usuarioRepositorio;

        public AutenticarUsuarioCommandHandler(IUsuarioRepositorio usuarioRepositorio, TokenService tokenService)
        {
            _usuarioRepositorio = usuarioRepositorio;
            this.tokenService = tokenService;
        }

        public CommandResult Handle(AutenticarUsuarioCommand command)
        {
            command.Validar();

            if (!command.EhValido)
                return new CommandResult(string.Join(",", command.Erros), false);

            var usuario = _usuarioRepositorio.ObterUsuarioPorEmail(command.Email);

            if (usuario == null)
                return new CommandResult("usuário não encontrado!", false);

            var senha = new Senha(command.Senha);

            if (senha.Valor != usuario.Senha)
                return new CommandResult("usuário/e ou senha inválidos!", false);

            tokenService.Generate(usuario);


            return new CommandResult("usuário autenticado com sucesso!", true);
        }
    }
}