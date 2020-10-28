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

            CreateMap<UserViewModel, User>()
                .ForMember(x => x.UserRoles, opt => opt.Ignore())
                .ForMember(x => x.District, opt => opt.Ignore());

            CreateMap<DistrictViewModel, District>();
            CreateMap<NoteViewModel, Note>();
        }
    }
}
