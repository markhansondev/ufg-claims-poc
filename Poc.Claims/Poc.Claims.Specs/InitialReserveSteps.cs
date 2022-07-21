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
            var initialLineType = "med";
            _reserveContext.Claim = _reserveContext.Fnol.CreateClaim(initialLineType);
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
            const string initialLineType = "med";
            _reserveContext.Claim = new Claim(initialReserveAmountForInitialLine, initialLineType);
        }

        [When(@"a new line is added to the claim with an initial reserve amount of \$(.*)")]
        public void WhenANewLineIsAddedToTheClaimWithAnInitialReserveAmountOf(decimal initialLineAmount)
        {
            const string newLineType = "med2";
            _reserveContext.Claim.AddLine(initialLineAmount, newLineType);
        }

        [Then(@"the initial reserve amount is set to \$(.*) on the new line")]
        public void ThenTheInitialReserveAmountIsSetToOnTheNewLine(decimal reserveAmount)
        {
            _reserveContext.Claim.Lines.LastOrDefault()?.ReserveAmount.ShouldBe(reserveAmount);
        }

        [Given(@"an existing claim has an initial line reserve amount of \$(.*)")]
        public void GivenAnExistingClaimHasAnInitialLineReserveAmountOf(decimal initialReserveAmount)
        {
            const string initialLineType = "med";
            _reserveContext.Claim = new Claim(initialReserveAmount, initialLineType);
        }

        [Then(@"the total reserve amount is set to \$(.*) on the new claim")]
        public void ThenTheTotalReserveAmountIsSetToOnTheNewClaim(decimal totalReserveAmount)
        {
            _reserveContext.Claim.TotalReserveAmount.ShouldBe(totalReserveAmount);
        }

        [Given(@"an existing claim with these lines")]
        public void GivenAnExistingClaimWithTheseLines(Table table)
        {
            var initialLineType = table.Rows.First()["line type"];
            var initialReserveAmount = decimal.Parse(table.Rows.First()["reserve amount"]);

            _reserveContext.Claim = new Claim(initialReserveAmount, initialLineType);

            for (int i = 1; i < table.RowCount; i++)
            {
                var row = table.Rows[i];

                _reserveContext.Claim.AddLine(decimal.Parse(row["reserve amount"]), row["reserve amount"]);
            }

            ScenarioContext.Current.Pending();
        }

        [When(@"the ""(.*)"" line is closed")]
        public void WhenTheLineIsClosed(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the total reserve amount is \$(.*)")]
        public void ThenTheTotalReserveAmountIs(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the ""(.*)"" line has a reserve amount of \$(.*)")]
        public void ThenTheLineHasAReserveAmountOf(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
