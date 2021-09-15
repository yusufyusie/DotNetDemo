using Contracts;
using DataModel.common;
using DataModel.Entity;
using DataModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _departmentService;

        public DepartmentController(IDepartment departmentService)
        {

            _departmentService= departmentService;
        }

        [HttpPost]
        public ResponseModel<Department> Create(Department department)
        {
            return _departmentService.Create(department);
        }

        [HttpGet]
        public ResponseModel<Department> GetAll( )
        {
            return _departmentService.GetAll();
        }

        [HttpGet("{departmentId}/employees")]
        public async Task<List<EmployeeViewModel>> GetEmployeesByDepartment(int departmentId)
        {
            return await _departmentService.GetEmployeesByDepartment(departmentId);
        }

        [HttpGet("{departmentId}/employee/{employeeId}")]
        public async Task<EmployeeViewModel> GetEmployeesByDepartment(int departmentId,int employeeId)
        {
            return await _departmentService.GetEmployeeByDepartment(departmentId,employeeId);
        }

        [HttpDelete]
        public ResponseModel<Department> Delete(int id)
        {
            return _departmentService.Delete( id);
        }

        [HttpPut]
        public ResponseModel<Department> Update(int id, Department department)
        {
            return _departmentService.Update(id,department);
        }

    }
}
