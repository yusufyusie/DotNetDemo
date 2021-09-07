using DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
  public interface IEmployee
    {
        public int Create(Employee employee);
        public List<Employee> GetAll();
        public Employee Get(int id);
        public Task<bool> Update(int id,Employee employee);
        public bool Delete(int id);
    }
}
