using System;
using MediatR;
using System.Threading.Tasks;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Bus
{
    public class MediatrHandler : IMediatrHandler
    {
        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }
}