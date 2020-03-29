using System;
using NerdStore.Core.Data;
using NerdStore.Pagamentos.Business;

namespace NerdStore.Pagamentos.Data
{
    public class PagamentoRepository : IPagamentoRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public void Adicionar(Pagamento pagamento)
        {
            throw new NotImplementedException();
        }

        public void AdicionarTransacao(Transacao transacao)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
