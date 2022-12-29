using Poc.Claims.Utils;
using System;

namespace Poc.Claims.Services
{
    public class FnolService
    {
        public FnolService(string connectionString)
        {
            Initer.Init(connectionString);
        }

        public FnolDto GetFnol(long id)
        {
            return new FnolDto(
                new FnolRepository().GetById(id));
        }

        public FnolDto CreateFnol(FnolDto fnolDto)
        {
            var fnol = new Fnol()
            {
                IsReadyToBeCompleted = fnolDto.is_ready_to_be_completed,
                FnolLineLiabilityAmount = fnolDto.line_liability_amount,
                LineType = fnolDto.line_type,
                ClaimantName = fnolDto.claimant_name
            };
            new FnolRepository().Save(fnol);
            return new FnolDto(fnol);
        }

        public ClaimDto CreateClaim(long id)
        {
            var claim = new FnolRepository().GetById(id).CreateClaim();
            new ClaimRepository().Save(claim);
            return new ClaimDto(claim);
        }
    }
}
