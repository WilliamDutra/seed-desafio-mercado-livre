using System;
using FluentValidation;

namespace MercadoLivre.Autenticacao.Aplicacao.Usuario
{
    public class CadastrarUsuarioCommandValidation : AbstractValidator<CadastrarUsuarioCommand>
    {
        public CadastrarUsuarioCommandValidation()
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
