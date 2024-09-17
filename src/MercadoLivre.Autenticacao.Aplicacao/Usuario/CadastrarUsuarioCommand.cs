using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Autenticacao.Aplicacao.Usuario
{
    public class CadastrarUsuarioCommand : Command
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public override void Validar()
        {
            var validacao = new CadastrarUsuarioCommandValidation();
            var valido = validacao.Validate(this);
            EhValido = valido.IsValid;
            foreach (var erro in valido.Errors)
            {
                AdicionaErro(erro.ErrorMessage);
            }
        }
    }
}
