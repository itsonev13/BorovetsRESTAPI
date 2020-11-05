using System;
using System.Collections.Generic;

namespace KabileApi.Entities
{
    public partial class Courses
    {
        public Courses()
        {
            Menu = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Menu> Menu { get; set; }
    }
}
