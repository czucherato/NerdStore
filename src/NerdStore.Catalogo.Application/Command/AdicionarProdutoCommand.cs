using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Application.Services;

namespace NerdStore.Catalogo.Application.Command
{
    public class AdicionarProdutoCommand : ICommand
    {
        public AdicionarProdutoCommand(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public string Imagem { get; set; }

        public int QuantidadeEstoque { get; set; }

        public int Catetoria { get; set; }

        public decimal Altura { get; set; }

        public decimal Largura { get; set; }

        public decimal Profundidade { get; set; }

        private readonly IProdutoAppService _produtoAppService;

        public void Execute()
        {
            Produto produto = null;
            Categoria categoria = _produtoAppService.ObterCategoriaPorCodigo(Catetoria).Result;
            Aplicar(ref produto, categoria, new Dimensoes(Altura, Largura, Profundidade));
            _produtoAppService.AdicionarProduto(produto);
        }

        private void Aplicar(ref Produto produto, Categoria categoria, Dimensoes dimensoes)
        {
            produto = new Produto(Nome, Descricao, Valor, Imagem, categoria, dimensoes);
        }
    }
}