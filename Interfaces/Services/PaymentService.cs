using System;
using Interfaces.Entities;

namespace Interfaces.Services
{
    class PaymentService
    {
        private IOnlinePaymentServices _paymentService;

        public PaymentService(IOnlinePaymentServices paymentService)
        {
            _paymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {            
            for (int i = 1; i <= months; i++)
            {
                double amount = contract.TotalValue / months;
                amount += _paymentService.Interest(amount, i);
                amount += _paymentService.PaymentFee(amount);
                contract.AddInstallment(new Installment(contract.Date.AddMonths(i), amount));
            }
        }
    }
}
