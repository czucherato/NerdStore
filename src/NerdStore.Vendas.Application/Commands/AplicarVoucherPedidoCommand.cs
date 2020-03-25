using System;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Commands
{
    public class AplicarVoucherPedidoCommand : Command
    {
        public AplicarVoucherPedidoCommand(Guid clienteId, string codigoVoucher)
        {
            ClienteId = clienteId;
            CodigoVoucher = codigoVoucher;
        }

        public Guid ClienteId { get; set; }

        public string CodigoVoucher { get; set; }

        public override bool EhValido()
        {
            return base.EhValido();
        }
    }
}
