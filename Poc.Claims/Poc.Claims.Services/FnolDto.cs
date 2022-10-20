
namespace Poc.Claims.Services
{
    public class FnolDto
    {
        public virtual long id { get; }
        public bool is_ready_to_be_completed { get; }
        public decimal line_liability_amount { get; }
        public string line_type { get; }
        public string claimant_name { get; }

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
