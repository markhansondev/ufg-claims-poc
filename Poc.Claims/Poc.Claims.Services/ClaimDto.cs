
using System.Collections.Generic;
using System.Linq;

namespace Poc.Claims.Services
{
    public class ClaimDto
    {
        public virtual long id { get; set; }
        public virtual IEnumerable<ClaimantDto> claimants { get; }

        public ClaimDto(Claim claim)
        {
            id = claim.Id;
            claimants = claim.Claimants.Select(claimant => new ClaimantDto(claimant));
        } 
    }
}
