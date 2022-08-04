namespace Poc.Claims
{
    public class Line
    {
        public decimal ReserveAmount { get; set; }
        public string LineType { get; set; }

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