using System;
using System.Collections.Generic;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Domain
{
    public class Voucher : Entity
    {
        public string Codigo { get; private set; }

        public decimal? Percentual { get; private set; }

        public decimal? ValorDesconto { get; private set; }

        public int Quantidade { get; private set; }

        public TipoDescontoVaucher TipoDescontoVaucher { get; private set; }

        public DateTime DataCriacao { get; private set; }

        public DateTime? DataUtilizacao { get; private set; }

        public DateTime DataValidade { get; private set; }

        public bool Ativo { get; private set; }

        public bool Utilizado { get; private set; }

        ICollection<Pedido> Pedido { get; set; }
    }
}