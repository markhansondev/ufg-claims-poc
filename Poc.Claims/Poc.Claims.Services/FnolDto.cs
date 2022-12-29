
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

        public FnolDto(Fnol fnol)
        {
            id = fnol.Id;
            is_ready_to_be_completed = fnol.IsReadyToBeCompleted;
            line_liability_amount = fnol.FnolLineLiabilityAmount;
            line_type = fnol.LineType;
            claimant_name = fnol.ClaimantName;
        }
    }
}
