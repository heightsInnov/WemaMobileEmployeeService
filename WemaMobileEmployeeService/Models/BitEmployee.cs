using System;
using System.Collections.Generic;

#nullable disable

namespace WemaMobileEmployeeService.Models
{
    public partial class BitEmployee
    {
        public BitEmployee()
        {
            BitEmployeePictures = new HashSet<BitEmployeePicture>();
        }

        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Department { get; set; }
        public int? State { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Role { get; set; }

        public virtual BitDepartment DepartmentNavigation { get; set; }
        public virtual BitState StateNavigation { get; set; }
        public virtual ICollection<BitEmployeePicture> BitEmployeePictures { get; set; }
    }
}
