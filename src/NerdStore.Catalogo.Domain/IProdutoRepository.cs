using System;
using NerdStore.Core.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NerdStore.Catalogo.Domain
{
    public interface IProdutoRepository: IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();

        Task<Produto> ObterProdutoPorId(Guid id);

        Task<Categoria> ObterCategoriaPorCodigo(int codigo);

        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);

        Task<IEnumerable<Categoria>> ObterCategorias();

        void Adicionar(Produto produto);

        void Atualizar(Produto produto);

        void Adicionar(Categoria produto);

        void Atualizar(Categoria produto);
    }
}