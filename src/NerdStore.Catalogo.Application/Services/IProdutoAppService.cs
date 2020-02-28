using System;
using System.Threading.Tasks;
using NerdStore.Catalogo.Domain;
using System.Collections.Generic;

namespace NerdStore.Catalogo.Application.Services
{
    public interface IProdutoAppService : IDisposable
    {
        Task<Produto> ObterProdutoPorId(Guid id);

        Task<Categoria> ObterCategoriaPorCodigo(int codigo);

        Task<IEnumerable<Produto>> ObterPorTodos();

        Task<IEnumerable<Produto>> ObterPorCategoria(int id);

        Task<IEnumerable<Categoria>> ObterCategorias(int id);   

        Task AdicionarProduto(Produto produto);

        Task AtualizarProduto(Produto produto);

        Task<Produto> DebitarEstoque(Guid id, int quantidade);

        Task<Produto> ReporEstoque(Guid id, int quantidade);
    }
}