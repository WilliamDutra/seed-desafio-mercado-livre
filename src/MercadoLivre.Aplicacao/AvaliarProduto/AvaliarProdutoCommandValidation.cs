using System;
using FluentValidation;

namespace MercadoLivre.Aplicacao.AvaliarProduto
{
    public class AvaliarProdutoCommandValidation : AbstractValidator<AvaliarProdutoCommand>
    {
        public AvaliarProdutoCommandValidation()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("o produto é obrigatório!");

            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("o usuário é obrigatório!");

            RuleFor(x => x.Titulo)
                .NotEmpty()
                .WithMessage("o titulo é obrigatório!");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("o descrição é obrigatório!");

            RuleFor(x => x.Nota)
                .Must((nota) => nota >= 0 && nota <= 5)
                .WithMessage("A nota precisa ser de 0 até 5");

        }
    }
}
