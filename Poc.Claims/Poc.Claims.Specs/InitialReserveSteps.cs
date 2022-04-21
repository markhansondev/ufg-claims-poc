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

        [Given(@"an existing claim has an initial line reserve amount")]
        public void GivenAnExistingClaimHasAnInitialLineReserveAmount()
        {
            _reserveContext.Claim = new Claim();
            _reserveContext.Claim.AddLine();
        }

        [Given(@"we are specifying a new line that has an initial reserve amount \$(.*)")]
        public void GivenWeAreSpecifyingANewLineThatHasAnInitialReserveAmount(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the new line is added to the claim")]
        public void WhenTheNewLineIsAddedToTheClaim()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the initial reserve amount is set to \$(.*) on the new line")]
        public void ThenTheInitialReserveAmountIsSetToOnTheNewLine(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
