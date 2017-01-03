/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Role
    {
        /// <summary>
        /// Adds a permission to this role instance.
        /// </summary>
        /// <param name="permission">The permission to add.</param>
        public virtual void AddPermission(Permission permission)
        {
            var rolePermission = new RolePermission
            {
                Permission = permission,
                Role = this
            };
            RolePermissions.Add(rolePermission);
        }

        /// <summary>
        /// Removes a permission from this role instance.
        /// </summary>
        /// <param name="permission">The permission to remove.</param>
        public virtual void RemovePermission(Permission permission)
        {
            var permissionToRemove = RolePermissions.FirstOrDefault(x => x.Permission.Code == permission.Code);
            if (permissionToRemove != null)
            {
                RolePermissions.Remove(permissionToRemove);
            }
        }

        /// <summary>
        /// Adds a user to this role instance.
        /// </summary>
        /// <param name="user">The user to add.</param>
        public void AddUser(User user)
        {
            var userRole = new UserRole()
            {
                User = user,
                Role = this
            };
            UserRoles.Add(userRole);
        }

        /// <summary>
        /// Removes a user from this role instance.
        /// </summary>
        /// <param name="user">The user to remove.</param>
        public void RemoveUser(User user)
        {
            var userToRemove = UserRoles.FirstOrDefault(x => x.User.Id == user.Id);
            if (userToRemove != null)
            {
                UserRoles.Remove(userToRemove);
            }
        }
    }
}
