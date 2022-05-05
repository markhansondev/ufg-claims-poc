namespace Poc.Claims
{
    //todo: should the client NOT be able to create a line independent of a claim?
    public class Line
    {
        public decimal ReserveAmount { get; set; }
        public Line(decimal initialAmount)
        {
            ReserveAmount = initialAmount;
        }
    }
}