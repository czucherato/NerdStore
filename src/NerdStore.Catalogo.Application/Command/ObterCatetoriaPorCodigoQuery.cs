using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Application.Services;

namespace NerdStore.Catalogo.Application.Command
{
    public class ObterCatetoriaPorCodigoQuery : IQuery<object>
    {
        public ObterCatetoriaPorCodigoQuery(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        private readonly IProdutoAppService _produtoAppService;

        public int? Codigo { get; set; }

        public object Executar()
        {
            Categoria resultado = _produtoAppService.ObterCategoriaPorCodigo(Codigo.Value).Result;
            return new
            {
                resultado.Codigo,
                resultado.Nome
            };
        }
    }
}
