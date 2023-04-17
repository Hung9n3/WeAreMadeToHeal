namespace WeAreMadeToHeal
{
    public class Product : BaseEntity
    {
        public int Name { get; set; }
        public string CategoryId { get; set; }
        public string Size { get; set; }
        public string Story { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}
