using AutoMapper;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;

namespace SchoolBusAPI.Mappings
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<Attachment, AttachmentViewModel>();
            
            CreateMap<User, UserViewModel>();
            CreateMap<User, CurrentUserViewModel>();
            CreateMap<User, InspectorViewModel>();
            CreateMap<User, UserListViewModel>();

            CreateMap<District, DistrictViewModel>();

            CreateMap<UserRole, UserRoleViewModel>();

            CreateMap<Role, RoleViewModel>();
            
            CreateMap<RolePermission, RolePermissionViewModel>();
            
            CreateMap<Permission, PermissionViewModel>();

            CreateMap<History, HistoryViewModel>(); //AffectedEntityId must be manually assigned
            
            CreateMap<UserFavourite, UserFavouriteViewModel>();
            
            CreateMap<Notification, NotificationViewModel>();
            
            CreateMap<SchoolBusOwner, SchoolBusOwnerViewModel>();

            CreateMap<CCWNotification, CCWNotificationViewModel>()
                .ForMember(x => x.DateDetected, opt => opt.MapFrom(x => x.CreateTimestamp))
                .ForMember(x => x.SchoolBusRegNum, opt => opt.MapFrom(x => x.SchoolBus.ICBCRegistrationNumber))
                .ForMember(x => x.SchoolBusOwnerName, opt => opt.MapFrom(x => x.SchoolBus.SchoolBusOwner.Name))
                .ForMember(x => x.SchoolBusOwnerId, opt => opt.MapFrom(x => x.SchoolBus.SchoolBusOwner.Id))
                .ForMember(x => x.InspectorId, opt => opt.MapFrom(x => x.SchoolBus.Inspector.Id));

            CreateMap<CCWNotificationDetail, CCWNotificationDetailViewModel>();
            CreateMap<Note, NoteViewModel>();
        }
    }
}
