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

namespace SchoolBusAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CurrentUserViewModel : IEquatable<CurrentUserViewModel>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public CurrentUserViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentUserViewModel" /> class.
        /// </summary>
        /// <param name="Id">Id.</param>
        /// <param name="GivenName">GivenName.</param>
        /// <param name="Surname">Surname.</param>
        /// <param name="Email">Email.</param>
        /// <param name="Active">Active.</param>
        /// <param name="UserRoles">UserRoles.</param>
        /// <param name="GroupMemberships">GroupMemberships.</param>
        /// <param name="District">The District to which this User is affliated..</param>
        /// <param name="OverdueInspections">OverdueInspections.</param>
        /// <param name="ScheduledInspections">ScheduledInspections.</param>
        /// <param name="DueNextMonthInspections">DueNextMonthInspections.</param>
        /// <param name="ReInspections">ReInspections.</param>
        public CurrentUserViewModel(int? Id = null, string GivenName = null, string Surname = null, string Email = null, bool? Active = null, List<UserRole> UserRoles = null, List<GroupMembership> GroupMemberships = null, District District = null, int? OverdueInspections = null, int? ScheduledInspections = null, int? DueNextMonthInspections = null, int? ReInspections = null)
        {               this.Id = Id;
            this.GivenName = GivenName;
            this.Surname = Surname;
            this.Email = Email;
            this.Active = Active;
            this.UserRoles = UserRoles;
            this.GroupMemberships = GroupMemberships;
            this.District = District;
            this.OverdueInspections = OverdueInspections;
            this.ScheduledInspections = ScheduledInspections;
            this.DueNextMonthInspections = DueNextMonthInspections;
            this.ReInspections = ReInspections;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets GivenName
        /// </summary>
        [DataMember(Name="givenName")]
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or Sets Surname
        /// </summary>
        [DataMember(Name="surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name="email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Active
        /// </summary>
        [DataMember(Name="active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or Sets UserRoles
        /// </summary>
        [DataMember(Name="userRoles")]
        public List<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Gets or Sets GroupMemberships
        /// </summary>
        [DataMember(Name="groupMemberships")]
        public List<GroupMembership> GroupMemberships { get; set; }

        /// <summary>
        /// The District to which this User is affliated.
        /// </summary>
        /// <value>The District to which this User is affliated.</value>
        [DataMember(Name="district")]
        [MetaDataExtension (Description = "The District to which this User is affliated.")]
        public District District { get; set; }

        /// <summary>
        /// Gets or Sets OverdueInspections
        /// </summary>
        [DataMember(Name="overdueInspections")]
        public int? OverdueInspections { get; set; }

        /// <summary>
        /// Gets or Sets ScheduledInspections
        /// </summary>
        [DataMember(Name="scheduledInspections")]
        public int? ScheduledInspections { get; set; }

        /// <summary>
        /// Gets or Sets DueNextMonthInspections
        /// </summary>
        [DataMember(Name="dueNextMonthInspections")]
        public int? DueNextMonthInspections { get; set; }

        /// <summary>
        /// Gets or Sets ReInspections
        /// </summary>
        [DataMember(Name="reInspections")]
        public int? ReInspections { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CurrentUserViewModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  GivenName: ").Append(GivenName).Append("\n");
            sb.Append("  Surname: ").Append(Surname).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  UserRoles: ").Append(UserRoles).Append("\n");
            sb.Append("  GroupMemberships: ").Append(GroupMemberships).Append("\n");
            sb.Append("  District: ").Append(District).Append("\n");
            sb.Append("  OverdueInspections: ").Append(OverdueInspections).Append("\n");
            sb.Append("  ScheduledInspections: ").Append(ScheduledInspections).Append("\n");
            sb.Append("  DueNextMonthInspections: ").Append(DueNextMonthInspections).Append("\n");
            sb.Append("  ReInspections: ").Append(ReInspections).Append("\n");
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
            return Equals((CurrentUserViewModel)obj);
        }

        /// <summary>
        /// Returns true if CurrentUserViewModel instances are equal
        /// </summary>
        /// <param name="other">Instance of CurrentUserViewModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CurrentUserViewModel other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
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
                    this.Email == other.Email ||
                    this.Email != null &&
                    this.Email.Equals(other.Email)
                ) &&                 
                (
                    this.Active == other.Active ||
                    this.Active != null &&
                    this.Active.Equals(other.Active)
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
                ) &&                 
                (
                    this.District == other.District ||
                    this.District != null &&
                    this.District.Equals(other.District)
                ) &&                 
                (
                    this.OverdueInspections == other.OverdueInspections ||
                    this.OverdueInspections != null &&
                    this.OverdueInspections.Equals(other.OverdueInspections)
                ) &&                 
                (
                    this.ScheduledInspections == other.ScheduledInspections ||
                    this.ScheduledInspections != null &&
                    this.ScheduledInspections.Equals(other.ScheduledInspections)
                ) &&                 
                (
                    this.DueNextMonthInspections == other.DueNextMonthInspections ||
                    this.DueNextMonthInspections != null &&
                    this.DueNextMonthInspections.Equals(other.DueNextMonthInspections)
                ) &&                 
                (
                    this.ReInspections == other.ReInspections ||
                    this.ReInspections != null &&
                    this.ReInspections.Equals(other.ReInspections)
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
                if (this.Id != null)
                {
                    hash = hash * 59 + this.Id.GetHashCode();
                }                
                                if (this.GivenName != null)
                {
                    hash = hash * 59 + this.GivenName.GetHashCode();
                }                
                                if (this.Surname != null)
                {
                    hash = hash * 59 + this.Surname.GetHashCode();
                }                
                                if (this.Email != null)
                {
                    hash = hash * 59 + this.Email.GetHashCode();
                }                
                                if (this.Active != null)
                {
                    hash = hash * 59 + this.Active.GetHashCode();
                }                
                                   
                if (this.UserRoles != null)
                {
                    hash = hash * 59 + this.UserRoles.GetHashCode();
                }                   
                if (this.GroupMemberships != null)
                {
                    hash = hash * 59 + this.GroupMemberships.GetHashCode();
                }                   
                if (this.District != null)
                {
                    hash = hash * 59 + this.District.GetHashCode();
                }                if (this.OverdueInspections != null)
                {
                    hash = hash * 59 + this.OverdueInspections.GetHashCode();
                }                
                                if (this.ScheduledInspections != null)
                {
                    hash = hash * 59 + this.ScheduledInspections.GetHashCode();
                }                
                                if (this.DueNextMonthInspections != null)
                {
                    hash = hash * 59 + this.DueNextMonthInspections.GetHashCode();
                }                
                                if (this.ReInspections != null)
                {
                    hash = hash * 59 + this.ReInspections.GetHashCode();
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
        public static bool operator ==(CurrentUserViewModel left, CurrentUserViewModel right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(CurrentUserViewModel left, CurrentUserViewModel right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
