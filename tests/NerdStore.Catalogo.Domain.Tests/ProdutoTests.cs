using Xunit;
using NUnit.Framework;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            // Arrange & Act Assert

            var ex = Assert.Throws<DomainException>(() =>
            {
                new Produto(string.Empty, "Descrição", false, 100, "Imagem", new Categoria("Categoria 1", 1), new Dimensoes(1, 1, 1));
            });

            Assert.Equals("O campo Nome do produto não pode estar vazio", ex.Message);
        }
    }
}