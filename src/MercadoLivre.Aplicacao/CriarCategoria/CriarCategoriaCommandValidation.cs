using System;
using FluentValidation;

namespace MercadoLivre.Aplicacao.CriarCategoria
{
    public class CriarCategoriaCommandValidation : AbstractValidator<CriarCategoriaCommand>
    {
        public CriarCategoriaCommandValidation()
        {
            RuleFor(x => x.Nome)
               .NotEmpty()
               .WithMessage("O nome é obrigatório!");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("A descriação é obrigatória!");
        }
    }
}
