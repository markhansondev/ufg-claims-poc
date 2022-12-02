
namespace Poc.Claims.Services
{
    public class FnolDto
    {
        public virtual long id { get; set; }
        public bool is_ready_to_be_completed { get; set; }
        public decimal line_liability_amount { get; set; }
        public string line_type { get; set; }
        public string claimant_name { get; set; }

        public FnolDto()
        {
        }

        public FnolDto(long id1, bool isReadyToBeCompleted, decimal lineLiabilityAmount, string lineType, string claimantName)
        {
            id = id1;
            is_ready_to_be_completed = isReadyToBeCompleted;
            line_liability_amount = lineLiabilityAmount;
            line_type = lineType;
            claimant_name = claimantName;
        }
    }
}
