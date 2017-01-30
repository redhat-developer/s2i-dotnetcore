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
        /// <param name="Name">The name of the School Bus owner as defined by the user&amp;#x2F;Inspector. Not tied to the ICBC or NSC names,  but whatever is most useful for the Inspectors..</param>
        /// <param name="Status">Status of the School Bus owner - enumerated value Active,  Archived.</param>
        /// <param name="DateCreated">The date-time of the creation of the record from the audit fields. Since this might be surfaced in the API,  adding it to the definition..</param>
        /// <param name="PrimaryContact">Link to the designated Primary Contact for the Inspector to the School Bus Owner organization..</param>
        /// <param name="District">The District to which this School Bus is affliated..</param>
        /// <param name="Contacts">The set of contacts related to the School Bus Owner..</param>
        /// <param name="Notes">The set of notes about the school bus owner entered by users..</param>
        /// <param name="Attachments">The set of attachments about the school bus owner uploaded by the users..</param>
        /// <param name="History">The history of updates made to the School Bus Owner data..</param>
        public SchoolBusOwner(int Id, string Name = null, string Status = null, DateTime? DateCreated = null, Contact PrimaryContact = null, District District = null, List<Contact> Contacts = null, List<Note> Notes = null, List<Attachment> Attachments = null, List<History> History = null)
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
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }
        
        /// <summary>
        /// The name of the School Bus owner as defined by the user&#x2F;Inspector. Not tied to the ICBC or NSC names,  but whatever is most useful for the Inspectors.
        /// </summary>
        /// <value>The name of the School Bus owner as defined by the user&#x2F;Inspector. Not tied to the ICBC or NSC names,  but whatever is most useful for the Inspectors.</value>
        [MetaDataExtension (Description = "The name of the School Bus owner as defined by the user&#x2F;Inspector. Not tied to the ICBC or NSC names,  but whatever is most useful for the Inspectors.")]
        [MaxLength(255)]
        
        public string Name { get; set; }
        
        /// <summary>
        /// Status of the School Bus owner - enumerated value Active,  Archived
        /// </summary>
        /// <value>Status of the School Bus owner - enumerated value Active,  Archived</value>
        [MetaDataExtension (Description = "Status of the School Bus owner - enumerated value Active,  Archived")]
        [MaxLength(255)]
        
        public string Status { get; set; }
        
        /// <summary>
        /// The date-time of the creation of the record from the audit fields. Since this might be surfaced in the API,  adding it to the definition.
        /// </summary>
        /// <value>The date-time of the creation of the record from the audit fields. Since this might be surfaced in the API,  adding it to the definition.</value>
        [MetaDataExtension (Description = "The date-time of the creation of the record from the audit fields. Since this might be surfaced in the API,  adding it to the definition.")]
        public DateTime? DateCreated { get; set; }
        
        /// <summary>
        /// Link to the designated Primary Contact for the Inspector to the School Bus Owner organization.
        /// </summary>
        /// <value>Link to the designated Primary Contact for the Inspector to the School Bus Owner organization.</value>
        [MetaDataExtension (Description = "Link to the designated Primary Contact for the Inspector to the School Bus Owner organization.")]
        public Contact PrimaryContact { get; set; }
        
        /// <summary>
        /// Foreign key for PrimaryContact 
        /// </summary>       
        [ForeignKey("PrimaryContact")]
        public int? PrimaryContactRefId { get; set; }
        
        /// <summary>
        /// The District to which this School Bus is affliated.
        /// </summary>
        /// <value>The District to which this School Bus is affliated.</value>
        [MetaDataExtension (Description = "The District to which this School Bus is affliated.")]
        public District District { get; set; }
        
        /// <summary>
        /// Foreign key for District 
        /// </summary>       
        [ForeignKey("District")]
        public int? DistrictRefId { get; set; }
        
        /// <summary>
        /// The set of contacts related to the School Bus Owner.
        /// </summary>
        /// <value>The set of contacts related to the School Bus Owner.</value>
        [MetaDataExtension (Description = "The set of contacts related to the School Bus Owner.")]
        public List<Contact> Contacts { get; set; }
        
        /// <summary>
        /// The set of notes about the school bus owner entered by users.
        /// </summary>
        /// <value>The set of notes about the school bus owner entered by users.</value>
        [MetaDataExtension (Description = "The set of notes about the school bus owner entered by users.")]
        public List<Note> Notes { get; set; }
        
        /// <summary>
        /// The set of attachments about the school bus owner uploaded by the users.
        /// </summary>
        /// <value>The set of attachments about the school bus owner uploaded by the users.</value>
        [MetaDataExtension (Description = "The set of attachments about the school bus owner uploaded by the users.")]
        public List<Attachment> Attachments { get; set; }
        
        /// <summary>
        /// The history of updates made to the School Bus Owner data.
        /// </summary>
        /// <value>The history of updates made to the School Bus Owner data.</value>
        [MetaDataExtension (Description = "The history of updates made to the School Bus Owner data.")]
        public List<History> History { get; set; }
        
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
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.Name != null)
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
        
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(SchoolBusOwner left, SchoolBusOwner right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(SchoolBusOwner left, SchoolBusOwner right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
