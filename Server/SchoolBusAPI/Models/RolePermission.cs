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
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// The collection of permissions included in a role.
    /// </summary>
        [MetaDataExtension (Description = "The collection of permissions included in a role.")]

    public partial class RolePermission : AuditableEntity, IEquatable<RolePermission>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public RolePermission()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RolePermission" /> class.
        /// </summary>
        /// <param name="Id">A system-generated unique identifier for a RolePermission (required).</param>
        /// <param name="Role">A foreign key reference to the system-generated unique identifier for a Role.</param>
        /// <param name="Permission">A foreign key reference to the system-generated unique identifier for a Permission.</param>
        public RolePermission(int Id, Role Role = null, Permission Permission = null)
        {   
            this.Id = Id;
            this.Role = Role;
            this.Permission = Permission;
        }

        /// <summary>
        /// A system-generated unique identifier for a RolePermission
        /// </summary>
        /// <value>A system-generated unique identifier for a RolePermission</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for a RolePermission")]
        public int Id { get; set; }
        
        /// <summary>
        /// A foreign key reference to the system-generated unique identifier for a Role
        /// </summary>
        /// <value>A foreign key reference to the system-generated unique identifier for a Role</value>
        [MetaDataExtension (Description = "A foreign key reference to the system-generated unique identifier for a Role")]
        public Role Role { get; set; }
        
        /// <summary>
        /// Foreign key for Role 
        /// </summary>   
        [ForeignKey("Role")]
		[JsonIgnore]
		[MetaDataExtension (Description = "A foreign key reference to the system-generated unique identifier for a Role")]
        public int? RoleId { get; set; }
        
        /// <summary>
        /// A foreign key reference to the system-generated unique identifier for a Permission
        /// </summary>
        /// <value>A foreign key reference to the system-generated unique identifier for a Permission</value>
        [MetaDataExtension (Description = "A foreign key reference to the system-generated unique identifier for a Permission")]
        public Permission Permission { get; set; }
        
        /// <summary>
        /// Foreign key for Permission 
        /// </summary>   
        [ForeignKey("Permission")]
		[JsonIgnore]
		[MetaDataExtension (Description = "A foreign key reference to the system-generated unique identifier for a Permission")]
        public int? PermissionId { get; set; }

        /// <summary>
        /// The date on which a permission previously assigned to a role was removed from that role.
        /// </summary>
        /// <value>The date on which a permission previously assigned to a role was removed from that role.</value>
        [MetaDataExtension(Description = "The date on which a permission previously assigned to a role was removed from that role.")]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return ToJson();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) { return false; }
            if (ReferenceEquals(this, obj)) { return true; }
            if (obj.GetType() != GetType()) { return false; }
            return Equals((RolePermission)obj);
        }

        /// <summary>
        /// Returns true if RolePermission instances are equal
        /// </summary>
        /// <param name="other">Instance of RolePermission to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RolePermission other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.Role == other.Role ||
                    this.Role != null &&
                    this.Role.Equals(other.Role)
                ) &&                 
                (
                    this.Permission == other.Permission ||
                    this.Permission != null &&
                    this.Permission.Equals(other.Permission)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks
                                   
                hash = hash * 59 + this.Id.GetHashCode();                   
                if (this.Role != null)
                {
                    hash = hash * 59 + this.Role.GetHashCode();
                }                   
                if (this.Permission != null)
                {
                    hash = hash * 59 + this.Permission.GetHashCode();
                }
                return hash;
            }
        }

        #region Operators
        
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(RolePermission left, RolePermission right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(RolePermission left, RolePermission right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
