using Poc.Claims.Utils;
using System;

namespace Poc.Claims.Services
{
    public class ClaimService
    {
        public ClaimService(string connectionString)
        {
            Initer.Init(connectionString);
        }

        public ClaimDto GetClaim(long id)
        {
            var claim = new ClaimRepository().GetById(id);
            return new ClaimDto(claim);
        }

        public ClaimDto AddClaimant(long id, AddClaimantDto addClaimantDto)
        {
            var claim = new ClaimRepository().GetById(id);
            claim.AddClaimant(addClaimantDto.name);
            new ClaimRepository().Save(claim);

            return new ClaimDto(claim);
        }
    }
}
