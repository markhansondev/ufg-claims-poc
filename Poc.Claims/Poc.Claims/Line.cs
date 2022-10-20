namespace Poc.Claims
{
    public class Line
    {
        public decimal ReserveAmount { get; protected set; }
        public string LineType { get; protected set; }

        public Line(decimal initialAmount, string lineType)
        {
            LineType = lineType;
            ReserveAmount = initialAmount;
        }

        public void Close()
        {
            ReserveAmount = 0;
        }
    }
}