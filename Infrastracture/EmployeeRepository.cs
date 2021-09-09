using Contracts;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture
{
    public class EmployeeRepository : IEmployee
    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee.Id;
        }

        public bool Delete(int id)
        {
            var existing = _dbContext.Employees.Find(id);
            if (existing != null)
            {
                _dbContext.Employees.Remove(existing);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
            
        }

        public Employee Get(int id)
        {
            return _dbContext.Employees.Find(id);
        }

        public List<Employee> GetAll()
        {
            return _dbContext.Employees.ToList();
        }

        public bool Update(int id, Employee employee)
        {
            var existing = _dbContext.Employees.Find(id);
            if (existing != null)
            {
              existing.FirstName = employee.FirstName;
            existing.LastName = employee.LastName;
            existing.Gender = employee.Gender;
            existing.BirtDate = employee.BirtDate;
            _dbContext.Employees.Update(existing);
            _dbContext.SaveChanges();
            return true;
            }
            return false;

        }

    }
}
