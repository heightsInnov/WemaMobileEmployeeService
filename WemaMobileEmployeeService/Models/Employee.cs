using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemaMobileEmployeeService.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string department { get; set; }
        public string picture { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string state { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirm_password { get; set; }
    }
}
