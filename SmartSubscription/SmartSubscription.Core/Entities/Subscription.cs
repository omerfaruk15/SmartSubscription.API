namespace SmartSubscription.Core.Entities
{
   public class Subscription : BaseEnity
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "TRY";
        public DateTime NextPaymentDate { get; set; }
        public string BillingCycle { get; set; } = "Monthly";
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
