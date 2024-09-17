using MercadoLivre.Autenticacao.Data;
using MercadoLivre.Autenticacao.Dominio;
using MercadoLivre.Autenticacao.Aplicacao.Usuario;
using MercadoLivre.Autenticacao.Aplicacao.Autenticar;

namespace MercadoLivre.Api.Configurations
{
    public static class DependencyResolve
    {
        public static IServiceCollection AddRepositorios(this IServiceCollection services)
        {
            services.AddScoped<MercadoLivreDbContext>((conn) => new MercadoLivreDbContext("Server=localhost;Port=5432;User Id=postgres;Password=root;Database=mercadolivre;"));
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<CadastrarUsuarioCommandHandler>();
            services.AddScoped<AutenticarUsuarioCommandHandler>();
            return services;
        }
    }
}
