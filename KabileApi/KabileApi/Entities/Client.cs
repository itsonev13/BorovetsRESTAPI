using System;
using System.Collections.Generic;

namespace KabileApi.Entities
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
