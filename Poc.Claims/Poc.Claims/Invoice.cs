namespace Poc.Claims
{
    public class Invoice
    {

        public Invoice(decimal amount)
        {
            Amount = amount;
            Status = "Draft";
        }

        public decimal Amount { get; }
        public string Status { get; }
    }
}
