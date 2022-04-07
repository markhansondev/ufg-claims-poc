using System;
using TechTalk.SpecFlow;
using Shouldly;

namespace Poc.Claims.Specs
{
    [Binding]
    public class InitialReserveSteps
    {

        private class ReserveContext
        {
            public Fnol Fnol { get; set; }
            public Claim Claim { get; set; }
        }

        private ReserveContext _reserveContext;

        [BeforeScenario]
        public void SetupScenario()
        {
            _reserveContext = new ReserveContext();
            _reserveContext.Fnol = new Fnol();
        }

        [Given(@"an FNOL is ready to be completed")]
        public void GivenAnFNOLIsReadyToBeCompleted()
        {
            _reserveContext.Fnol.IsReadyToBeCompleted = true;
        }

        [Given(@"the FNOL line liability amount \$(.*)")]
        public void GivenTheFNOLLineLiabilityAmount(decimal fnolLineLiabilityAmount)
        {
            _reserveContext.Fnol.FnolLineLiabilityAmount = fnolLineLiabilityAmount; 
        }

        [When(@"the claim is created from an FNOL")]
        public void WhenTheClaimIsCreatedFromAnFNOL()
        {
            _reserveContext.Claim = _reserveContext.Fnol.CreateClaim();
        }

        [Then(@"the line initial reserve amount is set to \$(.*)")]
        public void ThenTheInitialReserveAmountIsSetTo(decimal initialReserveAmount)
        {
            _reserveContext.Claim.ShouldNotBeNull();
            _reserveContext.Claim.ReserveAmount.ShouldBe(initialReserveAmount);
        }
    }
}
