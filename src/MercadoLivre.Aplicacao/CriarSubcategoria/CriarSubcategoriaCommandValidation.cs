using System;
using FluentValidation;

namespace MercadoLivre.Aplicacao.CriarSubcategoria
{
    public class CriarSubcategoriaCommandValidation : AbstractValidator<CriarSubcategoriaCommand>
    {
        public CriarSubcategoriaCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório!");

            RuleFor(x => x.CategoriaId)
                .NotEmpty()
                .WithMessage("A categoria mãe é obrigatória!");

        }
    }
}
