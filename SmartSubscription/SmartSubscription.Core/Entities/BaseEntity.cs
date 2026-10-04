namespace SmartSubscription.Core.Entities
{
   public abstract class BaseEnity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
