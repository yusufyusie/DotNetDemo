using Contracts;
using DataModel.common;
using DataModel.Entity;
using Microsoft.AspNetCore.Mvc;
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
        public ResponseModel<Employee> Get()
        {
            return _employeeService.GetAll();
        }
        [HttpPost]
        public ResponseModel<Employee> Create(Employee employee)
        {

            return _employeeService.Create(employee);
        }
        [HttpPut]
        public async Task<ResponseModel<Employee>> Update(int id,Employee employee)
        {
            return await _employeeService.Update(id,employee);
        }
        [HttpDelete]
        public ResponseModel<Employee> Delete(int id)
        {
            return _employeeService.Delete(id);
        }
    }
}
