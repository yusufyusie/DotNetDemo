using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IDepartment
    {
        public int Create(Department Department);
        public List<Department> GetAll();
        public Department Get(int id);
        public bool Update(int id, Department department);
        public bool Delete(int id);
    }
}
