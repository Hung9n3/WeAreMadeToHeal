namespace WeAreMadeToHeal
{
    public class TagProduct : BaseEntity
    {
        public string ProductId { get; set; }
        public string TagId { get; set; }
        public Tag Tag { get; set; }
        public Product Product { get; set; }
    }
}
