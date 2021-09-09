using DataModel;
using FluentValidation;
using System;

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
                .WithMessage("Department name cannot be null").Length(3, 25);
            
            

           
        }

        
    }
}
