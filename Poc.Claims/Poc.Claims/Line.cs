namespace Poc.Claims
{
    public class Line
    {
        public decimal ReserveAmount { get; set; }
        public Line(decimal initialAmount)
        {
            ReserveAmount = initialAmount;
        }
    }
}