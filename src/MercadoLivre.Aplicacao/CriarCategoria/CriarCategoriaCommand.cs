using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Aplicacao.CriarCategoria
{
    public class CriarCategoriaCommand : Command
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public override void Validar()
        {
            var validate = new CriarCategoriaCommandValidation();
            var validation = validate.Validate(this);
            EhValido = validation.IsValid;

            foreach (var erro in validation.Errors)
            {
                AdicionaErro(erro.ErrorMessage);
            }
        }
    }
}
