using Contracts;
using DataModel;
using DataModel.common;
using Infrastructure.Validators;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class DepartmentRepository : IDepartment
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly DepartmentValidator _departmentValidator;
        public DepartmentRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
            _departmentValidator = new DepartmentValidator(_dbContext);
        }
        public ResponseModel<Department> Create(Department department){
            var response=  new ResponseModel<Department>();
            var validationResult = _departmentValidator.Validate(department);
            if (!validationResult.IsValid)
            {
                response.Error = new ErrorModel()
                {
                    ErrorCode = 0,
                    ErrorDescription = "We have found some validation errors",
                    ErrorMessage = validationResult.Errors[0].ErrorMessage,
                };
                response.Success = false;
                response.Data = null;
               return response;
            }
 
            _dbContext.Departments.Add(department);
             _dbContext.SaveChanges();
            response.Data = new List<Department>();
            response.Data.Add(department);
            response.Success = true;
            response.Error = null;
            return response;
        }

        public ResponseModel<Department> Delete(int id)
        {
            var response = new ResponseModel<Department>();
            //TODO
            var oldData = _dbContext.Departments.Find(id);
            if(oldData is null)
            {
                response.Success = false;
                return response;

            }

            _dbContext.Departments.Remove(oldData);
            _dbContext.SaveChanges();
            response.Success = true;
            response.Data = new List<Department>()
            {
                oldData
            };
            return response;
        }

        public ResponseModel<Department> Get(int id)
        {
            var response = new ResponseModel<Department>();
            if (!_dbContext.Departments.Where(d => d.DepartmentId == id).Any())
            {
                response.Data = null;
                response.Success = false;
                response.TotalCount = 0;
                response.Error = new ErrorModel()
                {
                    ErrorCode = StatusCodes.Status404NotFound,
                    ErrorDescription = "Department with the given Id is not found",
                    ErrorMessage = "Department with the given Id is not found"
                };
                return response;
            }
            //TODO refactor 
                Department CurrentDepartment = _dbContext.Departments.FirstOrDefault(x => x.DepartmentId == id);
                response.Data = new List<Department>();
                response.Data.Add(CurrentDepartment);
                response.Success = true;
                response.TotalCount = response.Data.Count;
                response.Error = null;
                return response;
            
        }

        public ResponseModel<Department> GetAll()
        {
            return new ResponseModel<Department>()
            {
                Data = _dbContext.Departments.ToList(),
                Success = true,
                Error= null,
                TotalCount = _dbContext.Departments.Count()
           };
          
        }
      public ResponseModel<Department> Update(int id, Department department)
        {
            var response = new ResponseModel<Department>();
            //TODO
            Department oldData = _dbContext.Departments.Find(id);
            if (oldData is null)
            {
                response.Data = null;
                response.Error = new ErrorModel()
                {
                    ErrorCode = StatusCodes.Status404NotFound,
                    ErrorDescription = "Department with the given Id is not found",
                    ErrorMessage = "Department with the given Id is not found"
                };
             return  response;
            }
            oldData.DepartmentName = department.DepartmentName;
            _dbContext.Update(oldData);
             _dbContext.SaveChangesAsync();
            Department CurrentDepartment = _dbContext.Departments.FirstOrDefault(x => x.DepartmentId == id);
            response.Data = new List<Department>();
            response.Data.Add(CurrentDepartment);
            response.Success = true;
            response.TotalCount = response.Data.Count;
            response.Error = null;
            return response; 
        }
    }
}
