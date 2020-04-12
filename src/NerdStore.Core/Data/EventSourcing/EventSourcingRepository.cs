using System;
using System.Text;
using EventSourcing;
using Newtonsoft.Json;
using EventStore.ClientAPI;
using System.Threading.Tasks;
using NerdStore.Core.Messages;
using System.Collections.Generic;

namespace NerdStore.Core.Data.EventSourcing
{
    public class EventSourcingRepository : IEventSourcingRepository
    {
        public EventSourcingRepository(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }

        private readonly IEventStoreService _eventStoreService;

        public async Task<IEnumerable<StoredEvent>> ObterEventos(Guid aggregateId)
        {
            var eventos = await _eventStoreService.GetConnection().ReadStreamEventsBackwardAsync(aggregateId.ToString(), 0, 500, false);

            var listaEventos = new List<StoredEvent>();

            foreach (var resolvedEvent in eventos.Events)
            {
                var dataEncoded = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
                var jsonData = JsonConvert.DeserializeObject<Event>(dataEncoded);
                var evento = new StoredEvent(resolvedEvent.Event.EventId, resolvedEvent.Event.EventType, jsonData.Timestamp, dataEncoded);
                listaEventos.Add(evento);
            }

            return listaEventos;
        }

        public async Task SalvarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            await _eventStoreService.GetConnection().AppendToStreamAsync(
                evento.AggregateId.ToString(),
                ExpectedVersion.Any,
                FormatarEvento(evento));
        }

        private static IEnumerable<EventData> FormatarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            yield return new EventData(
                Guid.NewGuid(),
                evento.MessageType,
                true,
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(evento)),
                null);
        }
    }
}