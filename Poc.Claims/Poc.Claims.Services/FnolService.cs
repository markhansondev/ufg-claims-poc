using Poc.Claims.Utils;
using System;

namespace Poc.Claims.Services
{
    public class FnolService
    {
        public FnolService()
        {
            Initer.Init(@"Server=.;Database=ClaimsPoc;Trusted_Connection=true");
        }

        public FnolDto GetFnol(int id)
        {
            var fnol = new FnolRepository().GetById(id);
            //new(1, true, 100, "med", "claimant 1");
            return new FnolDto(fnol.Id, fnol.IsReadyToBeCompleted, fnol.FnolLineLiabilityAmount, fnol.LineType, fnol.ClaimantName);
        }

        public Fnol CreateFnol(FnolDto fnolDto)
        {
            var fnol = new Fnol()
            {
                IsReadyToBeCompleted = fnolDto.is_ready_to_be_completed,
                FnolLineLiabilityAmount = fnolDto.line_liability_amount,
                LineType = fnolDto.line_type,
                ClaimantName = fnolDto.claimant_name
            };
            new FnolRepository().Save(fnol);
            return fnol;
        }

        //TODO: This method should return a claim dto
        public Claim CreateClaim(int id) => new FnolRepository().GetById(id).CreateClaim();            
    }
}
