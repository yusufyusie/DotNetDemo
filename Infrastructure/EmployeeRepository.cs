using Contracts;
using DataModel;
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
            _dbContext = dbContext;
            _employeeValidator = new EmployeeValidator(_dbContext);   
        }
        public int Create(Employee employee)
        {
            var result= _employeeValidator.Validate(employee);
            if (!result.IsValid)
                return 0;
           _dbContext.Add(employee);
           _dbContext.SaveChanges();
           return employee.Id;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Employee Get(int id)
        {
          //  return _dbContext.Employees.Where(x=>x.Id==id).FirstOrDefault();
          return _dbContext.Employees.FirstOrDefault(x => x.Id == id);

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
