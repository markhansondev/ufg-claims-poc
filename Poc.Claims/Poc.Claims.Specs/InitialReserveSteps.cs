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
        private const string DefaultLineType = "medical";
        private const string NewLineType = "line type 2";
        private const string DefaultClaimantName = "Sonia";
        private const decimal DefaultReserveAmount = 1000;

        [BeforeScenario]
        public void SetupScenario()
        {
            _reserveContext = new ReserveContext();
            _reserveContext.Fnol = new Fnol();
            _reserveContext.Fnol.ClaimantName = DefaultClaimantName;
            _reserveContext.Fnol.LineType = DefaultLineType;
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
        public void ThenTheLineInitialReserveAmountIsSetTo(decimal initialReserveAmount)
        {
            _reserveContext.Claim.ShouldNotBeNull();
            _reserveContext.Claim.GetClaimant(DefaultClaimantName).GetLine(DefaultLineType).ReserveAmount.ShouldBe(initialReserveAmount);
        }

        [Given(@"an existing claim has an initial line reserve amount")]
        public void GivenAnExistingClaimHasAnInitialLineReserveAmount()
        {
            _reserveContext.Claim = new Claim(
                new Claimant(
                    DefaultClaimantName,
                    new[] { new Line(DefaultReserveAmount, DefaultLineType, 1)}));
        }

        [When(@"a new line is added to the claim with an initial reserve amount of \$(.*)")]
        public void WhenANewLineIsAddedToTheClaimWithAnInitialReserveAmountOf(decimal initialLineAmount)
        {
            _reserveContext.Claim.GetClaimant(DefaultClaimantName).AddLine(initialLineAmount, NewLineType);
        }

        [Then(@"the initial reserve amount is set to \$(.*) on the new line")]
        public void ThenTheInitialReserveAmountIsSetToOnTheNewLine(decimal reserveAmount)
        {
            _reserveContext.Claim
                .GetClaimant(DefaultClaimantName)
                .GetLine(NewLineType).ReserveAmount.ShouldBe(reserveAmount);
        }

        [Given(@"an existing claim has an initial line reserve amount of \$(.*)")]
        public void GivenAnExistingClaimHasAnInitialLineReserveAmountOf(decimal initialReserveAmount)
        {
            _reserveContext.Claim = new Claim(
                new Claimant(
                    DefaultClaimantName,
                    new[] { new Line(initialReserveAmount, DefaultLineType, 1) }));
        }

        [Then(@"the total reserve amount is set to \$(.*) on the new claim")]
        public void ThenTheTotalReserveAmountIsSetToOnTheNewClaim(decimal totalReserveAmount)
        {
            _reserveContext.Claim.TotalReserveAmount.ShouldBe(totalReserveAmount);
        }

        [Given(@"an existing claim with these lines")]
        public void GivenAnExistingClaimWithTheseLines(Table table)
        {
            _reserveContext.Claim = new Claim(
                new Claimant(
                    DefaultClaimantName,
                    table.Rows.Select(
                        row => new Line(
                            decimal.Parse(row["reserve amount"]),
                            row["line type"], 
                            1)                        
                        )
                    )
                );
        }

        [When(@"the ""(.*)"" line is closed")]
        public void WhenTheLineIsClosed(string lineType)
        {
            _reserveContext.Claim.GetClaimant(DefaultClaimantName).CloseLine(lineType);
        }

        [Then(@"the total reserve amount is \$(.*)")]
        public void ThenTheTotalReserveAmountIs(decimal newReserveAmount)
        {
            _reserveContext.Claim.TotalReserveAmount.ShouldBe(newReserveAmount);
        }

        [Then(@"the ""(.*)"" line has a reserve amount of \$(.*)")]
        public void ThenTheLineHasAReserveAmountOf(string lineType, decimal newLineReserveAmount)
        {
            _reserveContext.Claim.GetClaimant(DefaultClaimantName).GetLine(lineType).ReserveAmount.ShouldBe(newLineReserveAmount);
        }
    }
}
