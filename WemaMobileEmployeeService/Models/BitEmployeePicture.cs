using System;
using System.Collections.Generic;

#nullable disable

namespace WemaMobileEmployeeService.Models
{
    public partial class BitEmployeePicture
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string UploadLink { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual BitEmployee Employee { get; set; }
    }
}
