using System;
using NerdStore.Core.Data;
using System.Threading.Tasks;
using NerdStore.Catalogo.Domain;
using System.Collections.Generic;

namespace NerdStore.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public void Adicionar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Categoria produto)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Categoria produto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> ObterCategorias()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> ObterProdutoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> ObterCategoriaPorCodigo(int codigo)
        {
            throw new NotImplementedException();
        }
    }
}
