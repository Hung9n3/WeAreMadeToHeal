using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class Coupon : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpiredAt { get; set; }
        public string ReduceRate { get; set; }
    }
}
