using Npgsql;

namespace MercadoLivre.Data
{
    public class MercadoLivreDbContext
    {
        public NpgsqlConnection Conexao;

        public MercadoLivreDbContext(string connectionStrings)
        {
            Conexao = new NpgsqlConnection(connectionStrings);
            Conexao.Open();
        }

    }
}
