using MediatR;
using System.Threading.Tasks;
using NerdStore.Core.Messages;
using NerdStore.Core.Data.EventSourcing;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.Core.Communication.Mediator
{
    public class MediatrHandler : IMediatorHandler
    {
        public MediatrHandler(
            IMediator mediator,
            IEventSourcingRepository eventSourcingRepository)
        {
            _mediator = mediator;
            _eventSourcingRepository = eventSourcingRepository;
        }

        private readonly IMediator _mediator;
        private readonly IEventSourcingRepository _eventSourcingRepository;

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);

            if (!evento.GetType().BaseType.Name.Equals("DomainEvent"))
                await _eventSourcingRepository.SalvarEvento(evento);
        }

        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task PublicarNotificacoes<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }
    }
}