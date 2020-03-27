using System;
using NerdStore.Core.DomainObjects.DTO;

namespace NerdStore.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PedidoEstoqueConfirmadoEvent : IntegrationEvent
    {
        public PedidoEstoqueConfirmadoEvent(Guid pedidoId, Guid clienteId, ListaProdutosPedido itens, decimal total, string nomeCartao, string numeroCartao, string expiracaoCartao, string cvvCartao)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
            ListaProdutosPedido = itens;
            Total = total;
            NomeCartao = nomeCartao;
            NumeroCartao = numeroCartao;
            ExpiracaoCartao = expiracaoCartao;
            CvvCartao = cvvCartao;
        }

        public Guid PedidoId { get; private set; }

        public Guid ClienteId { get; private set; }

        public ListaProdutosPedido ListaProdutosPedido { get; private set; }

        public decimal Total { get; private set; }

        public string NomeCartao { get; private set; }

        public string NumeroCartao { get; private set; }

        public string ExpiracaoCartao { get; private set; }

        public string CvvCartao { get; private set; }
    }
}