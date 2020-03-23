using System;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoItemAdicionadoEvent : Event
    {
        public PedidoItemAdicionadoEvent(Guid clienteId, Guid produtoId, string produtoNome, Guid pedidoId, decimal valorUnitario, int quantidade)
        {
            AggregateId = pedidoId;
            ClienteId = clienteId;
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            PedidoId = pedidoId;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
        }

        public Guid ClienteId { get; private set; }

        public Guid ProdutoId { get; private set; }

        public string ProdutoNome { get; private set; }

        public Guid PedidoId { get; private set; }

        public decimal ValorUnitario { get; private set; }

        public int Quantidade { get; private set; }
    }
}
