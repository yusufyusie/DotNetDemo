using DataModel;
using DataModel.Entity;
using FluentValidation;
using System;
using System.Linq;

namespace Infrastructure.Validators
{
    public  class DepartmentValidator : AbstractValidator<Department>
    {
        private readonly EmployeeDbContext _dbcontext;
        public DepartmentValidator()
        {

        }

        public DepartmentValidator(EmployeeDbContext dbContext)
        {
            _dbcontext = dbContext;
            RuleFor(x => x.DepartmentName).NotEmpty().NotNull()
                .WithMessage("Department name cannot be null").Length(3, 25)
                .Must(BeUniqueName).WithMessage("Department name cannot be duplicated");
           
        }

        private bool BeUniqueName(string name)
        {
           return _dbcontext.Departments.Where(x=>x.DepartmentName==name).Any();
        }
    }
}
