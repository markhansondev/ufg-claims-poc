using System;
using TechTalk.SpecFlow;

namespace Poc.Claims.Specs
{
    [Binding]
    public class InitialReserveSteps
    {

        private class ReserveContext
        {
            public Fnol Fnol { get; set; }

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
        public void GivenTheFNOLLineLiabilityAmount(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the claim is created from an FNOL")]
        public void WhenTheClaimIsCreatedFromAnFNOL()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the intial reserve is set to \$(.*)")]
        public void ThenTheIntialReserveIsSetTo(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
