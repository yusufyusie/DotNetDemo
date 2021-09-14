namespace DataModel.Entity
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public virtual Employee VEmployee { get; set; }
    }
}
