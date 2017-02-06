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
    /// Information about the users of the system.
    /// </summary>
        [MetaDataExtension (Description = "Information about the users of the system.")]

    public partial class User : IEquatable<User>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public User()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="Id">A system-generated unique identifier for a User (required).</param>
        /// <param name="GivenName">Given name of the user. (required).</param>
        /// <param name="Surname">Surname of the user. (required).</param>
        /// <param name="Active">A flag indicating the User is active in the system. Set false to remove access to the system for the user. (required).</param>
        /// <param name="Initials">Initials of the user, to be presented where screen space is at a premium..</param>
        /// <param name="Email">The email address of the user in the system..</param>
        /// <param name="SmUserId">Security Manager User ID.</param>
        /// <param name="Guid">The GUID unique to the user as provided by the authentication system. In this case, authentication is done by Siteminder and the GUID uniquely identifies the user within the user directories managed by Siteminder - e.g. IDIR and BCeID. The GUID is equivalent to the IDIR Id, but is guaranteed unique to a person, while the IDIR ID is not - IDIR IDs can be recycled..</param>
        /// <param name="SmAuthorizationDirectory">The user directory service used by Siteminder to authenticate the user - usually IDIR or BCeID..</param>
        /// <param name="UserRoles">UserRoles.</param>
        /// <param name="GroupMemberships">GroupMemberships.</param>
        public User(int Id, string GivenName, string Surname, bool Active, string Initials = null, string Email = null, string SmUserId = null, string Guid = null, string SmAuthorizationDirectory = null, List<UserRole> UserRoles = null, List<GroupMembership> GroupMemberships = null)
        {   
            this.Id = Id;
            this.GivenName = GivenName;
            this.Surname = Surname;
            this.Active = Active;



            this.Initials = Initials;
            this.Email = Email;
            this.SmUserId = SmUserId;
            this.Guid = Guid;
            this.SmAuthorizationDirectory = SmAuthorizationDirectory;
            this.UserRoles = UserRoles;
            this.GroupMemberships = GroupMemberships;
        }

        /// <summary>
        /// A system-generated unique identifier for a User
        /// </summary>
        /// <value>A system-generated unique identifier for a User</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for a User")]
        public int Id { get; set; }
        
        /// <summary>
        /// Given name of the user.
        /// </summary>
        /// <value>Given name of the user.</value>
        [MetaDataExtension (Description = "Given name of the user.")]
        [MaxLength(255)]
        
        public string GivenName { get; set; }
        
        /// <summary>
        /// Surname of the user.
        /// </summary>
        /// <value>Surname of the user.</value>
        [MetaDataExtension (Description = "Surname of the user.")]
        [MaxLength(50)]
        
        public string Surname { get; set; }
        
        /// <summary>
        /// A flag indicating the User is active in the system. Set false to remove access to the system for the user.
        /// </summary>
        /// <value>A flag indicating the User is active in the system. Set false to remove access to the system for the user.</value>
        [MetaDataExtension (Description = "A flag indicating the User is active in the system. Set false to remove access to the system for the user.")]
        public bool Active { get; set; }
        
        /// <summary>
        /// Initials of the user, to be presented where screen space is at a premium.
        /// </summary>
        /// <value>Initials of the user, to be presented where screen space is at a premium.</value>
        [MetaDataExtension (Description = "Initials of the user, to be presented where screen space is at a premium.")]
        [MaxLength(10)]
        
        public string Initials { get; set; }
        
        /// <summary>
        /// The email address of the user in the system.
        /// </summary>
        /// <value>The email address of the user in the system.</value>
        [MetaDataExtension (Description = "The email address of the user in the system.")]
        [MaxLength(255)]
        
        public string Email { get; set; }
        
        /// <summary>
        /// Security Manager User ID
        /// </summary>
        /// <value>Security Manager User ID</value>
        [MetaDataExtension (Description = "Security Manager User ID")]
        [MaxLength(255)]
        
        public string SmUserId { get; set; }
        
        /// <summary>
        /// The GUID unique to the user as provided by the authentication system. In this case, authentication is done by Siteminder and the GUID uniquely identifies the user within the user directories managed by Siteminder - e.g. IDIR and BCeID. The GUID is equivalent to the IDIR Id, but is guaranteed unique to a person, while the IDIR ID is not - IDIR IDs can be recycled.
        /// </summary>
        /// <value>The GUID unique to the user as provided by the authentication system. In this case, authentication is done by Siteminder and the GUID uniquely identifies the user within the user directories managed by Siteminder - e.g. IDIR and BCeID. The GUID is equivalent to the IDIR Id, but is guaranteed unique to a person, while the IDIR ID is not - IDIR IDs can be recycled.</value>
        [MetaDataExtension (Description = "The GUID unique to the user as provided by the authentication system. In this case, authentication is done by Siteminder and the GUID uniquely identifies the user within the user directories managed by Siteminder - e.g. IDIR and BCeID. The GUID is equivalent to the IDIR Id, but is guaranteed unique to a person, while the IDIR ID is not - IDIR IDs can be recycled.")]
        [MaxLength(255)]
        
        public string Guid { get; set; }
        
        /// <summary>
        /// The user directory service used by Siteminder to authenticate the user - usually IDIR or BCeID.
        /// </summary>
        /// <value>The user directory service used by Siteminder to authenticate the user - usually IDIR or BCeID.</value>
        [MetaDataExtension (Description = "The user directory service used by Siteminder to authenticate the user - usually IDIR or BCeID.")]
        [MaxLength(255)]
        
        public string SmAuthorizationDirectory { get; set; }
        
        /// <summary>
        /// Gets or Sets UserRoles
        /// </summary>
        public List<UserRole> UserRoles { get; set; }
        
        /// <summary>
        /// Gets or Sets GroupMemberships
        /// </summary>
        public List<GroupMembership> GroupMemberships { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  GivenName: ").Append(GivenName).Append("\n");
            sb.Append("  Surname: ").Append(Surname).Append("\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  Initials: ").Append(Initials).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  SmUserId: ").Append(SmUserId).Append("\n");
            sb.Append("  Guid: ").Append(Guid).Append("\n");
            sb.Append("  SmAuthorizationDirectory: ").Append(SmAuthorizationDirectory).Append("\n");
            sb.Append("  UserRoles: ").Append(UserRoles).Append("\n");
            sb.Append("  GroupMemberships: ").Append(GroupMemberships).Append("\n");
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
            return Equals((User)obj);
        }

        /// <summary>
        /// Returns true if User instances are equal
        /// </summary>
        /// <param name="other">Instance of User to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(User other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.GivenName == other.GivenName ||
                    this.GivenName != null &&
                    this.GivenName.Equals(other.GivenName)
                ) &&                 
                (
                    this.Surname == other.Surname ||
                    this.Surname != null &&
                    this.Surname.Equals(other.Surname)
                ) &&                 
                (
                    this.Active == other.Active ||
                    this.Active.Equals(other.Active)
                ) &&                 
                (
                    this.Initials == other.Initials ||
                    this.Initials != null &&
                    this.Initials.Equals(other.Initials)
                ) &&                 
                (
                    this.Email == other.Email ||
                    this.Email != null &&
                    this.Email.Equals(other.Email)
                ) &&                 
                (
                    this.SmUserId == other.SmUserId ||
                    this.SmUserId != null &&
                    this.SmUserId.Equals(other.SmUserId)
                ) &&                 
                (
                    this.Guid == other.Guid ||
                    this.Guid != null &&
                    this.Guid.Equals(other.Guid)
                ) &&                 
                (
                    this.SmAuthorizationDirectory == other.SmAuthorizationDirectory ||
                    this.SmAuthorizationDirectory != null &&
                    this.SmAuthorizationDirectory.Equals(other.SmAuthorizationDirectory)
                ) && 
                (
                    this.UserRoles == other.UserRoles ||
                    this.UserRoles != null &&
                    this.UserRoles.SequenceEqual(other.UserRoles)
                ) && 
                (
                    this.GroupMemberships == other.GroupMemberships ||
                    this.GroupMemberships != null &&
                    this.GroupMemberships.SequenceEqual(other.GroupMemberships)
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
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.GivenName != null)
                {
                    hash = hash * 59 + this.GivenName.GetHashCode();
                }                
                                if (this.Surname != null)
                {
                    hash = hash * 59 + this.Surname.GetHashCode();
                }                
                                   
                hash = hash * 59 + this.Active.GetHashCode();
                                if (this.Initials != null)
                {
                    hash = hash * 59 + this.Initials.GetHashCode();
                }                
                                if (this.Email != null)
                {
                    hash = hash * 59 + this.Email.GetHashCode();
                }                
                                if (this.SmUserId != null)
                {
                    hash = hash * 59 + this.SmUserId.GetHashCode();
                }                
                                if (this.Guid != null)
                {
                    hash = hash * 59 + this.Guid.GetHashCode();
                }                
                                if (this.SmAuthorizationDirectory != null)
                {
                    hash = hash * 59 + this.SmAuthorizationDirectory.GetHashCode();
                }                
                                   
                if (this.UserRoles != null)
                {
                    hash = hash * 59 + this.UserRoles.GetHashCode();
                }                   
                if (this.GroupMemberships != null)
                {
                    hash = hash * 59 + this.GroupMemberships.GetHashCode();
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
        public static bool operator ==(User left, User right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(User left, User right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
