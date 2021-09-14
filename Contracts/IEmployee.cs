using DataModel.common;
using DataModel.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEmployee
    {
        public ResponseModel<Employee> Create(Employee employee);
        public ResponseModel<Employee> GetAll();
        public ResponseModel<Employee> Get(int id);
        public Task<ResponseModel<Employee>> Update(int id,Employee employee);
        public ResponseModel<Employee> Delete(int id);
    }
}
