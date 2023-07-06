using System;
using Xunit;
using Shouldly;

namespace Poc.Claims.UnitTests
{
    public class InvoiceTest
    {
        [Fact]
        public void Create_an_invoice_with_a_positive_amount()
        {
            //Arrange            
            var amount = 10.25m;

            //Act
            Invoice invoice = new Invoice(amount);

            //Assert
            invoice.Amount.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void Create_draft_invoice()
        {
            //Arrange
            var amount = 10.25m;

            //Act
            var invoice = new Invoice(amount);

            //Assert
            invoice.Status.ShouldBe("Draft");
        }

        //[Fact]
        //public void See_the_status_on_my_invoice_with_an_id()
        //{
        //    //Arrange
        //    var status = "Draft";

        //    //Act            
        //    Invoice invoice = GetInvoice();

        //    //Assert
        //}
    }
}
