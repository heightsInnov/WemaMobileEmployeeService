using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaMobileEmployeeService.Models;

namespace WemaMobileEmployeeService.Helper
{
    public class ClassConverter
    {

        public static EmployeeModel convertEmployee(BitEmployee user)
        {

            return  new EmployeeModel()
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Department = user.DepartmentNavigation.Department,
                State = user.StateNavigation.Name,
                Gender = user.Gender,
                Email = user.Email
            };
        }
    }
}
