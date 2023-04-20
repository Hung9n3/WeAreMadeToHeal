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
        public string Description { get; set; } = string.Empty;
        public bool CanExpire { get; set; } = false;
        public DateTime ExpiredAt { get; set; } = DateTime.Now.AddYears(100);
        public int ExpiredAfterReceive { get; set; } = 5;
        public string MaxReduce { get; set; } = string.Empty;
        public double ReduceAmount { get; set; } = 0.0;
        public double ReduceRate { get; set; } = double.MinValue;
    }
}
