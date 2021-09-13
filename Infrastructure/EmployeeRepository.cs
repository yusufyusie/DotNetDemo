using Contracts;
using DataModel;
using DataModel.common;
using Infrastructure.Validators;
using Microsoft.AspNetCore.Http;
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
            var response = new ResponseModel<Employee>();

            //TODO
            var existing = _dbContext.Employees.Find(id);
            if (existing is null)
            {
                _dbContext.Employees.Remove(existing);
                _dbContext.SaveChanges();
                response.Success = false;
                response.Error = new ErrorModel()
                {
                    ErrorCode= StatusCodes.Status404NotFound,
                    ErrorDescription="Employee not found"
                };
                return response;
            }
            var employee = _dbContext.Employees.Find(id);
            response.Data = new List<Employee>();
            response.Data.Add(employee);
            response.Success = true;
            return response;
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
                    Error = new ErrorModel()
                    {
                        ErrorCode= StatusCodes.Status404NotFound,
                        ErrorDescription= "Employee not found",
                        ErrorMessage="Employee with the given Id does not exist"
                    }
                };
                return response;
            }

            response.Data = new List<Employee>()
                {
                   _dbContext.Employees.Find(id)
                };
            response.Success = true;
            response.TotalCount = 1;
            response.Error = null;

            return response;

        }

        public ResponseModel<Employee> GetAll()
        {
            var response = new ResponseModel<Employee>
            {
                Data = _dbContext.Employees
                .Include(x => x.VDepartment)
                .ToList()
            };
            response.Success = response.Data.Count > 0;
           return response;
        }

        public async Task<ResponseModel<Employee>>  Update(int id, Employee UpdatedData)
        {
            var response = new ResponseModel<Employee>();
            //TODO
            Employee oldData =await _dbContext.Employees.FindAsync(id);
            if(oldData is null)
            {
                response.Success = false;
                response.Error = new ErrorModel() { ErrorDescription = "Employee not found", ErrorCode = StatusCodes.Status404NotFound };
                return response;
            }

            oldData.DepartmentId= UpdatedData.DepartmentId;
            _dbContext.Update(oldData);
            await _dbContext.SaveChangesAsync();
            var employee= await _dbContext.Employees.FindAsync(id);
            response.Success= true;
            response.Data = new List<Employee>();
            response.Data.Add(employee);
            return response;
        }
    }
}
