using System;
using System.Collections.Generic;

#nullable disable

namespace WemaMobileEmployeeService.Models
{
    public partial class BitState
    {
        public BitState()
        {
            BitEmployees = new HashSet<BitEmployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<BitEmployee> BitEmployees { get; set; }
    }
}
