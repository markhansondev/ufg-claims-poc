using CSharpFunctionalExtensions;

namespace Poc.Claims
{
    public class Payment : ValueObject<Payment>
    {
        protected virtual long Id { get; set; }

        protected Payment()
        {
        }

        private Payment(decimal amount)
        {
            Amount = amount;
        }

        public virtual decimal Amount { get; set; }

        public static Result<Payment> Create(Maybe<decimal> amountOrNothing) =>
            amountOrNothing
                .ToResult("The amount should have a value.")
                .Ensure(amount => amount >= 0, "A payment amount must positive.")
                .Map(amount => new Payment(amount));

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