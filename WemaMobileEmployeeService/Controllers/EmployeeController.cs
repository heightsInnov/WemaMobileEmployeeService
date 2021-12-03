using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WemaMobileEmployeeService.Helper;
using WemaMobileEmployeeService.Models;
using WemaMobileEmployeeService.Repositories;

namespace WemaMobileEmployeeService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeRepository employeeRepository
            ;
        private ResponseModel response = new ResponseModel(400, "Failed Operation");

        public EmployeeController(ILogger<EmployeeController> logger, EmployeeRepository _employeeRepository)
        {
            _logger = logger;
            employeeRepository = _employeeRepository;
        }

        [HttpPost]
        [Route("/login")]
        public ResponseModel Login([FromBody] LoginModel login)
        {
            if(string.IsNullOrEmpty(login.email) || string.IsNullOrEmpty(login.password))
            {
                response.message = "Bad login parameters, username or password cannot be empty";
                return response;
            }
            else
            {
                var user = employeeRepository.EmployeeList().Where(x => x.Email.Equals(login.email) && x.Password.Equals(login.password)).FirstOrDefault();
                if(user == null)
                {
                    response.message = "Incorrect username or password";
                    return response;
                }
                else
                {
                    EmployeeModel employee = new()
                    {
                        Id = user.Id,
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        Department = user.DepartmentNavigation.Department,
                        State = user.StateNavigation.Name,
                        Gender = user.Gender,
                        Email = user.Email
                    };
                    response.data = employee;
                    response.code = 200;
                    response.message = "Successfully logged in";
                    return response;
                }
                
            }
        }

        [HttpPost]
        [Route("/register")]
        public ResponseModel Register(BitEmployee employee)
        {
            if (string.IsNullOrEmpty(employee.Firstname))
            {
                response.message = "Firstname is compulsory";
                return response;

            }else if (string.IsNullOrEmpty(employee.Lastname))
            {
                response.message = "Lastname is compulsory";
                return response;
            }
            else if (employee.Department == 0)
            {
                response.message = "Department is compulsory";
                return response;
            }
            else if (employee.State == 0)
            {
                response.message = "State is compulsory";
                return response;
            }
            else if (string.IsNullOrEmpty(employee.Gender))
            {
                response.message = "Gender is compulsory";
                return response;
            }
            else if (string.IsNullOrEmpty(employee.Password))
            {
                response.message = "Password is compulsory";
                return response;
            }

            try
            {
                employeeRepository.RegisterEmployee(employee);
                response.message = "Employee successfully created";
                response.code = 200;
                return response;

            }catch(Exception e)
            {
                response.message = e.Message;
                return response;

            }
        }

        [HttpGet]
        [Route("/get-employees")]
        public ResponseModel GetEmployees()
        {
            List<EmployeeModel> employees = new();
            try
            {
                var emps = employeeRepository.EmployeeList();
                if(emps.Count < 1)
                {
                    response.message = "Failed to fetched employees";
                    return response;
                }
                foreach(var e in emps)
                {
                    employees.Add(ClassConverter.convertEmployee(e));
                }
                response.data = employees;
                response.message = "Successfully fetched employees";
                response.code = 200;
                return response;

            }catch(Exception e)
            {
                return response;
            }
        }

        [HttpGet]
        [Route("/get-employee-by-id/{employeeId}")]
        public ResponseModel GetEmployeeById(int employeeId)
        {
            try
            {
                var emp = employeeRepository.EmployeeList().Where(x => x.Id == employeeId).FirstOrDefault();
                if (emp == null)
                {
                    response.message = "Failed to fetched employee with Id "+ employeeId;
                    return response;
                }
                response.data = ClassConverter.convertEmployee(emp);
                response.message = "Successfully fetched employee";
                response.code = 200;
                return response;

            }
            catch (Exception e)
            {
                return response;
            }
        }

        [HttpPost]
        [Route("/create-employee/{adminUsername}")]
        public ResponseModel CreateEmployee(String adminUsername, BitEmployee employee)
        {
            try
            {
                var admin = employeeRepository.EmployeeList().Where(x => x.Email.Equals(adminUsername) && "ADMIN".Equals(x.Role)).FirstOrDefault();
                if(admin == null)
                {
                    response.message = "Only admin users can use this interface";
                    return response;
                }
                else
                {
                    employee.Password = "23456dsfghfgjhfgfsdds3456";
                    employee.Role = "USER";
                    return Register(employee);
                }
            }
            catch(Exception e)
            {
                response.message = e.Message;
                return response;
            }
        }

        [HttpGet]
        [Route("/get-employee-pictures")]
        public ResponseModel GetEmployeePictures()
        {
            List<string> employeePics = new();
            try
            {
                var emps = employeeRepository.GetEmployeePictures().ToList();
                if (emps.Count < 1)
                {
                    response.message = "No employee pictures avaialble";
                    return response;
                }
                foreach (var e in emps)
                {
                    employeePics.Add(e.UploadLink);
                }
                response.data = employeePics;
                response.message = "Successfully fetched employee pictures";
                response.code = 200;
                return response;

            }
            catch (Exception e)
            {
                response.message = e.Message;
                return response;
            }
        }

        [HttpGet]
        [Route("/get-employee-pictures/{employeeId}")]
        public ResponseModel GetEmployeePicturesById(int employeeId)
        {
            if(employeeId < 1)
            {
                response.message = "Invalid employee id supplied";
                return response;
            }
            List<string> employeePics = new();
            try
            {
                var emps = employeeRepository.GetEmployeePictures().Where(x => x.EmployeeId == employeeId).ToList();
                if (emps.Count < 1)
                {
                    response.message = "No employee pictures avaialble";
                    return response;
                }
                foreach (var e in emps)
                {
                    employeePics.Add(e.UploadLink);
                }
                response.data = employeePics;
                response.message = "Successfully fetched employee pictures";
                response.code = 200;
                return response;

            }
            catch (Exception e)
            {
                response.message = e.Message;
                return response;
            }
        }
    }
}
