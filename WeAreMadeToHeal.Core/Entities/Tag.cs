using System.Collections.Generic;

namespace WeAreMadeToHeal
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TagProduct> TagProducts { get; set; }
    }
}
