using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;

namespace SchoolBusAPI.Mappings
{
    /// <summary>
    /// Various routines for converting database models to view models
    /// </summary>
    public static class MappingExtensions
    {
        /// <summary>
        /// Convert User to UserViewModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserViewModel ToViewModel(this User model)
        {
            var dto = new UserViewModel();
            if (model != null)
            {
                dto.Active = model.Active;
                dto.Email = model.Email;
                dto.GivenName = model.GivenName;                
                dto.Surname = model.Surname;
                dto.Id = model.Id;
                dto.District = model.District;
                dto.GroupMemberships = model.GroupMemberships;
                dto.UserRoles = model.UserRoles;
            }            
            return dto;
        }

        /// <summary>
        /// Convert User to CurrentUserViewModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CurrentUserViewModel ToCurrentUserViewModel(this User model)
        {
            var dto = new CurrentUserViewModel();
            if (model != null)
            {
                dto.Email = model.Email;
                dto.GivenName = model.GivenName;
                dto.Surname = model.Surname;
                dto.Id = model.Id;
                dto.District = model.District;
                dto.GroupMemberships = model.GroupMemberships;
                dto.UserRoles = model.UserRoles;
            }
            return dto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserRoleViewModel ToViewModel(this UserRole model)
        {
            var dto = new UserRoleViewModel();
            if (model != null)
            {
                dto.EffectiveDate = model.EffectiveDate;
                dto.ExpiryDate = model.ExpiryDate;
                if (model.Role != null)
                {
                    dto.RoleId = model.Role.Id;
                }                
                dto.Id = model.Id;
            }            
            return dto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static RoleViewModel ToViewModel(this Role model)
        {
            var dto = new RoleViewModel();
            if (model != null)
            {
                dto.Description = model.Description;
                dto.Name = model.Name;
                dto.Id = model.Id;
            }            
            return dto;
        }

        /// <summary>
        /// Convert RolePermission to RolePermissionViewModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static RolePermissionViewModel ToViewModel(this RolePermission model)
        {
            var dto = new RolePermissionViewModel();
            if (model != null)
            {
                if (model.Permission != null)
                {
                    dto.PermissionId = model.Permission.Id;
                }
                if (model.Role != null)
                {
                    dto.RoleId = model.Role.Id;
                }
                dto.Id = model.Id;
            }            
            return dto;
        }

        /// <summary>
        /// Convert Permission to PermissionViewModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PermissionViewModel ToViewModel(this Permission model)
        {
            var dto = new PermissionViewModel();
            if (model != null)
            {
                dto.Code = model.Code;
                dto.Name = model.Name;
                dto.Description = model.Description;
            }            
            return dto;
        }

        /// <summary>
        /// Convert GroupMembership to GroupMembershipViewModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static GroupMembershipViewModel ToViewModel(this GroupMembership model)
        {
            var dto = new GroupMembershipViewModel();
            if (model != null)
            {
                dto.Active = model.Active;
                dto.GroupId = model.Group.Id;
                dto.UserId = model.User.Id;
                dto.Id = model.Id;
            }            
            return dto;
        }

        /// <summary>
        /// Convert Group to GroupViewModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static GroupViewModel ToViewModel(this Group model)
        {
            var dto = new GroupViewModel();
            if (model != null)
            {
                dto.Description = model.Description;
                dto.Name = model.Name;
                dto.Id = model.Id;
            }            
            return dto;
        }

        /// <summary>
        /// Converts UserFavourite to UserFavouriteViewModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserFavouriteViewModel ToViewModel(this UserFavourite model)
        {
            var dto = new UserFavouriteViewModel();
            if (model != null)
            {
                dto.Type = model.Type;
                dto.IsDefault = model.IsDefault;
                dto.Name = model.Name;
                dto.Value = model.Value;
                dto.Id = model.Id;
            }                        
            return dto;
        }

        /// <summary>
        /// Converts Notification to NotificationViewModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static NotificationViewModel ToViewModel(this Notification model)
        {
            var dto = new NotificationViewModel();
            if (model != null)
            {
                dto.Event2Id = model.Event2.Id;
                dto.EventId = model.Event.Id;
                dto.HasBeenViewed = model.HasBeenViewed;
                dto.IsAllDay = model.IsAllDay;
                dto.IsExpired = model.IsExpired;
                dto.IsWatchNotification = model.IsWatchNotification;
                dto.PriorityCode = model.PriorityCode;
                dto.UserId = model.User.Id;
                dto.Id = model.Id;
            }            
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
            if (model != null)
            {
                dto.Attachments = model.Attachments;
                dto.Contacts = model.Contacts;
                dto.DateCreated = model.DateCreated;
                dto.District = model.District;
                dto.History = model.History;
                dto.Id = model.Id;
                dto.Name = model.Name;
                dto.PrimaryContact = model.PrimaryContact;
                dto.Status = model.Status;
            }            
            return dto;
        }
    }
}
