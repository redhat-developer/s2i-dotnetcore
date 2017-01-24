using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;

namespace SchoolBusAPI.Mappings
{
    public static class MappingExtensions
    {
        public static UserViewModel ToViewModel(this User model)
        {
            var dto = new UserViewModel();
            dto.Active = model.Active;
            dto.Email = model.Email;
            dto.GivenName = model.GivenName;
            dto.Initials = model.Initials;
            dto.Surname = model.Surname;
            dto.Id = model.Id;
            return dto;
        }

        public static UserRoleViewModel ToViewModel(this UserRole model)
        {
            var dto = new UserRoleViewModel();
            dto.EffectiveDate = model.EffectiveDate;
            dto.ExpiryDate = model.ExpiryDate;
            dto.RoleId = model.Role.Id;
            dto.UserId = model.User.Id;
            dto.Id = model.Id;
            return dto;
        }

        public static RoleViewModel ToViewModel(this Role model)
        {
            var dto = new RoleViewModel();
            dto.Description = model.Description;
            dto.Name = model.Name;
            dto.Id = model.Id;
            return dto;
        }

        public static RolePermissionViewModel ToViewModel(this RolePermission model)
        {
            var dto = new RolePermissionViewModel();
            if (model.Permission != null)
            {
                dto.PermissionId = model.Permission.Id;
            }                        
            if (model.Role != null)
            {
                dto.RoleId = model.Role.Id;
            }
            dto.Id = model.Id;
            return dto;
        }

        public static PermissionViewModel ToViewModel(this Permission model)
        {
            var dto = new PermissionViewModel();
            dto.Code = model.Code;
            dto.Name = model.Name;
            dto.Description = model.Description;
            return dto;
        }

        public static GroupMembershipViewModel ToViewModel(this GroupMembership model)
        {
            var dto = new GroupMembershipViewModel();
            dto.Active = model.Active;
            dto.GroupId = model.Group.Id;
            dto.UserId = model.User.Id;
            dto.Id = model.Id;
            return dto;
        }

        public static GroupViewModel ToViewModel(this Group model)
        {
            var dto = new GroupViewModel();
            dto.Description = model.Description;
            dto.Name = model.Name;
            dto.Id = model.Id;
            return dto;
        }

        public static UserFavouriteViewModel ToViewModel(this UserFavourite model)
        {
            var dto = new UserFavouriteViewModel();
            dto.Type = model.Type;
            dto.IsDefault = model.IsDefault;
            dto.Name = model.Name;
            dto.Value = model.Value;
            dto.Id = model.Id;
            return dto;
        }

        public static NotificationViewModel ToViewModel(this Notification model)
        {
            var dto = new NotificationViewModel();
            dto.Event2Id = model.Event2.Id;
            dto.EventId = model.Event.Id;
            dto.HasBeenViewed = model.HasBeenViewed;
            dto.IsAllDay = model.IsAllDay;
            dto.IsExpired = model.IsExpired;
            dto.IsWatchNotification = model.IsWatchNotification;
            dto.PriorityCode = model.PriorityCode;
            dto.UserId = model.User.Id;
            dto.Id = model.Id;
            return dto;
        }

        /// <summary>
        /// Converts a SchoolBusOwner to a SchoolBusOwnerViewModel
        /// </summary>
        /// <param name="model">The SchoolBusOwner to convert</param>
        /// <returns>A SchoolBusOwnerViewModel</returns>
        public static SchoolBusOwnerViewModel ToViewModel(this SchoolBusOwner model)
        {
            var dto = new SchoolBusOwnerViewModel();            
            dto.Attachments = model.Attachments;
            dto.Contacts = model.Contacts;
            dto.DateCreated = model.DateCreated;
            dto.District = model.District;
            dto.History = model.History;
            dto.Id = model.Id;
            dto.Name = model.Name;
            dto.PrimaryContact = model.PrimaryContact;
            dto.Status = model.Status;
            return dto;
        }
    }
}
