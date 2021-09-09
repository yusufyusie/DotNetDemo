using System;

namespace DataModel
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public DateTimeOffset BirtDate{ get; set; }
        public int DepartmentId { get; set; }
    }
}
