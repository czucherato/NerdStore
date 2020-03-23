using NerdStore.Vendas.Application.Queries.ViewModels;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NerdStore.Vendas.Application.Queries
{
    public interface IPedidoQueries
    {
        Task<CarrinhoViewModel> ObterCarrinhoCliente(Guid clienteId);

        Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(Guid clienteId);
    }
}