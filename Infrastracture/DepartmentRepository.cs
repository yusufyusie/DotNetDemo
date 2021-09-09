using Contracts;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture
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

        public bool Delete(int id)
        {
            var old = _dbContext.Departments.Find(id);
            if (old != null)
            {
               
                _dbContext.Departments.Remove(old);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Department Get(int id)
        {
            return _dbContext.Departments.Find(keyValues: id);
        }

        public List<Department> GetAll()
        {
            return _dbContext.Departments.ToList();
        }

        public bool Update(int id, Department department)
        {
            var old = _dbContext.Departments.Find(id);
            if(old!=null)
            {
                old.DepartmentId = department.DepartmentId;
                old.DepartmentName = department.DepartmentName;
                _dbContext.Departments.Update(old);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
