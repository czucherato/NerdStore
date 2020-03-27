using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : 
        INotificationHandler<ProdutoAbaixoEstoqueEvent>,
        INotificationHandler<PedidoIniciadoEvent>
    {
        public ProdutoEventHandler(
            IEstoqueService estoqueService,
            IMediatorHandler mediatorHandler,
            IProdutoRepository produtoRepository)
        {
            _estoqueService = estoqueService;
            _mediatorHandler = mediatorHandler;
            _produtoRepository = produtoRepository;
        }

        private readonly IEstoqueService _estoqueService;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProdutoRepository _produtoRepository;

        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            //var produto = await _produtoRepository.ObterProdutoPorId(mensagem.AggregateId);
            // Enviar e-mail para aquisição de mais produtos;
        }

        public async Task Handle(PedidoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            var result = await _estoqueService.DebitarListaProdutosPedido(notification.ListaProdutosPedido);

            if (result)
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(notification.PedidoId, notification.ClienteId, notification.ListaProdutosPedido, notification.Total, notification.NomeCartao, notification.NumeroCartao, notification.ExpiracaoCartao, notification.CvvCartao));
            }
            else
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(notification.PedidoId, notification.ClienteId));
            }
        }
    }
}