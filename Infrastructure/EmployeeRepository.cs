using Contracts;
using DataModel;
using DataModel.common;
using Infrastructure.Validators;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Infrastructure
{
    public class EmployeeRepository : IEmployee
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly EmployeeValidator _employeeValidator;
        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            //nnnnn
            _dbContext = dbContext;
            _employeeValidator = new EmployeeValidator(_dbContext);   
        }
         public ResponseModel<Employee> Create(Employee employee)
        {
            var response = new ResponseModel<Employee>();
            var result = _employeeValidator.Validate(employee);
            if (!result.IsValid)
           
            {
                response.TotalCount = 0; 
                response.Success = false;
                response.Error = new ErrorModel()
                {
                    ErrorCode = 0, ErrorDescription = "Please fix validation errors",
                    ErrorMessage = result.Errors[0].ErrorMessage
                };
                return response;
            }
           _dbContext.Add(employee);
           _dbContext.SaveChanges();

            response.Success=true; 
            response.Error = null;
            response.TotalCount = 1;
            response.Data = new List<Employee>()
            {
            _dbContext.Employees.Find(employee.Id)
            };
            return response;

        }

        public ResponseModel<Employee> Delete(int id)
        {
            var existing = _dbContext.Employees.Find(id);
            if (existing!= null)
            {
                _dbContext.Employees.Remove(existing);
                _dbContext.SaveChanges();
                return true;
            }
            return false;

            //var existing = _dbContext.Employees.Find(id);
            //_dbContext.Employees.Remove(existing);
            //_dbContext.SaveChanges();
            //return true;
        }

        public ResponseModel<Employee> Get(int id)
        {
            var response = new ResponseModel<Employee>();
            if (!_dbContext.Employees.Where(d => d.Id == id).Any())
            {
                response = new ResponseModel<Employee>()
                {
                    Data = null,
                    Success = false,
                    TotalCount = 0,
                    Error = null
                };
                return response;
            }

            response = new ResponseModel<Employee>()
            {
                Data = new List<Employee>()
                {
                   _dbContext.Employees.Find(id)
                },
                Success = true,
                TotalCount = 1,
                Error = null
            };

            return response;

        }

        public List<Employee> GetAll()
        {
            return _dbContext.Employees
                .Where(x=>x.Id>1)
                .Include(x=>x.VDepartment)
                .ToList();
        }

        public async Task<bool> Update(int id, Employee UpdatedData)
        {
            Employee oldData =await _dbContext.Employees.FindAsync(id);
            if(oldData is null)
            {
                return false;
            }
            oldData.DepartmentId= UpdatedData.DepartmentId;
            _dbContext.Update(oldData);
           await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
