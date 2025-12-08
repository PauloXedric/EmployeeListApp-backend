using AutoMapper;
using EmployeeListApp.Entities;
using EmployeeListApp.Models.EmployeeModels;

namespace EmployeeListApp.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeEntity, ReadEmployeeModel>();
            CreateMap<AddEmployeeModel, EmployeeEntity>();
            CreateMap<UpdateEmployeeModel, EmployeeEntity>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
