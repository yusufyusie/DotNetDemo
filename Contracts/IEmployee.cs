using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEmployee
    {
        public int Create(Employee Employee);
        public List<Employee> GetAll();
        public Employee Get(int id);
        public bool Update(int id,Employee employee);
        public bool Delete(int id);
    }
}
