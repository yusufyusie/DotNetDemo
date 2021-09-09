using DataModel;
using DataModel.common;

namespace Contracts
{
    public interface IDepartment

    {
        public int Create(Department department);  
        public int Update(int id,Department department);        
        public ResponseModel<Department> GetAll();
        public ResponseModel<Department> Get(int id);  
        public ResponseModel<Department> Delete(int id);
       
    }
}
