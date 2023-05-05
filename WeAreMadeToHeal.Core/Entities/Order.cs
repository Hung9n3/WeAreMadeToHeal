using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public string UniqueCode { get; set; }
        public double TotalPrice { get; set; }
        public DateTime? DepartDate { get; set; }
        public DateTime? ArriveDate { get; set; }
        public bool IsArrive { get; set; }
        public bool IsPaid { get; set; }
        public ICollection<OrderItem> OrderItems { get; set;}
    }
}
