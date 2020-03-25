using System;
using NerdStore.Core.Messages;
using NerdStore.Vendas.Application.Validations;

namespace NerdStore.Vendas.Application.Commands
{
    public class IniciarPedidoCommand : Command
    {
        public IniciarPedidoCommand(Guid pedidoId, Guid clienteId, decimal valorTotal, string nomeCartao, string numeroCartao, string expiracaoCartao, string cvvCartao)
        {
            PedidoId = pedidoId;
            ClienteId = clienteId;
            ValorTotal = valorTotal;
            NomeCartao = nomeCartao;
            NumeroCartao = numeroCartao;
            ExpiracaoCartao = expiracaoCartao;
            CvvCartao = cvvCartao;
        }

        public Guid PedidoId { get; private set; }

        public Guid ClienteId { get; private set; }

        public decimal ValorTotal { get; private set; }

        public string NomeCartao { get; private set; }

        public string NumeroCartao { get; private set; }

        public string ExpiracaoCartao { get; private set; }

        public string CvvCartao { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new IniciarPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}