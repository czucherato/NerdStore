using System;
using NerdStore.Core.DomainObjects.DTO;

namespace NerdStore.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PedidoProcessamentoCanceladoEvent : IntegrationEvent
    {
        public PedidoProcessamentoCanceladoEvent(Guid pedidoId, Guid clienteId, ListaProdutosPedido produtosPedido)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
            ListaProdutosPedido = produtosPedido;
        }

        public Guid PedidoId { get; private set; }

        public Guid ClienteId { get; private set; }

        public ListaProdutosPedido ListaProdutosPedido { get; set; }
    }
}