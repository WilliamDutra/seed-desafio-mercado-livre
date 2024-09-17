using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Autenticacao.Aplicacao.Autenticar
{
    public class AutenticarUsuarioCommand : Command
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public override void Validar()
        {
            var validacao = new AutenticarUsuarioCommandValidation();
            var valido = validacao.Validate(this);
            EhValido = valido.IsValid;

            foreach (var erro in valido.Errors)
            {
                AdicionaErro(erro.ErrorMessage);
            }

        }
    }
}
