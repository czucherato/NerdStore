using FluentValidation;
using NerdStore.Vendas.Domain;
using System;

namespace NerdStore.Vendas.Application.Validations
{
    public class VoucherAplicavelValidation : AbstractValidator<Voucher>
    {
        public VoucherAplicavelValidation()
        {
            RuleFor(c => c.DataValidade)
                .Must(DataVencimentoSuperiorAtual)
                .WithMessage("Este voucher está expirado.");
        }

        protected static bool DataVencimentoSuperiorAtual(DateTime dataValidade)
        {
            throw new NotImplementedException();
        }
    }
}
