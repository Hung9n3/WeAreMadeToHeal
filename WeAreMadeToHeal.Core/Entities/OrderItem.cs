using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class OrderItem : BaseEntity
    {
        public string ProductId { get; set; }
        public string OrderId { get; set; }
        public double TotalPrice { get; set; }
        public int Amount { get; set; }
        public Product Product { get; set; }
    }
}
