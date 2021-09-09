using Contracts;
using DataModel;
using DataModel.common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class DepartmentRepository : IDepartment
    {
        private readonly EmployeeDbContext _dbContext;
        public DepartmentRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(Department department)
        {
           
            _dbContext.Departments.Add(department);
             _dbContext.SaveChanges();
            return department.DepartmentId;
        }

        public ResponseModel<Department> Delete(int id)
        {
            var existing = _dbContext.Departments.Find(id);       
                _dbContext.Departments.Remove(existing);
                _dbContext.SaveChanges();
                return new ResponseModel<Department>();
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
