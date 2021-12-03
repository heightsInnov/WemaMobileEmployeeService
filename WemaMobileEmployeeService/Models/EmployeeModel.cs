using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemaMobileEmployeeService.Models
{
    public class EmployeeModel
    {

        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Department { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }
}
