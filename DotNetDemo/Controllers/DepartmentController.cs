using Contracts;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //hjihjkkjkjkjjk
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController: ControllerBase
    {
        private readonly IDepartment _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(IDepartment departmentService, ILogger<DepartmentController> logger)
        {
            _logger = logger;
            _departmentService = departmentService;
        }
        [HttpGet]
        [Route("Yesuf")]
        public List<Department> Get()
        {
            return _departmentService.GetAll();
        }
        [HttpPost]
        public int Create(Department department)
        {
            _logger.LogInformation("new department " + department.DepartmentName + " created");
            return _departmentService.Create(Department: department);
        }
        [HttpPut]
        public bool Update(int id, Department department)
        {
            _logger.LogInformation(" department " + department.DepartmentName + " updated");
            return _departmentService.Update(id, department);
        }
        [Authorize]
        [HttpDelete]
        public bool Delete(int id)
        {
            return _departmentService.Delete(id);
        }
    }
}
