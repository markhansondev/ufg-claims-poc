using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Poc.Claims
{
    public class Payment : ValueObject<Payment>
    {
        private Payment(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; set; }

        public static Result<Payment> Create(decimal amount)
        {
            if (amount < 0)
                return Result.Failure<Payment>("A payment amount must positive.");

            return Result.Success(new Payment(amount));
        }

        protected override bool EqualsCore(Payment other)
        {
            return Amount == other.Amount;
        }

        protected override int GetHashCodeCore()
        {
            return (Amount).GetHashCode();
        }
    }
}