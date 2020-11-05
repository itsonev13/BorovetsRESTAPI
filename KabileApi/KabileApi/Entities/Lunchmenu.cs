using System;
using System.Collections.Generic;

namespace KabileApi.Entities
{
    public partial class Lunchmenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
    }
}
