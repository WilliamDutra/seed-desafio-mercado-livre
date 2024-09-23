using System;
using MercadoLivre.Dominio;
using MercadoLivre.Autenticacao.Dominio;

namespace MercadoLivre.Autenticacao.Aplicacao.Usuario
{
    public class CadastrarUsuarioCommandHandler
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public CadastrarUsuarioCommandHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public CommandResult Handle(CadastrarUsuarioCommand command)
        {
            command.Validar();

            if (!command.EhValido)
                return new CommandResult(string.Join(",", command.Erros), false);

            var usuarioExistente = _usuarioRepositorio.ObterUsuarioPorEmail(command.Email);

            if (usuarioExistente == null)
                return new CommandResult("Esse e-mail já existe no sistema!", false);

            var usuario = UsuarioLogin.Criar(command.Email, new Senha(command.Senha));
            _usuarioRepositorio.Inserir(usuario);

            return new CommandResult("usuário cadastrado com sucesso!", true);
        }
    }
}
