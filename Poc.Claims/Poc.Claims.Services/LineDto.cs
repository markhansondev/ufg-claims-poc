
namespace Poc.Claims.Services
{
    public class LineDto
    {
        public decimal reserve_amount { get; set; }
        public string type { get; set; }
        public int line_number { get; set; }

        public LineDto()
        {
        }

        public LineDto(Line line)
        {
            reserve_amount = line.ReserveAmount;
            type = line.Type;
            line_number = line.LineNumber;
        }
    }
}
