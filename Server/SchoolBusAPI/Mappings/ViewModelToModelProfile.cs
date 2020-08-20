using AutoMapper;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;

namespace SchoolBusAPI.Mappings
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            CreateMap<PermissionViewModel, Permission>();
            CreateMap<RoleViewModel, Role>();

        }
    }
}
