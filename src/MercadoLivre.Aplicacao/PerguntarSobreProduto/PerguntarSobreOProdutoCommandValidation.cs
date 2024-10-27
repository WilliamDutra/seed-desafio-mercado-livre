using System;
using FluentValidation;

namespace MercadoLivre.Aplicacao.PerguntarSobreProduto
{
    public class PerguntarSobreOProdutoCommandValidation : AbstractValidator<PerguntarSobreOProdutoCommand>
    {
        public PerguntarSobreOProdutoCommandValidation()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .WithMessage("O titulo é obrigatório!");


            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("A descrição é obrigatório!");

            RuleFor(x => x.ProdutoId)
                .NotEmpty()
                .WithMessage("O produto é obrigatório!");

            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("O usuário é obrigatório!");

        }
    }
}
