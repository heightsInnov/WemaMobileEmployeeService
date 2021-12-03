using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WemaMobileEmployeeService.Models
{
    public class ResponseModel
    {

        public int code { get; set; }
        public string message { get; set; }
        public Object data { get; set; }

        public ResponseModel(int code, string message)
        {
            this.code = code;
            this.message = message;
        }
    }
}
