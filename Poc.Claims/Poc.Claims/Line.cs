namespace Poc.Claims
{
    public class Line
    {
        public decimal ReserveAmount { get; set; }
        public string LineType { get; set; }
        internal Line(decimal initialAmount, string lineType)
        {
            LineType = lineType;
            ReserveAmount = initialAmount;
        }
    }
}