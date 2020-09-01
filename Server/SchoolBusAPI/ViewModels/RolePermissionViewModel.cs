/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System;
using System.Runtime.Serialization;

namespace SchoolBusAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class RolePermissionViewModel
    {
        /// <summary>
        /// Gets or Sets RoleId
        /// </summary>
        [DataMember(Name="roleId")]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or Sets PermissionId
        /// </summary>
        [DataMember(Name="permissionId")]
        public int PermissionId { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id")]
        public int? Id { get; set; }

        [DataMember(Name="permission")]
        public PermissionViewModel Permission { get; set; }

        /// <summary>
        /// Gets or Sets ExpiryDate
        /// </summary>
        [DataMember(Name = "expiryDate")]
        public DateTime? ExpiryDate { get; set; }

    }
}
