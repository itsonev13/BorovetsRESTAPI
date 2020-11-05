using System;
using System.Collections.Generic;

namespace KabileApi.Entities
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? CourseId { get; set; }

        public virtual Courses Course { get; set; }
    }
}
