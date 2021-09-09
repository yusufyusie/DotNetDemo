using Contracts;
using DataModel;
using DataModel.common;
using Infrastructure.Validators;
using System;
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
        public int Create(Department department)
        {
           
            _dbContext.Departments.Add(department);
             _dbContext.SaveChanges();
            return department.DepartmentId;
        }

        public ResponseModel<Department> Delete(int id)
        {
            //This needs to done by birhan
            var oldData = _dbContext.Departments.Find(id);
            Department department=Get(id);

            var response = new ResponseModel<Department>();
            var result = _departmentValidator.Validate(department);
            if (!result.IsValid)
            {
                response.TotalCount = 0; response.Success = false;
                response.Error = new ErrorModel()
                {
                    ErrorCode = 0,
                    ErrorDescription = "Please fix validation errors",
                    ErrorMessage = result.Errors[0].ErrorMessage
                };
                return response;
            }


            _dbContext.Departments.Remove(oldData);
            _dbContext.SaveChanges();




            return response;
        }

      
        public Department Get(int id)
        {
            return _dbContext.Departments.Where(x=>x.DepartmentId==id).FirstOrDefault();
             

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

        public int Update(int id, Department department)
        {
            Department oldData = _dbContext.Departments.Find(id);
            if (oldData is null)
            {
                return 0;
            }
            oldData.DepartmentName = department.DepartmentName;
            _dbContext.Update(oldData);
             _dbContext.SaveChangesAsync();
            return 1;
        }
    }
}
