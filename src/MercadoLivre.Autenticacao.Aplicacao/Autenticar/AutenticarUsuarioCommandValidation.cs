using System;
using FluentValidation;

namespace MercadoLivre.Autenticacao.Aplicacao.Autenticar
{
    public class AutenticarUsuarioCommandValidation : AbstractValidator<AutenticarUsuarioCommand>
    {
        public AutenticarUsuarioCommandValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório!");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("A senha é obrigatória!");
        }
    }
}
