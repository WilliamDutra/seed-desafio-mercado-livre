using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Aplicacao.AvaliarProduto
{
    public class AvaliarProdutoCommand : Command
    {
        public Guid ProdutoId { get; set; }

        public Guid UsuarioId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public int Nota { get; set; }

        public override void Validar()
        {
            var validator = new AvaliarProdutoCommandValidation();
            var validate = validator.Validate(this);
            EhValido = validate.IsValid;
            foreach (var erro in validate.Errors) 
            {
                AdicionaErro(erro.ErrorMessage);
            }
        }
    }
}
