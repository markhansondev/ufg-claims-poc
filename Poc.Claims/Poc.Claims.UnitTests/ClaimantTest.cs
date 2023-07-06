using System;
using Xunit;
using Shouldly;

namespace Poc.Claims.UnitTests
{
    public class ClaimantTest
    {
        [Fact]
        public void Claimant_equals_other_claimant_with_lines()
        {
            //Arrange
            var claimant = new Claimant("Zach", 
                new[] { new Line(1000, "Test Line", 1),
                new Line(2000, "Test Line 2", 2)
                });

            var other = new Claimant("Zach",
                new[] { new Line(1000, "Test Line", 1),
                new Line(2000, "Test Line 2", 2)
                });

            //Assert
            (claimant == other).ShouldBeTrue();
        }
    }
}
