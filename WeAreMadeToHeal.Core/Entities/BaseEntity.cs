using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class BaseEntity
    {

        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        public BaseEntity()
        {
            DateTime utcNow = DateTime.UtcNow;
            Id = Guid.NewGuid().ToString();
            CreatedAt = utcNow;
            UpdatedAt = utcNow;
            IsActive = true;
        }
    }
}
