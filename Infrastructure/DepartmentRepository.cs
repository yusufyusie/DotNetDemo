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
            var response = new ResponseModel<Department>();
            var oldData = Get(id);
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
            if (!_dbContext.Employees.Where(d => d.Id == id).Any())
            {
                response = new ResponseModel<Department>()
                {
                    Data = null,
                    Success = false,
                    TotalCount = 0,
                    Error = null
                };
                return response;
            }

            response = new ResponseModel<Department>()
            {
                Data = new List<Department>()
                {
                   _dbContext.Departments.Find(id)
                },
                Success = true,
                TotalCount = 1,
                Error = null
            };
             
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
                public int Update(int id, Department department)
        {
            Department oldData = Get(id);
            if (oldData is null)
            {
                return 0;
            }
            oldData.DepartmentName = department.DepartmentName;
            _dbContext.Update(oldData);
             _dbContext.SaveChangesAsync();
            return 1;
        }

        ResponseModel<Department> IDepartment.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
