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

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// 
    /// </summary>



    public partial class SchoolBusOwner : IEquatable<SchoolBusOwner>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public SchoolBusOwner()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolBusOwner" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="Name">The name of the School Bus owner as defined by the user/Inspector. Not tied to the ICBC or NSC names, but whatever is most useful for the Inspectors..</param>
        /// <param name="Status">Status of the School Bus owner - enumerated value Active, Archived.</param>
        /// <param name="DateCreated">The date-time of the creation of the record from the audit fields. Since this might be surfaced in the API, adding it to the definition..</param>
        /// <param name="PrimaryContact">Link to the designated Primary Contact for the Inspector to the School Bus Owner organization..</param>
        /// <param name="ServiceArea">The District to which this School Bus is affliated..</param>
        /// <param name="NextInspectionDate">The calculated next inspection date from across the School Buses associated with this School Bus Owner.</param>
        /// <param name="NumberOfBuses">The calculated count of the number of School Buses associated with this School Bus Owner.</param>
        /// <param name="Contacts">Contacts.</param>
        public SchoolBusOwner(int Id, string Name = null, string Status = null, DateTime? DateCreated = null, SchoolBusOwnerContact PrimaryContact = null, ServiceArea ServiceArea = null, DateTime? NextInspectionDate = null, int? NumberOfBuses = null, List<SchoolBusOwnerContact> Contacts = null)
        {
            
            this.Id = Id;
            this.Name = Name;
            this.Status = Status;
            this.DateCreated = DateCreated;
            this.PrimaryContact = PrimaryContact;
            this.ServiceArea = ServiceArea;
            this.NextInspectionDate = NextInspectionDate;
            this.NumberOfBuses = NumberOfBuses;
            this.Contacts = Contacts;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the School Bus owner as defined by the user/Inspector. Not tied to the ICBC or NSC names, but whatever is most useful for the Inspectors.
        /// </summary>
        /// <value>The name of the School Bus owner as defined by the user/Inspector. Not tied to the ICBC or NSC names, but whatever is most useful for the Inspectors.</value>
        [MetaDataExtension (Description = "The name of the School Bus owner as defined by the user/Inspector. Not tied to the ICBC or NSC names, but whatever is most useful for the Inspectors.")]
        public string Name { get; set; }

        /// <summary>
        /// Status of the School Bus owner - enumerated value Active, Archived
        /// </summary>
        /// <value>Status of the School Bus owner - enumerated value Active, Archived</value>
        [MetaDataExtension (Description = "Status of the School Bus owner - enumerated value Active, Archived")]
        public string Status { get; set; }

        /// <summary>
        /// The date-time of the creation of the record from the audit fields. Since this might be surfaced in the API, adding it to the definition.
        /// </summary>
        /// <value>The date-time of the creation of the record from the audit fields. Since this might be surfaced in the API, adding it to the definition.</value>
        [MetaDataExtension (Description = "The date-time of the creation of the record from the audit fields. Since this might be surfaced in the API, adding it to the definition.")]
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Link to the designated Primary Contact for the Inspector to the School Bus Owner organization.
        /// </summary>
        /// <value>Link to the designated Primary Contact for the Inspector to the School Bus Owner organization.</value>
        [MetaDataExtension (Description = "Link to the designated Primary Contact for the Inspector to the School Bus Owner organization.")]
        public SchoolBusOwnerContact PrimaryContact { get; set; }

        [ForeignKey("PrimaryContact")]
        public int? PrimaryContactRefId { get; set; }

        /// <summary>
        /// The District to which this School Bus is affliated.
        /// </summary>
        /// <value>The District to which this School Bus is affliated.</value>
        [MetaDataExtension (Description = "The District to which this School Bus is affliated.")]
        public ServiceArea ServiceArea { get; set; }

        [ForeignKey("ServiceArea")]
        public int? ServiceAreaRefId { get; set; }

        /// <summary>
        /// The calculated next inspection date from across the School Buses associated with this School Bus Owner
        /// </summary>
        /// <value>The calculated next inspection date from across the School Buses associated with this School Bus Owner</value>
        [MetaDataExtension (Description = "The calculated next inspection date from across the School Buses associated with this School Bus Owner")]
        public DateTime? NextInspectionDate { get; set; }

        /// <summary>
        /// The calculated count of the number of School Buses associated with this School Bus Owner
        /// </summary>
        /// <value>The calculated count of the number of School Buses associated with this School Bus Owner</value>
        [MetaDataExtension (Description = "The calculated count of the number of School Buses associated with this School Bus Owner")]
        public int? NumberOfBuses { get; set; }

        /// <summary>
        /// Gets or Sets Contacts
        /// </summary>
        public List<SchoolBusOwnerContact> Contacts { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchoolBusOwner {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  DateCreated: ").Append(DateCreated).Append("\n");
            sb.Append("  PrimaryContact: ").Append(PrimaryContact).Append("\n");
            sb.Append("  ServiceArea: ").Append(ServiceArea).Append("\n");
            sb.Append("  NextInspectionDate: ").Append(NextInspectionDate).Append("\n");
            sb.Append("  NumberOfBuses: ").Append(NumberOfBuses).Append("\n");
            sb.Append("  Contacts: ").Append(Contacts).Append("\n");
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
            return Equals((SchoolBusOwner)obj);
        }

        /// <summary>
        /// Returns true if SchoolBusOwner instances are equal
        /// </summary>
        /// <param name="other">Instance of SchoolBusOwner to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchoolBusOwner other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.DateCreated == other.DateCreated ||
                    this.DateCreated != null &&
                    this.DateCreated.Equals(other.DateCreated)
                ) && 
                (
                    this.PrimaryContact == other.PrimaryContact ||
                    this.PrimaryContact != null &&
                    this.PrimaryContact.Equals(other.PrimaryContact)
                ) && 
                (
                    this.ServiceArea == other.ServiceArea ||
                    this.ServiceArea != null &&
                    this.ServiceArea.Equals(other.ServiceArea)
                ) && 
                (
                    this.NextInspectionDate == other.NextInspectionDate ||
                    this.NextInspectionDate != null &&
                    this.NextInspectionDate.Equals(other.NextInspectionDate)
                ) && 
                (
                    this.NumberOfBuses == other.NumberOfBuses ||
                    this.NumberOfBuses != null &&
                    this.NumberOfBuses.Equals(other.NumberOfBuses)
                ) && 
                (
                    this.Contacts == other.Contacts ||
                    this.Contacts != null &&
                    this.Contacts.SequenceEqual(other.Contacts)
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
                if (this.Name != null)
                {
                    hash = hash * 59 + this.Name.GetHashCode();
                }
                if (this.Status != null)
                {
                    hash = hash * 59 + this.Status.GetHashCode();
                }
                if (this.DateCreated != null)
                {
                    hash = hash * 59 + this.DateCreated.GetHashCode();
                }
                if (this.PrimaryContact != null)
                {
                    hash = hash * 59 + this.PrimaryContact.GetHashCode();
                }
                if (this.ServiceArea != null)
                {
                    hash = hash * 59 + this.ServiceArea.GetHashCode();
                }
                if (this.NextInspectionDate != null)
                {
                    hash = hash * 59 + this.NextInspectionDate.GetHashCode();
                }
                if (this.NumberOfBuses != null)
                {
                    hash = hash * 59 + this.NumberOfBuses.GetHashCode();
                }
                if (this.Contacts != null)
                {
                    hash = hash * 59 + this.Contacts.GetHashCode();
                }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(SchoolBusOwner left, SchoolBusOwner right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SchoolBusOwner left, SchoolBusOwner right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
