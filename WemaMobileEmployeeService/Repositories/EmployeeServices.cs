using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaMobileEmployeeService.Models;

namespace WemaMobileEmployeeService.Repositories
{
    public class EmployeeService : BaseRepository, EmployeeRepository
    {
        public EmployeeService(WemaMobileTrainingContext context) : base(context)
        {

        }

        public bool DeleteEmployee(BitEmployee employee)
        {
            try
            {
                _context.BitEmployees.Remove(employee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<BitEmployee> EmployeeList()
        {
            return _context.BitEmployees
                .Include(x => x.StateNavigation)
                .Include(x => x.DepartmentNavigation)
                .Include(x => x.BitEmployeePictures)
                .ToList();
        }

        public List<BitEmployeePicture> GetEmployeePictures()
        {
            return _context.BitEmployeePictures
                .ToList();
        }

        public bool RegisterEmployee(BitEmployee employee)
        {
            try
            {
                _context.BitEmployees.Add(employee);
                _context.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool UpdateEmployee(BitEmployee employee)
        {
            try
            {
                _context.BitEmployees.Update(employee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
