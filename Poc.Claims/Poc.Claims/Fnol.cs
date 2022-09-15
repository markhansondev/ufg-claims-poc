namespace Poc.Claims
{
    public class Fnol
    {
        public bool IsReadyToBeCompleted { get; set; }
        public decimal FnolLineLiabilityAmount { get; set; }
        public string LineType { get; set; }
        public string ClaimantName { get; set; }

        public Claim CreateClaim()
        {
            return new Claim(
                new Claimant(
                    ClaimantName,
                    new[] { new Line(FnolLineLiabilityAmount, LineType) }));
        }
    }
}
