using Poc.Claims.Utils;

namespace Poc.Claims.Services
{
    public class FnolService
    {
        public FnolService()
        {
            Initer.Init(@"Server=.;Database=ClaimsPoc;Trusted_Connection=true");
        }

        public FnolDto GetFnol()
        {
            var fnol = new FnolRepository().GetById(1);
            //new(1, true, 100, "med", "claimant 1");
            return new FnolDto(fnol.Id, fnol.IsReadyToBeCompleted, fnol.FnolLineLiabilityAmount, fnol.LineType, fnol.ClaimantName);
        }
    }
}
