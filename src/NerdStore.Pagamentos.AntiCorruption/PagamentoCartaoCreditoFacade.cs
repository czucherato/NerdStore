﻿using NerdStore.Pagamentos.Business;

namespace NerdStore.Pagamentos.AntiCorruption
{
    public class PagamentoCartaoCreditoFacade : IPagamentoCartaoCreditoFacade
    {
        public PagamentoCartaoCreditoFacade(
            IPayPalGateway payPalGateway,
            IConfigurationManager configurationManager)
        {
            _payPalGateway = payPalGateway;
            _configurationManager = configurationManager;
        }

        private readonly IPayPalGateway _payPalGateway;
        private readonly IConfigurationManager _configurationManager;

        public Transacao RealizarPagamento(Pedido pedido, Pagamento pagamento)
        {
            var apiKey = _configurationManager.GetValue("apiKey");
            var encriptionKey = _configurationManager.GetValue("encriptionKey");

            var serviceKey = _payPalGateway.GetPayPalServiceKey(apiKey, encriptionKey);
            var cardeHashKey = _payPalGateway.GetCardHashKey(serviceKey, pagamento.NumeroCartao);

            var pagamentoResult = _payPalGateway.CommitTransaction(cardeHashKey, pedido.Id.ToString(), pagamento.Valor);

            // TODO: O gateway  de pagamentos que deve retornar o objeto transação
            var transacao = new Transacao
            {
                PedidoId = pedido.Id,
                Total = pedido.Valor,
                PagamentoId = pagamento.Id
            };

            if (pagamentoResult)
            {
                transacao.StatusTransacao = StatusTransacao.Pago;
                return transacao;
            }

            transacao.StatusTransacao = StatusTransacao.Recusado;
            return transacao;
        }
    }
}
