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
using SchoolBusAPI.Models;

namespace SchoolBusAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class SchoolBusOwnerViewModel : IEquatable<SchoolBusOwnerViewModel>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public SchoolBusOwnerViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolBusOwnerViewModel" /> class.
        /// </summary>
        /// <param name="GivenName">GivenName.</param>
        /// <param name="Surname">Surname.</param>
        /// <param name="FullName">FullName.</param>
        /// <param name="DistrictName">DistrictName.</param>
        /// <param name="OverdueInspections">OverdueInspections.</param>
        /// <param name="ScheduledInspections">ScheduledInspections.</param>
        /// <param name="DueNextMonthInspections">DueNextMonthInspections.</param>
        public SchoolBusOwnerViewModel(int Id, string Name = null, string Status = null, DateTime? DateCreated = null, Contact PrimaryContact = null, District District = null, List<Contact> Contacts = null, List<Note> Notes = null, List<Attachment> Attachments = null, List<History> History = null)
        {
            this.Id = Id;
            this.Name = Name;
            this.Status = Status;
            this.DateCreated = DateCreated;
            this.PrimaryContact = PrimaryContact;
            this.District = District;
            this.Contacts = Contacts;
            this.Notes = Notes;
            this.Attachments = Attachments;
            this.History = History;

        }

        /// <summary>
        /// Gets or Sets GivenName
        /// </summary>
        [DataMember(Name= "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Surname
        /// </summary>
        [DataMember(Name= "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets FullName
        /// </summary>
        [DataMember(Name= "Status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets DistrictName
        /// </summary>
        [DataMember(Name= "DateCreated")]
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Gets or Sets OverdueInspections
        /// </summary>
        [DataMember(Name= "PrimaryContact")]
        public Contact PrimaryContact { get; set; }

        /// <summary>
        /// Gets or Sets ScheduledInspections
        /// </summary>
        [DataMember(Name= "District")]
        public District District { get; set; }

        /// <summary>
        /// Gets or Sets DueNextMonthInspections
        /// </summary>
        [DataMember(Name= "Contacts")]
        public List<Contact> Contacts { get; set; }

        /// <summary>
        /// The set of notes about the school bus owner entered by users.
        /// </summary>
        /// <value>The set of notes about the school bus owner entered by users.</value>
        [DataMember(Name = "Notes")]
        public List<Note> Notes { get; set; }

        /// <summary>
        /// The set of attachments about the school bus owner uploaded by the users.
        /// </summary>
        /// <value>The set of attachments about the school bus owner uploaded by the users.</value>        
        [DataMember(Name = "Attachments")]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// The history of updates made to the School Bus Owner data.
        /// </summary>
        /// <value>The history of updates made to the School Bus Owner data.</value>
        [DataMember(Name = "History")]
        public List<History> History { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>The next inspection date associated with this owner</value>
        [DataMember(Name = "nextInspectionDate")]
        public DateTime? nextInspectionDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>The number of buses for which this owner is associated with</value>
        [DataMember(Name = "numberOfBuses")]
        public int numberOfBuses { get; set; }


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
            sb.Append("  District: ").Append(District).Append("\n");
            sb.Append("  Contacts: ").Append(Contacts).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  Attachments: ").Append(Attachments).Append("\n");
            sb.Append("  History: ").Append(History).Append("\n");
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
        public bool Equals(SchoolBusOwnerViewModel other)
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
                    this.District == other.District ||
                    this.District != null &&
                    this.District.Equals(other.District)
                ) &&
                (
                    this.Contacts == other.Contacts ||
                    this.Contacts != null &&
                    this.Contacts.SequenceEqual(other.Contacts)
                ) &&
                (
                    this.Notes == other.Notes ||
                    this.Notes != null &&
                    this.Notes.SequenceEqual(other.Notes)
                ) &&
                (
                    this.Attachments == other.Attachments ||
                    this.Attachments != null &&
                    this.Attachments.SequenceEqual(other.Attachments)
                ) &&
                (
                    this.History == other.History ||
                    this.History != null &&
                    this.History.SequenceEqual(other.History)
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

                hash = hash * 59 + this.Id.GetHashCode(); if (this.Name != null)
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
                if (this.District != null)
                {
                    hash = hash * 59 + this.District.GetHashCode();
                }
                if (this.Contacts != null)
                {
                    hash = hash * 59 + this.Contacts.GetHashCode();
                }
                if (this.Notes != null)
                {
                    hash = hash * 59 + this.Notes.GetHashCode();
                }
                if (this.Attachments != null)
                {
                    hash = hash * 59 + this.Attachments.GetHashCode();
                }
                if (this.History != null)
                {
                    hash = hash * 59 + this.History.GetHashCode();
                }
                return hash;
            }

        }

        #region Operators

        public static bool operator ==(SchoolBusOwnerViewModel left, SchoolBusOwnerViewModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SchoolBusOwnerViewModel left, SchoolBusOwnerViewModel right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
