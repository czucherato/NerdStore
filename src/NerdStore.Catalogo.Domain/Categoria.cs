using System.Collections.Generic;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        protected Categoria()
        {
            Produtos = new List<Produto>();
        }

        public Categoria(string nome, int codigo)
            : this()
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public string Nome { get; private set; }

        public int Codigo { get; private set; }

        public ICollection<Produto> Produtos { get; set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazion");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Código não pode ser zero");
        }
    }
}