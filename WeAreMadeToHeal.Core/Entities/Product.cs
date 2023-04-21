using System.Collections.Generic;

namespace WeAreMadeToHeal
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string Size { get; set; }
        public string Story { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public double Price { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<TagProduct> TagProducts { get; set; }
    }
}
