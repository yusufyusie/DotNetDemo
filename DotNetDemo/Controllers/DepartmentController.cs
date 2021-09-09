using Contracts;
using DataModel;
using DataModel.common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _departmentService;

        public DepartmentController(IDepartment departmentService)
        {

            _departmentService= departmentService;
        }

        [HttpPost]
        public int Create(Department department)
        {
            return _departmentService.Create(department);
        }

        [HttpGet]
        public ResponseModel<Department> GetAll( )
        {
            return _departmentService.GetAll();
        }

        [HttpDelete]
        public ResponseModel<Department> Delete(int id)
        {
            return _departmentService.Delete( id);
        }

    }
}
