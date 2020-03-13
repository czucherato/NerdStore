using MediatR;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Events;
using NerdStore.Catalogo.Data.Repository;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Catalogo.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace NerdStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatrHandler>();

            // Catálogo
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            
            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

            // Vendas
            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
        }
    }
}