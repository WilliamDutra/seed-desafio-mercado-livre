using MercadoLivre.Dominio;
using System;

namespace MercadoLivre.Aplicacao.PerguntarSobreProduto
{
    public class PerguntarSobreOProdutoCommand : Command
    {
        public Guid ProdutoId { get; set; }

        public Guid UsuarioId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public override void Validar()
        {
            var validation = new PerguntarSobreOProdutoCommandValidation();
            var validator = validation.Validate(this);
            EhValido = validator.IsValid;
            foreach (var erro in validator.Errors)
            {
                AdicionaErro(erro.ErrorMessage);
            }
        }
    }
}
