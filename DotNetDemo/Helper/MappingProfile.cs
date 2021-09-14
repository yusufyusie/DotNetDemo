using AutoMapper;
using DataModel.DTO;
using DataModel.Entity;

namespace API.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, CreateEmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
        }
    }
}
