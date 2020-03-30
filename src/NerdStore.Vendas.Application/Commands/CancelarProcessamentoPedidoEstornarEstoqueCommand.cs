using System;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Commands
{
    public class CancelarProcessamentoPedidoEstornarEstoqueCommand : Command
    {
        public CancelarProcessamentoPedidoEstornarEstoqueCommand(Guid pedidoId, Guid clienteId)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }

        public Guid PedidoId { get; private set; }

        public Guid ClienteId { get; private set; }
    }
}