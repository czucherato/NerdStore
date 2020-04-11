using EventStore.ClientAPI;
using Microsoft.Extensions.Configuration;
using System;

namespace EventSourcing
{
    public class EventStoreService : IEventStoreService
    {
        private readonly IEventStoreConnection _eventStoreConnection;

        public EventStoreService(IConfiguration configuration)
        {
            _eventStoreConnection = EventStoreConnection.Create(configuration.GetConnectionString("EventStoreConnection"));
            _eventStoreConnection.ConnectAsync();
        }

        public IEventStoreConnection GetConnection()
        {
            return _eventStoreConnection;
        }
    }
}