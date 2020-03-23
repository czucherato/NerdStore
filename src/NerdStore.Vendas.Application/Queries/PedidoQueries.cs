using System;
using System.Threading.Tasks;
using NerdStore.Vendas.Domain;
using System.Collections.Generic;
using NerdStore.Vendas.Application.Queries.ViewModels;

namespace NerdStore.Vendas.Application.Queries
{
    public class PedidoQueries : IPedidoQueries
    {
        public PedidoQueries(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        private readonly IPedidoRepository _pedidoRepository;

        public Task<CarrinhoViewModel> ObterCarrinhoCliente(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(Guid clienteId)
        {
            throw new NotImplementedException();
        }
    }
}