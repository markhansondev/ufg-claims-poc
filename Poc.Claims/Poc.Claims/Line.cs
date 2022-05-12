namespace Poc.Claims
{
    public class Line
    {
        public decimal ReserveAmount { get; set; }
        internal Line(decimal initialAmount)
        {
            ReserveAmount = initialAmount;
        }
    }
}