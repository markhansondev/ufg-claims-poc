namespace Poc.Claims
{
    public class Fnol
    {
        public bool IsReadyToBeCompleted { get; set; }
        public decimal FnolLineLiabilityAmount { get; set; }

        public Claim CreateClaim()
        {
            return new Claim(FnolLineLiabilityAmount);
        }
    }
}
