using Contracts;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeService;
        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public List<Employee> Get()
        {
            return _employeeService.GetAll();
        }
        [HttpPost]
        public int Create(Employee employee)
        {
            return _employeeService.Create(Employee: employee);
        }
        [HttpPut]
        public bool Update(int id, Employee employee)
        {
            return _employeeService.Update(id, employee);
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            return _employeeService.Delete(id);
        }
    }
}
