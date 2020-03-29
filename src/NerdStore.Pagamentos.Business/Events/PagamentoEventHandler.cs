using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NerdStore.Core.DomainObjects.DTO;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;

namespace NerdStore.Pagamentos.Business.Events
{
    public class PagamentoEventHandler : INotificationHandler<PedidoEstoqueConfirmadoEvent>
    {
        public PagamentoEventHandler(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        private readonly IPagamentoService _pagamentoService;

        public async Task Handle(PedidoEstoqueConfirmadoEvent notification, CancellationToken cancellationToken)
        {
            var pagamentoPedido = new PagamentoPedido
            {
                PedidoId = notification.PedidoId,
                ClienteId = notification.ClienteId,
                Total = notification.Total,
                NomeCartao = notification.NomeCartao,
                NumeroCartao = notification.NumeroCartao,
                ExpiracaoCartao = notification.ExpiracaoCartao,
                CvvCartao = notification.CvvCartao
            };

            await _pagamentoService.RealizarPagamentoPedido(pagamentoPedido);
        }
    }
}