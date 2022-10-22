using System;
using System.Collections.Generic;

namespace CustomerAPI.Models
{
    public partial class TblUser
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public decimal? Phone { get; set; }
    }
}
