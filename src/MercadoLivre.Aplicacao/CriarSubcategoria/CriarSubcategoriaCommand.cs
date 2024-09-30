using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Aplicacao.CriarSubcategoria
{
    public class CriarSubcategoriaCommand : Command
    {
        public string Nome { get; set; }

        public Guid CategoriaId { get; set; }

        public override void Validar()
        {
            var validation = new CriarSubcategoriaCommandValidation();
            var validate = validation.Validate(this);
            EhValido = validate.IsValid;
            foreach (var erro in validate.Errors)
            {
                AdicionaErro(erro.ErrorMessage);
            }
        }
    }
}
