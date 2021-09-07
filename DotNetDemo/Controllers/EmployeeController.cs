using Contracts;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            return _employeeService.Create(employee);
        }
        [HttpPut]
        public async Task<bool> Update(int id,Employee employee)
        {
            return await _employeeService.Update(id,employee);
        }
    }
}
