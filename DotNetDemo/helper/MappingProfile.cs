using AutoMapper;
using DataModel.DTO;
using DataModel.Entity;

namespace API.helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, CreateEmployeeDto>();
        }
    }
}
