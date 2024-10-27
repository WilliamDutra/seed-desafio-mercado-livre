using System;
using MercadoLivre.Dominio;

namespace MercadoLivre.Aplicacao.AdicionarImagemAoProduto
{
    public class AdicionarImagemAoProdutoCommand : Command
    {
        public Guid ProdutoId { get; set; }

        public IReadOnlyCollection<Arquivo> Arquivos => _Arquivos;

        private List<Arquivo> _Arquivos = new List<Arquivo>();

        public override void Validar()
        {
            var validator = new AdicionarImagemAoProdutoCommandValidation();
            var validate = validator.Validate(this);
            EhValido = validate.IsValid;
            foreach (var erro in validate.Errors)
            {
                AdicionaErro(erro.ErrorMessage);
            }
        }

        public void AdicionarArquivo(Stream file, string name, string type)
        {
            _Arquivos.Add(new Arquivo(file, name, type));
        }
    }

    public class Arquivo
    {
        public Stream File { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public Arquivo(Stream file, string name, string type)
        {
            File = file;
            Name = name;
            Type = type;
        }
    }
}
