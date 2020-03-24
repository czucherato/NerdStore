using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NerdStore.Core.Messages;
using NerdStore.Vendas.Domain;
using NerdStore.Core.Extensions;
using NerdStore.Vendas.Application.Events;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.Vendas.Application.Commands
{
    public class PedidoCommandHandler :
        IRequestHandler<RemoverItemPedidoCommand, bool>,
        IRequestHandler<AdicionarItemPedidoCommand, bool>,
        IRequestHandler<AtualizarItemPedidoCommand, bool>,
        IRequestHandler<AplicarVoucherPedidoCommand, bool>
    {
        public PedidoCommandHandler(
            IMediatorHandler mediatorHandler,
            IPedidoRepository pedidoRepository)
        {
            _mediatorHandler = mediatorHandler;
            _pedidoRepository = pedidoRepository;
        }

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPedidoRepository _pedidoRepository;

        public async Task<bool> Handle(AdicionarItemPedidoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;
            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(request.ClienteId);
            var pedidoItem = new PedidoItem(request.ProdutoId, request.Nome, request.Quantidade, request.ValorUnitario);

            if (pedido is null)
            {
                pedido = Pedido.PedidoFactory.NovoPedidoRascunho(request.ClienteId);
                pedido.AdicionarItem(pedidoItem);
                _pedidoRepository.Adicionar(pedido);
                pedido.AdicionarEvento(new PedidoRascunhoIniciadoEvent(request.ClienteId, pedido.Id));
            }
            else
            {
                var pedidoItemExistente = pedido.PedidoItemExistente(pedidoItem);
                pedido.AdicionarItem(pedidoItem);

                if (pedidoItemExistente)
                {
                    _pedidoRepository.AtualizarItem(pedido.PedidoItens.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId));
                }
                else
                {
                    _pedidoRepository.AdicionarItem(pedidoItem);
                }

                pedido.AdicionarEvento(new PedidoAtualizadoEvent(pedido.ClienteId, pedido.Id, pedido.ValorTotal));
            }

            pedido.AdicionarEvento(new PedidoItemAdicionadoEvent(pedido.ClienteId, request.ProdutoId, request.Nome, pedido.Id, request.ValorUnitario, request.Quantidade));
            await _mediatorHandler.PublicarEventos(pedido);
            return await _pedidoRepository.UnitOfWork.Commit();
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacoes(new DomainNotification(message.MessageType, error.ErrorMessage));
            }

            return false;
        }

        public async Task<bool> Handle(AplicarVoucherPedidoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Handle(AtualizarItemPedidoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(request.ClienteId);

            if (pedido is null)
            {
                await _mediatorHandler.PublicarNotificacoes(new DomainNotification("pedido", "Pedido não encontrado"));
                return false;
            }

            var pedidoItem = await _pedidoRepository.ObterItemPorPedido(pedido.Id, request.ProdutoId);

            if (!pedido.PedidoItemExistente(pedidoItem))
            {
                await _mediatorHandler.PublicarNotificacoes(new DomainNotification("pedido", "Item do pedido não econtrado"));
                return false;
            }

            pedido.AtualizarUnidades(pedidoItem, request.Quantidade);
            pedido.AdicionarEvento(new PedidoAtualizadoEvent(pedido.ClienteId, pedido.Id, pedido.ValorTotal));
            _pedidoRepository.AtualizarItem(pedidoItem);
            _pedidoRepository.Atualizar(pedido);

            return await _pedidoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(RemoverItemPedidoCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(true);
        }
    }
}