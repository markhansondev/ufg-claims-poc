namespace Poc.Claims
{
    public class Fnol
    {
        public virtual long Id { get; protected set; }
        public virtual bool IsReadyToBeCompleted { get; set; }
        public virtual decimal FnolLineLiabilityAmount { get; set; }
        public virtual string LineType { get; set; }
        public virtual string ClaimantName { get; set; }

        public virtual Claim CreateClaim()
        {
            return new Claim(
                new Claimant(
                    ClaimantName,
                    new[] { new Line(FnolLineLiabilityAmount, LineType) }));
        }
    }
}
