using System;
using System.Linq;
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

        [Given(@"the FNOL line liability amount is \$(.*)")]
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
            _reserveContext.Claim.Lines.First().ReserveAmount.ShouldBe(initialReserveAmount);
        }

        [Given(@"an existing claim has an initial line reserve amount")]
        public void GivenAnExistingClaimHasAnInitialLineReserveAmount()
        {
            const decimal initialReserveAmountForInitialLine = 1000;
            _reserveContext.Claim = new Claim(initialReserveAmountForInitialLine);
        }

        [When(@"a new line is added to the claim with an initial reserve amount of \$(.*)")]
        public void WhenANewLineIsAddedToTheClaimWithAnInitialReserveAmountOf(decimal initialLineAmount)
        {
            _reserveContext.Claim.AddLine(initialLineAmount);
        }

        [Then(@"the initial reserve amount is set to \$(.*) on the new line")]
        public void ThenTheInitialReserveAmountIsSetToOnTheNewLine(decimal reserveAmount)
        {
            _reserveContext.Claim.Lines.LastOrDefault()?.ReserveAmount.ShouldBe(reserveAmount);
        }

        [Given(@"an existing claim has an initial line reserve amount of \$(.*)")]
        public void GivenAnExistingClaimHasAnInitialLineReserveAmountOf(decimal initialReserveAmount)
        {
            _reserveContext.Claim = new Claim(initialReserveAmount);
        }

        [Then(@"the total reserve amount is set to \$(.*) on the new claim")]
        public void ThenTheTotalReserveAmountIsSetToOnTheNewClaim(decimal totalReserveAmount)
        {
            _reserveContext.Claim.TotalReserveAmount.ShouldBe(totalReserveAmount);
        }

        //6/23
        [Given(@"an exisiting claim that has (.*) lines each with a reserve amount of \$(.*)")]
        public void GivenAnExisitingClaimThatHasLinesEachWithAReserveAmountOf(int lineCount, int lineReserveAmount)
        {
            _reserveContext.Claim = new Claim(lineReserveAmount);

            for (int i = 1; i <= lineCount; i++)
            {
                _reserveContext.Claim.AddLine(lineReserveAmount);
            }
        }

        [When(@"one of the lines is closed")]
        public void WhenOneOfTheLinesIsClosed()
        {
            //TODO: Discussion on what is "missing" to move forward
            ScenarioContext.Current.Pending();
        }

        [Then(@"the total reserve amount is \$(.*)")]
        public void ThenTheTotalReserveAmountIs(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the closed line has a reserve amount of \$(.*)")]
        public void ThenTheClosedLineHasAReserveAmountOf(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
