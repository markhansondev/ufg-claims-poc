namespace Poc.Claims
{
    public class Fnol
    {
        public bool IsReadyToBeCompleted { get; set; }
        public decimal FnolLineLiabilityAmount { get; set; }

        public Claim CreateClaim(string lineType)
        {
            return new Claim(FnolLineLiabilityAmount, lineType);
        }
    }
}
