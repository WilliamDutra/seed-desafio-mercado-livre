using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Aplicacao.CadastrarProduto
{
    public class CadastrarProdutoCommand : Command
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public Guid CategoriaId { get; set; }

        public int Quantidade { get; set; }

        public Guid UsuarioId { get; set; }

        public override void Validar()
        {
            var validation = new CadastrarProdutoCommandValidation();
            var validate = validation.Validate(this);
            EhValido = validate.IsValid;
            foreach (var erro in validate.Errors)
            {
                AdicionaErro(erro.ErrorMessage);
            }
        }
    }
}
