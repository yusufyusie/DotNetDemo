using DataModel;
using DataModel.common;

namespace Contracts
{
    public interface IDepartment

    {
        public ResponseModel<Department> Create(Department department);  
        public ResponseModel<Department> Update(int id,Department department);        
        public ResponseModel<Department> GetAll();
        public ResponseModel<Department> Get(int id);  
        public ResponseModel<Department> Delete(int id);
       
    }
}
