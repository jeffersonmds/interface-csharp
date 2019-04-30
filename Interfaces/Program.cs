using System;
using System.Globalization;
using Interfaces.Entities;
using Interfaces.Services;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter contract data\nNumber: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int installments = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, contractValue);
            PaymentService paymentService = new PaymentService(new PaypalService());
            paymentService.ProcessContract(contract, installments);

            Console.WriteLine("Installments:");
            foreach (Installment x in contract.Installments)
            {
                Console.WriteLine(x);
            }
            
        }
    }
}
