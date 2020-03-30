using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoEventHandler :
        INotificationHandler<PedidoAtualizadoEvent>,
        INotificationHandler<PedidoItemAdicionadoEvent>,
        INotificationHandler<PedidoRascunhoIniciadoEvent>,
        INotificationHandler<PedidoEstoqueRejeitadoEvent>,
        INotificationHandler<PagamentoRealizadoEvent>,
        INotificationHandler<PagamentoRecusadoEvent>
    {

        public PedidoEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        private readonly IMediatorHandler _mediatorHandler;

        public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoItemAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task Handle(PedidoEstoqueRejeitadoEvent notification, CancellationToken cancellationToken)
        {
            await _mediatorHandler.EnviarComando(new CancelarProcessamentoPedidoCommand(notification.PedidoId, notification.ClienteId));
        }

        public async Task Handle(PagamentoRealizadoEvent notification, CancellationToken cancellationToken)
        {
            await _mediatorHandler.EnviarComando(new FinalizarPedidoCommand(notification.PedidoId, notification.ClienteId));
        }

        public async Task Handle(PagamentoRecusadoEvent notification, CancellationToken cancellationToken)
        {
            await _mediatorHandler.EnviarComando(new CancelarProcessamentoPedidoEstornarEstoqueCommand(notification.PedidoId, notification.ClienteId));
        }
    }
}