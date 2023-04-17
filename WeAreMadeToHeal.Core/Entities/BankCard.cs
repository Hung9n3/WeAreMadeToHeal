using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class BankCard : BaseEntity
    {
        public string BankName { get; set; }
        public string UserId { get; set; }
        public string OwnerName { get; set; }
        public string Number { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
