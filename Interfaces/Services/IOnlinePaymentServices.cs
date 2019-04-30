using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Services
{
    interface IOnlinePaymentServices
    {
        double PaymentFee(double amount);
        double Interest(double amount, int months);
    }
}
