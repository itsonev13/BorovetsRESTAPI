using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabileApi.Models
{
    public class MenuDto
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double  Price{ get; set; }
        public int CourseId { get; set; }
    }
}
