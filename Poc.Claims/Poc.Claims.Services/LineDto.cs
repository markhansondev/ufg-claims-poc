
namespace Poc.Claims.Services
{
    public class LineDto
    {
        public virtual long id { get; set; }
        public decimal reserve_amount { get; set; }
        public string type { get; set; }

        public LineDto()
        {
        }

        public LineDto(Line line)
        {
            id = line.Id;
            reserve_amount = line.ReserveAmount;
            type = line.Type;
        }
    }
}
