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
    public partial class Permission : IEquatable<Permission>
    {
        public const string LOGIN = "LOGIN";
        public const string USER_MANAGEMENT = "USER_MANAGEMENT";
        public const string ROLES_AND_PERMISSIONS = "ROLES_AND_PERMISSIONS";
        public const string ADMIN = "ADMIN";
        public const string RECEIVE_NOTIFICATIONS = "RECEIVE_NOTIFICATIONS";
        public const string ASSIGN_INSPECTORS = "ASSIGN_INSPECTORS";

        public static readonly IEnumerable<Permission> ALL_PERMISSIONS = new List<Permission>
        {
            new Permission
            {
                Code = LOGIN,
                Name = "Login",
                Description = "Permission to login to the application"
            },
            new Permission
            {
                Code = USER_MANAGEMENT,
                Name = "User Management",
                Description = "Gives the user access to the User Management screens"
            },
            new Permission
            {
                Code = ROLES_AND_PERMISSIONS,
                Name = "Roles and Permissions",
                Description = "Gives the user access to the Roles and Permissions screens"
            },
            new Permission
            {
                Code = ADMIN,
                Name = "Admin",
                Description = "Allows the user to perform special administrative tasks."
            },
            new Permission()
            {
                Code = RECEIVE_NOTIFICATIONS,
                Name = "Receive Notifications",
                Description = "Enables the user to receive notifications intended for the user's group."
            },
            new Permission()
            {
                Code = ASSIGN_INSPECTORS,
                Name = "Assign Inspectors",
                Description = "A user granted this permission will be able to assign inspectors."
            },
        };
    }
}
