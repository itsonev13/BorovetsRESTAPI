using System;
using System.Collections.Generic;

namespace KabileApi.Entities
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int? DishId { get; set; }
        public string DishName { get; set; }
        public int? Quantity { get; set; }
        public int? ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
