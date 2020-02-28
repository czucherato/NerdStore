using NerdStore.Core.Bus;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Data.Repository;
using NerdStore.Catalogo.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace NerdStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatrHandler, MediatrHandler>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IMediatrHandler, MediatrHandler>();
        }
    }
}