using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace Poc.Claims
{
    public class Line : ValueObject<Line>
    {
        protected virtual long Id { get; set; }
        public virtual decimal ReserveAmount { get; protected set; }
        public virtual string Type { get; protected set; }
        public virtual IEnumerable<Payment> Payments => _payments;

        private readonly IList<Payment> _payments;

        protected Line()
        {
        }

        public Line(decimal initialReserveAmount, string type)
        {
            Type = type;
            ReserveAmount = initialReserveAmount;
            _payments = new List<Payment>();
        }

        public virtual void Close()
        {
            ReserveAmount = 0;
        }

        protected override bool EqualsCore(Line other) => 
            ReserveAmount == other.ReserveAmount
            && Type == other.Type;

        public virtual Result MakePayment(decimal amount) =>
            Payment.Create(amount)
                .Tap(payment => _payments.Add(payment));

        protected override int GetHashCodeCore() => (ReserveAmount, Type).GetHashCode();
    }
}