namespace Poc.Claims
{
    public class Line
    {
        public virtual long Id { get; protected set; }
        public virtual decimal ReserveAmount { get; protected set; }
        public virtual string Type { get; protected set; }
        protected Line()
        {
        }

        public Line(decimal initialReserveAmount, string type)
        {
            Type = type;
            ReserveAmount = initialReserveAmount;
        }

        public virtual void Close()
        {
            ReserveAmount = 0;
        }
    }
}