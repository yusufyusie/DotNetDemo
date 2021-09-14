using DataModel.common;
using DataModel.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDepartment

    {
        public ResponseModel<Department> Create(Department department);  
        public ResponseModel<Department> Update(int id,Department department);        
        public ResponseModel<Department> GetAll();
        public ResponseModel<Department> Get(int id);  
        public ResponseModel<Department> Delete(int id);
        public Task<List<Employee>> GetEmployeesByDepartment(int departmentId);
        public Task<Employee> GetEmployeeByDepartment(int departmentId, int employeeId);
       
    }
}
