using Poc.Claims.Common;

namespace Poc.Claims
{
    public class Fnol : Aggregate<long>
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
                    //TODO: Initial line's LineNumber (1) is a magic number
                    new[] { new Line(FnolLineLiabilityAmount, LineType, 1)}));
        }
    }
}
