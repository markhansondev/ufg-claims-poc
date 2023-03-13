using CSharpFunctionalExtensions;

namespace Poc.Claims
{
    public class Line : ValueObject<Line>
    {
        protected virtual long Id { get; set; }
        public virtual decimal ReserveAmount { get; protected set; }
        public virtual string Type { get; protected set; }
        protected Line()
        {
        }

        //TODO: Make non-public
        public Line(decimal initialReserveAmount, string type)
        {
            Type = type;
            ReserveAmount = initialReserveAmount;
        }

        public virtual void Close()
        {
            ReserveAmount = 0;
        }

        protected override bool EqualsCore(Line other)
        {
            return ReserveAmount == other.ReserveAmount
                && Type == other.Type;
        }

        protected override int GetHashCodeCore()
        {
            return (ReserveAmount, Type).GetHashCode();
        }
    }
}