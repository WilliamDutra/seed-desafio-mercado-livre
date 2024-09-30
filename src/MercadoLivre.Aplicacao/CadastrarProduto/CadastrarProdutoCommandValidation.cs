using System;
using FluentValidation;

namespace MercadoLivre.Aplicacao.CadastrarProduto
{
    public class CadastrarProdutoCommandValidation : AbstractValidator<CadastrarProdutoCommand>
    {
        public CadastrarProdutoCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório!");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("A descrição é obrgatória!");

            RuleFor(x => x.Valor)
                .NotEmpty()
                .WithMessage("O valor é obrgatótio!")
                .GreaterThan(1)
                .WithMessage("O valor precisa ser maior que 1 real");

            RuleFor(x => x.CategoriaId)
                .NotEmpty()
                .WithMessage("A categoria do produto é obrigatório!");

            RuleFor(x => x.Quantidade)
                .GreaterThan(5)
                .WithMessage("A quantidade do produto não pode ser menor que 5");

            
        }
    }
}
