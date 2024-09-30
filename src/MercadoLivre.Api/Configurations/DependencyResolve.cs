using MercadoLivre.Dominio;
using MercadoLivre.Autenticacao.Data;
using MercadoLivre.Autenticacao.Dominio;
using MercadoLivre.Autenticacao.Aplicacao;
using MercadoLivre.Aplicacao.CriarCategoria;
using MercadoLivre.Aplicacao.CadastrarProduto;
using MercadoLivre.Aplicacao.CriarSubcategoria;
using MercadoLivre.Autenticacao.Aplicacao.Usuario;
using MercadoLivre.Autenticacao.Aplicacao.Autenticar;

namespace MercadoLivre.Api.Configurations
{
    public static class DependencyResolve
    {
        public static IServiceCollection AddRepositorios(this IServiceCollection services)
        {
            services.AddScoped<MercadoLivreDbContext>((conn) => new MercadoLivreDbContext("Server=localhost;Port=5432;User Id=postgres;Password=root;Database=mercadolivre;"));
            services.AddScoped<MercadoLivre.Data.MercadoLivreDbContext>((conn) => new MercadoLivre.Data.MercadoLivreDbContext("Server=localhost;Port=5432;User Id=postgres;Password=root;Database=mercadolivre;"));
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<ICategoriaRepositorio, Data.CategoriaRepositorio>();
            services.AddScoped<IProdutoRepositorio, Data.ProdutoRepositorio>();
            services.AddScoped<TokenService>();
            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<CadastrarUsuarioCommandHandler>();
            services.AddScoped<AutenticarUsuarioCommandHandler>();
            services.AddScoped<CriarCategoriaCommandHandler>();
            services.AddScoped<CriarSubcategoriaCommandHandler>();
            services.AddScoped<CadastrarProdutoCommandHandler>();
            return services;
        }
    }
}
