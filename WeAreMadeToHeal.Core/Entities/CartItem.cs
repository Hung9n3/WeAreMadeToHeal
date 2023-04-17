namespace WeAreMadeToHeal
{
    public class CartItem : BaseEntity
    {
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
    }
}
