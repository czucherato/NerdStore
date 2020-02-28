using System;
using System.Threading.Tasks;
using NerdStore.Catalogo.Domain;
using System.Collections.Generic;

namespace NerdStore.Catalogo.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        public ProdutoAppService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        private readonly IProdutoRepository _produtoRepository;

        public Task AdicionarProduto(Produto produto)
        {
            _produtoRepository.Adicionar(produto);

            return Task.CompletedTask;
        }

        public Task AtualizarProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> DebitarEstoque(Guid id, int quantidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> ObterCategoriaPorCodigo(int codigo)
        {
            return _produtoRepository.ObterCategoriaPorCodigo(codigo);
        }

        public Task<IEnumerable<Categoria>> ObterCategorias(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ObterPorCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ObterPorTodos()
        {
            throw new NotImplementedException();
        }

        public Task<Produto> ObterProdutoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> ReporEstoque(Guid id, int quantidade)
        {
            throw new NotImplementedException();
        }
    }
}