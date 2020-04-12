using System;
using System.Threading.Tasks;
using NerdStore.Core.Messages;
using System.Collections.Generic;

namespace NerdStore.Core.Data.EventSourcing
{
    public interface IEventSourcingRepository
    {
        Task SalvarEvento<TEvent>(TEvent evento) where TEvent : Event;

        Task<IEnumerable<StoredEvent>> ObterEventos(Guid aggregateId);
    }
}