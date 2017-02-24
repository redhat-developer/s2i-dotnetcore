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
    /// A table of contacts related to various entities in the system. FK fields are used to link contacts to records in the system.
    /// </summary>
        [MetaDataExtension (Description = "A table of contacts related to various entities in the system. FK fields are used to link contacts to records in the system.")]

    public partial class Contact : AuditableEntity, IEquatable<Contact>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public Contact()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact" /> class.
        /// </summary>
        /// <param name="Id">A system-generated unique identifier for a Contact (required).</param>
        /// <param name="GivenName">The given name of the contact..</param>
        /// <param name="Surname">The surname of the contact..</param>
        /// <param name="OrganizationName">The organization name of the contact..</param>
        /// <param name="Role">The role of the contact. UI controlled as to whether it is free form or selected from an enumerated list - for initial implementation, the field is freeform..</param>
        /// <param name="Notes">A note about the contact maintained by the users..</param>
        /// <param name="EmailAddress">The email address for the contact..</param>
        /// <param name="WorkPhoneNumber">The work phone number for the contact..</param>
        /// <param name="MobilePhoneNumber">The mobile phone number for the contact..</param>
        /// <param name="FaxPhoneNumber">The fax phone number for the contact..</param>
        /// <param name="Address1">Address 1 line of the address..</param>
        /// <param name="Address2">Address 2 line of the address..</param>
        /// <param name="City">The City of the address..</param>
        /// <param name="Province">The Province of the address..</param>
        /// <param name="PostalCode">The postal code of the address..</param>
        public Contact(int Id, string GivenName = null, string Surname = null, string OrganizationName = null, string Role = null, string Notes = null, string EmailAddress = null, string WorkPhoneNumber = null, string MobilePhoneNumber = null, string FaxPhoneNumber = null, string Address1 = null, string Address2 = null, string City = null, string Province = null, string PostalCode = null)
        {   
            this.Id = Id;
            this.GivenName = GivenName;
            this.Surname = Surname;
            this.OrganizationName = OrganizationName;
            this.Role = Role;
            this.Notes = Notes;
            this.EmailAddress = EmailAddress;
            this.WorkPhoneNumber = WorkPhoneNumber;
            this.MobilePhoneNumber = MobilePhoneNumber;
            this.FaxPhoneNumber = FaxPhoneNumber;
            this.Address1 = Address1;
            this.Address2 = Address2;
            this.City = City;
            this.Province = Province;
            this.PostalCode = PostalCode;
        }

        /// <summary>
        /// A system-generated unique identifier for a Contact
        /// </summary>
        /// <value>A system-generated unique identifier for a Contact</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for a Contact")]
        public int Id { get; set; }
        
        /// <summary>
        /// The given name of the contact.
        /// </summary>
        /// <value>The given name of the contact.</value>
        [MetaDataExtension (Description = "The given name of the contact.")]
        [MaxLength(50)]
        
        public string GivenName { get; set; }
        
        /// <summary>
        /// The surname of the contact.
        /// </summary>
        /// <value>The surname of the contact.</value>
        [MetaDataExtension (Description = "The surname of the contact.")]
        [MaxLength(50)]
        
        public string Surname { get; set; }
        
        /// <summary>
        /// The organization name of the contact.
        /// </summary>
        /// <value>The organization name of the contact.</value>
        [MetaDataExtension (Description = "The organization name of the contact.")]
        [MaxLength(150)]
        
        public string OrganizationName { get; set; }
        
        /// <summary>
        /// The role of the contact. UI controlled as to whether it is free form or selected from an enumerated list - for initial implementation, the field is freeform.
        /// </summary>
        /// <value>The role of the contact. UI controlled as to whether it is free form or selected from an enumerated list - for initial implementation, the field is freeform.</value>
        [MetaDataExtension (Description = "The role of the contact. UI controlled as to whether it is free form or selected from an enumerated list - for initial implementation, the field is freeform.")]
        [MaxLength(100)]
        
        public string Role { get; set; }
        
        /// <summary>
        /// A note about the contact maintained by the users.
        /// </summary>
        /// <value>A note about the contact maintained by the users.</value>
        [MetaDataExtension (Description = "A note about the contact maintained by the users.")]
        [MaxLength(150)]
        
        public string Notes { get; set; }
        
        /// <summary>
        /// The email address for the contact.
        /// </summary>
        /// <value>The email address for the contact.</value>
        [MetaDataExtension (Description = "The email address for the contact.")]
        [MaxLength(255)]
        
        public string EmailAddress { get; set; }
        
        /// <summary>
        /// The work phone number for the contact.
        /// </summary>
        /// <value>The work phone number for the contact.</value>
        [MetaDataExtension (Description = "The work phone number for the contact.")]
        [MaxLength(20)]
        
        public string WorkPhoneNumber { get; set; }
        
        /// <summary>
        /// The mobile phone number for the contact.
        /// </summary>
        /// <value>The mobile phone number for the contact.</value>
        [MetaDataExtension (Description = "The mobile phone number for the contact.")]
        [MaxLength(20)]
        
        public string MobilePhoneNumber { get; set; }
        
        /// <summary>
        /// The fax phone number for the contact.
        /// </summary>
        /// <value>The fax phone number for the contact.</value>
        [MetaDataExtension (Description = "The fax phone number for the contact.")]
        [MaxLength(20)]
        
        public string FaxPhoneNumber { get; set; }
        
        /// <summary>
        /// Address 1 line of the address.
        /// </summary>
        /// <value>Address 1 line of the address.</value>
        [MetaDataExtension (Description = "Address 1 line of the address.")]
        [MaxLength(80)]
        
        public string Address1 { get; set; }
        
        /// <summary>
        /// Address 2 line of the address.
        /// </summary>
        /// <value>Address 2 line of the address.</value>
        [MetaDataExtension (Description = "Address 2 line of the address.")]
        [MaxLength(80)]
        
        public string Address2 { get; set; }
        
        /// <summary>
        /// The City of the address.
        /// </summary>
        /// <value>The City of the address.</value>
        [MetaDataExtension (Description = "The City of the address.")]
        [MaxLength(100)]
        
        public string City { get; set; }
        
        /// <summary>
        /// The Province of the address.
        /// </summary>
        /// <value>The Province of the address.</value>
        [MetaDataExtension (Description = "The Province of the address.")]
        [MaxLength(50)]
        
        public string Province { get; set; }
        
        /// <summary>
        /// The postal code of the address.
        /// </summary>
        /// <value>The postal code of the address.</value>
        [MetaDataExtension (Description = "The postal code of the address.")]
        [MaxLength(15)]
        
        public string PostalCode { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Contact {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  GivenName: ").Append(GivenName).Append("\n");
            sb.Append("  Surname: ").Append(Surname).Append("\n");
            sb.Append("  OrganizationName: ").Append(OrganizationName).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  EmailAddress: ").Append(EmailAddress).Append("\n");
            sb.Append("  WorkPhoneNumber: ").Append(WorkPhoneNumber).Append("\n");
            sb.Append("  MobilePhoneNumber: ").Append(MobilePhoneNumber).Append("\n");
            sb.Append("  FaxPhoneNumber: ").Append(FaxPhoneNumber).Append("\n");
            sb.Append("  Address1: ").Append(Address1).Append("\n");
            sb.Append("  Address2: ").Append(Address2).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  Province: ").Append(Province).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
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
            return Equals((Contact)obj);
        }

        /// <summary>
        /// Returns true if Contact instances are equal
        /// </summary>
        /// <param name="other">Instance of Contact to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Contact other)
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
                    this.OrganizationName == other.OrganizationName ||
                    this.OrganizationName != null &&
                    this.OrganizationName.Equals(other.OrganizationName)
                ) &&                 
                (
                    this.Role == other.Role ||
                    this.Role != null &&
                    this.Role.Equals(other.Role)
                ) &&                 
                (
                    this.Notes == other.Notes ||
                    this.Notes != null &&
                    this.Notes.Equals(other.Notes)
                ) &&                 
                (
                    this.EmailAddress == other.EmailAddress ||
                    this.EmailAddress != null &&
                    this.EmailAddress.Equals(other.EmailAddress)
                ) &&                 
                (
                    this.WorkPhoneNumber == other.WorkPhoneNumber ||
                    this.WorkPhoneNumber != null &&
                    this.WorkPhoneNumber.Equals(other.WorkPhoneNumber)
                ) &&                 
                (
                    this.MobilePhoneNumber == other.MobilePhoneNumber ||
                    this.MobilePhoneNumber != null &&
                    this.MobilePhoneNumber.Equals(other.MobilePhoneNumber)
                ) &&                 
                (
                    this.FaxPhoneNumber == other.FaxPhoneNumber ||
                    this.FaxPhoneNumber != null &&
                    this.FaxPhoneNumber.Equals(other.FaxPhoneNumber)
                ) &&                 
                (
                    this.Address1 == other.Address1 ||
                    this.Address1 != null &&
                    this.Address1.Equals(other.Address1)
                ) &&                 
                (
                    this.Address2 == other.Address2 ||
                    this.Address2 != null &&
                    this.Address2.Equals(other.Address2)
                ) &&                 
                (
                    this.City == other.City ||
                    this.City != null &&
                    this.City.Equals(other.City)
                ) &&                 
                (
                    this.Province == other.Province ||
                    this.Province != null &&
                    this.Province.Equals(other.Province)
                ) &&                 
                (
                    this.PostalCode == other.PostalCode ||
                    this.PostalCode != null &&
                    this.PostalCode.Equals(other.PostalCode)
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
                                if (this.OrganizationName != null)
                {
                    hash = hash * 59 + this.OrganizationName.GetHashCode();
                }                
                                if (this.Role != null)
                {
                    hash = hash * 59 + this.Role.GetHashCode();
                }                
                                if (this.Notes != null)
                {
                    hash = hash * 59 + this.Notes.GetHashCode();
                }                
                                if (this.EmailAddress != null)
                {
                    hash = hash * 59 + this.EmailAddress.GetHashCode();
                }                
                                if (this.WorkPhoneNumber != null)
                {
                    hash = hash * 59 + this.WorkPhoneNumber.GetHashCode();
                }                
                                if (this.MobilePhoneNumber != null)
                {
                    hash = hash * 59 + this.MobilePhoneNumber.GetHashCode();
                }                
                                if (this.FaxPhoneNumber != null)
                {
                    hash = hash * 59 + this.FaxPhoneNumber.GetHashCode();
                }                
                                if (this.Address1 != null)
                {
                    hash = hash * 59 + this.Address1.GetHashCode();
                }                
                                if (this.Address2 != null)
                {
                    hash = hash * 59 + this.Address2.GetHashCode();
                }                
                                if (this.City != null)
                {
                    hash = hash * 59 + this.City.GetHashCode();
                }                
                                if (this.Province != null)
                {
                    hash = hash * 59 + this.Province.GetHashCode();
                }                
                                if (this.PostalCode != null)
                {
                    hash = hash * 59 + this.PostalCode.GetHashCode();
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
        public static bool operator ==(Contact left, Contact right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Contact left, Contact right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
