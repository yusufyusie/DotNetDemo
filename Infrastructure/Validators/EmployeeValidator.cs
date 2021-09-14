using DataModel;
using DataModel.DTO;
using FluentValidation;
using System.Linq;

namespace Infrastructure.Validators
{
    public class EmployeeValidator:AbstractValidator<CreateEmployeeDto>
    {
        private readonly EmployeeDbContext _dbcontext;
        public EmployeeValidator(EmployeeDbContext dbContext)
        {
            _dbcontext= dbContext;
            RuleFor(x => x.FirstName)
                .NotEmpty().NotNull()
                .WithMessage("First name cannot be null")
                .Length(3, 25);

            RuleFor(x => x.LastName)
                .NotEmpty().NotNull()
                .Length(3, 25);

            RuleFor(x => x.DepartmentId).NotEmpty()
                .Must(BeValidDepartmentId)
                .WithMessage("Department Id must be valid") ;

            RuleFor(x => x.Gender)
                .MinimumLength(4)
                .MaximumLength(6)
                .When(x=>x.Gender!=null);
        }

        private bool BeValidDepartmentId(int departmentId)
        {
            return _dbcontext.Departments.Where(x => x.DepartmentId == departmentId).Any();
        }
    }
}
