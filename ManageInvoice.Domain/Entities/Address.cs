using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInvoice.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string AddressName { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Invoice Invoice { get; set; }
    }
}
