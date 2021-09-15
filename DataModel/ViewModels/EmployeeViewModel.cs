using System;

namespace DataModel.ViewModels
{
   public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset? BirthDate { get; set; }
        public string DepartmentName { get; set; }
    }
}
