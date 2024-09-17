using Npgsql;
using System.Data;
using MercadoLivre.Autenticacao.Dominio;

namespace MercadoLivre.Autenticacao.Data
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private MercadoLivreDbContext _dbContext;

        public UsuarioRepositorio(MercadoLivreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Autenticar(string email, string hashSenha)
        {
            throw new NotImplementedException();
        }

        public void Inserir(UsuarioLogin login)
        {
            string insert = @"insert into usuario_autenticacao 
                            ( 
	                            id, 
	                            email, 
	                            hash_senha, 
	                            logado_em 
                            ) 
                            values 
                            ( 
	                            @id, 
	                            @email, 
	                            @hash_senha, 
	                            @logado_em 
                            )";

            NpgsqlCommand comando = new NpgsqlCommand();
            comando.CommandText = insert; ;
            comando.CommandType = CommandType.Text;
            comando.Connection = _dbContext.Conexao;
            comando.Parameters.Add(new NpgsqlParameter("@id", login.Id));
            comando.Parameters.Add(new NpgsqlParameter("@email", login.Login));
            comando.Parameters.Add(new NpgsqlParameter("@hash_senha", login.Senha));
            comando.Parameters.Add(new NpgsqlParameter("@logado_em", login.LogadoEm));
            comando.ExecuteNonQuery();
        }

        public UsuarioLogin? ObterUsuarioPorEmail(string email)
        {
            UsuarioLogin usuario = null;

            string select = @"select
	                                id,
	                                email,
	                                hash_senha,
	                                logado_em
                                from
	                                usuario_autenticacao where email = @email";

            NpgsqlCommand comando = new NpgsqlCommand();
            comando.CommandText = select;
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add(new NpgsqlParameter("@email", email));
            comando.Connection = _dbContext.Conexao;

            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    usuario = UsuarioLogin.Restaurar(Guid.Parse(reader["id"].ToString()), reader["email"].ToString(), reader["hash_senha"].ToString(), DateTime.Parse(reader["logado_em"].ToString()));
                }
            }

            return usuario;
        }
    }
}