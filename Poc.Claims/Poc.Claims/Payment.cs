using System;

namespace Poc.Claims
{
    public class Payment
    {
        public Payment(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; set; }
    }
}
