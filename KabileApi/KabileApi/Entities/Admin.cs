using System;
using System.Collections.Generic;

namespace KabileApi.Entities
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
