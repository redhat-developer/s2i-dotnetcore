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

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// A join table that provides allows each user to have any number of Roles in the system.  At login time the user is given the sum of the permissions of the roles assigned to that user.
    /// </summary>
        [MetaDataExtension (Description = "A join table that provides allows each user to have any number of Roles in the system.  At login time the user is given the sum of the permissions of the roles assigned to that user.")]

    public partial class UserRole : AuditableEntity,  IEquatable<UserRole>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public UserRole()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRole" /> class.
        /// </summary>
        /// <param name="Id">A system-generated unique identifier for a UserRole (required).</param>
        /// <param name="EffectiveDate">The date on which the user was given the related role. (required).</param>
        /// <param name="ExpiryDate">The date on which a role previously assigned to a user was removed from that user..</param>
        /// <param name="Role">Role.</param>
        public UserRole(int Id, DateTime EffectiveDate, DateTime? ExpiryDate = null, Role Role = null)
        {   
            this.Id = Id;
            this.EffectiveDate = EffectiveDate;

            this.ExpiryDate = ExpiryDate;
            this.Role = Role;
        }

        /// <summary>
        /// A system-generated unique identifier for a UserRole
        /// </summary>
        /// <value>A system-generated unique identifier for a UserRole</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for a UserRole")]
        public int Id { get; set; }
        
        /// <summary>
        /// The date on which the user was given the related role.
        /// </summary>
        /// <value>The date on which the user was given the related role.</value>
        [MetaDataExtension (Description = "The date on which the user was given the related role.")]
        public DateTime EffectiveDate { get; set; }
        
        /// <summary>
        /// The date on which a role previously assigned to a user was removed from that user.
        /// </summary>
        /// <value>The date on which a role previously assigned to a user was removed from that user.</value>
        [MetaDataExtension (Description = "The date on which a role previously assigned to a user was removed from that user.")]
        public DateTime? ExpiryDate { get; set; }
        
        /// <summary>
        /// Gets or Sets Role
        /// </summary>
        public Role Role { get; set; }
        
        /// <summary>
        /// Foreign key for Role 
        /// </summary>       
        [ForeignKey("Role")]
        public int? RoleRefId { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserRole {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  EffectiveDate: ").Append(EffectiveDate).Append("\n");
            sb.Append("  ExpiryDate: ").Append(ExpiryDate).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
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
            return Equals((UserRole)obj);
        }

        /// <summary>
        /// Returns true if UserRole instances are equal
        /// </summary>
        /// <param name="other">Instance of UserRole to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserRole other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.EffectiveDate == other.EffectiveDate ||
                    this.EffectiveDate != null &&
                    this.EffectiveDate.Equals(other.EffectiveDate)
                ) &&                 
                (
                    this.ExpiryDate == other.ExpiryDate ||
                    this.ExpiryDate != null &&
                    this.ExpiryDate.Equals(other.ExpiryDate)
                ) &&                 
                (
                    this.Role == other.Role ||
                    this.Role != null &&
                    this.Role.Equals(other.Role)
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
                if (this.EffectiveDate != null)
                {
                    hash = hash * 59 + this.EffectiveDate.GetHashCode();
                }                if (this.ExpiryDate != null)
                {
                    hash = hash * 59 + this.ExpiryDate.GetHashCode();
                }                
                                   
                if (this.Role != null)
                {
                    hash = hash * 59 + this.Role.GetHashCode();
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
        public static bool operator ==(UserRole left, UserRole right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(UserRole left, UserRole right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
