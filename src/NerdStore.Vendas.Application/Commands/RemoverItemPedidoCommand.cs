using System;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Commands
{
    public class RemoverItemPedidoCommand : Command
    {
        public RemoverItemPedidoCommand(Guid clienteId, Guid pedidoId, Guid produtoId)
        {
            ClienteId = clienteId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
        }

        public Guid ClienteId { get; private set; }

        public Guid PedidoId { get; private set; }

        public Guid ProdutoId { get; private set; }

        public override bool EhValido()
        {
            return base.EhValido();
        }
    }
}
