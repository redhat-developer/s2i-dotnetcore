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
        /// <param name="GivenName">GivenName.</param>
        /// <param name="Surname">Surname.</param>
        /// <param name="FullName">FullName.</param>
        /// <param name="DistrictName">DistrictName.</param>
        /// <param name="OverdueInspections">OverdueInspections.</param>
        /// <param name="ScheduledInspections">ScheduledInspections.</param>
        /// <param name="DueNextMonthInspections">DueNextMonthInspections.</param>
        public CurrentUserViewModel(string GivenName = null, string Surname = null, string FullName = null, string DistrictName = null, int? OverdueInspections = null, int? ScheduledInspections = null, int? DueNextMonthInspections = null)
        {
            this.GivenName = GivenName;
            this.Surname = Surname;
            this.FullName = FullName;
            this.DistrictName = DistrictName;
            this.OverdueInspections = OverdueInspections;
            this.ScheduledInspections = ScheduledInspections;
            this.DueNextMonthInspections = DueNextMonthInspections;
            
        }

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
        /// Gets or Sets FullName
        /// </summary>
        [DataMember(Name="fullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or Sets DistrictName
        /// </summary>
        [DataMember(Name="districtName")]
        public string DistrictName { get; set; }

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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CurrentUserViewModel {\n");
            sb.Append("  GivenName: ").Append(GivenName).Append("\n");
            sb.Append("  Surname: ").Append(Surname).Append("\n");
            sb.Append("  FullName: ").Append(FullName).Append("\n");
            sb.Append("  DistrictName: ").Append(DistrictName).Append("\n");
            sb.Append("  OverdueInspections: ").Append(OverdueInspections).Append("\n");
            sb.Append("  ScheduledInspections: ").Append(ScheduledInspections).Append("\n");
            sb.Append("  DueNextMonthInspections: ").Append(DueNextMonthInspections).Append("\n");
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
                    this.FullName == other.FullName ||
                    this.FullName != null &&
                    this.FullName.Equals(other.FullName)
                ) && 
                (
                    this.DistrictName == other.DistrictName ||
                    this.DistrictName != null &&
                    this.DistrictName.Equals(other.DistrictName)
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
                if (this.GivenName != null)
                {
                    hash = hash * 59 + this.GivenName.GetHashCode();
                }
                if (this.Surname != null)
                {
                    hash = hash * 59 + this.Surname.GetHashCode();
                }
                if (this.FullName != null)
                {
                    hash = hash * 59 + this.FullName.GetHashCode();
                }
                if (this.DistrictName != null)
                {
                    hash = hash * 59 + this.DistrictName.GetHashCode();
                }
                if (this.OverdueInspections != null)
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
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(CurrentUserViewModel left, CurrentUserViewModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CurrentUserViewModel left, CurrentUserViewModel right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
