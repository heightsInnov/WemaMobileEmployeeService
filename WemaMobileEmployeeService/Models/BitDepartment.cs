using System;
using System.Collections.Generic;

#nullable disable

namespace WemaMobileEmployeeService.Models
{
    public partial class BitDepartment
    {
        public BitDepartment()
        {
            BitEmployees = new HashSet<BitEmployee>();
        }

        public int Id { get; set; }
        public string Department { get; set; }

        public virtual ICollection<BitEmployee> BitEmployees { get; set; }
    }
}
