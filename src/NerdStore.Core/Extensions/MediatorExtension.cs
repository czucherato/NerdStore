using NerdStore.Core.Communication.Mediator;
using System.Linq;
using System.Threading.Tasks;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Core.Extensions
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventos<T>(this IMediatorHandler mediatorHandler, T entity) where T : Entity
        {
            var tasks = entity.Notificacoes.Select(async (domainEvent) =>
            {
                await mediatorHandler.PublicarEvento(domainEvent);
            });

            await Task.WhenAll(tasks);
        }
    }
}