using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaMobileEmployeeService.Models;

namespace WemaMobileEmployeeService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private ResponseModel response = new ResponseModel(400, "Failed Operation");

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("/login")]
        public ResponseModel Login()
        {
            return response;
        }

        [HttpPost]
        [Route("/register")]
        public ResponseModel Register()
        {
            return response;
        }

        [HttpGet]
        [Route("/get-employees")]
        public ResponseModel GetEmployees()
        {
            return response;
        }

        [HttpGet]
        [Route("/get-employee-by-id")]
        public ResponseModel GetEmployeeById()
        {
            return response;
        }

        [HttpPost]
        [Route("/create-employee")]
        public ResponseModel CreateEmployee()
        {
            return response;
        }
    }
}
