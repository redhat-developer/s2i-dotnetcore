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
            CreateMap<UserRole, UserRoleViewModel>();

            CreateMap<Role, RoleViewModel>();
            CreateMap<RolePermission, RolePermissionViewModel>();
            CreateMap<Permission, PermissionViewModel>();

            CreateMap<GroupMembership, GroupMembershipViewModel>(); //to be removed
            CreateMap<Group, GroupViewModel>(); //to be removed

            CreateMap<History, HistoryViewModel>(); //AffectedEntityId must be manually assigned
            CreateMap<UserFavourite, UserFavouriteViewModel>();
            CreateMap<Notification, NotificationViewModel>();
            CreateMap<SchoolBusOwner, SchoolBusOwnerViewModel>();
        }
    }
}
