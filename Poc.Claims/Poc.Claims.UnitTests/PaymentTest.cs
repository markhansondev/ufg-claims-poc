using Shouldly;
using System.Linq;
using Xunit;

namespace Poc.Claims.UnitTests
{
    public class PaymentTest
    {
        [Fact]
        public void Make_payment_on_a_line()
        {
            //Arrange
            var line = CreateClaim()
                .Claimants.ElementAt(0)
                .Lines.ElementAt(0);

            //Act
            line.MakePayment(0m);

            //Assert
            line.Payments.Count().ShouldBe(1);
        }

        private static Claim CreateClaim()
        {
            return new Fnol()
                {
                    ClaimantName = "claimant1",
                    FnolLineLiabilityAmount = 0,
                    IsReadyToBeCompleted = true,
                    LineType = "stressing"
                }
                .CreateClaim();
        }

        [Fact]
        public void Payment_amount_can_not_be_less_than_zero()
        {
            //Arrange
            var line = CreateClaim()
                .Claimants.ElementAt(0)
                .Lines.ElementAt(0);

            //Act
            var result = line.MakePayment(-10.0m);

            //Assert
            result.IsFailure.ShouldBeTrue();
        }
    }
}
