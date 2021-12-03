using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaMobileEmployeeService.Models;

namespace WemaMobileEmployeeService.Repositories
{
    public interface EmployeeRepository
    {
        bool RegisterEmployee(BitEmployee employee);
        List<BitEmployee> EmployeeList();
        bool DeleteEmployee(BitEmployee employee);
        bool UpdateEmployee(BitEmployee employee);
        List<BitEmployeePicture> GetEmployeePictures();

    }
}
