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

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// 
    /// </summary>



    public partial class SchoolBusOwnerContact : IEquatable<SchoolBusOwnerContact>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public SchoolBusOwnerContact()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolBusOwnerContact" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="GivenName">The given name of the contact..</param>
        /// <param name="Surname">The surname of the contact..</param>
        /// <param name="Role">The role of the contact. UI controlled as to whether it is free form or selected from an enumerated list..</param>
        /// <param name="Notes">Notes about the contact..</param>
        /// <param name="SchoolBusOwnerContactPhones">SchoolBusOwnerContactPhones.</param>
        /// <param name="SchoolBusOwnerContactAddresses">SchoolBusOwnerContactAddresses.</param>
        public SchoolBusOwnerContact(int Id, string GivenName = null, string Surname = null, string Role = null, string Notes = null, List<SchoolBusOwnerContactPhone> SchoolBusOwnerContactPhones = null, List<SchoolBusOwnerContactAddress> SchoolBusOwnerContactAddresses = null)
        {
            
            this.Id = Id;
            this.GivenName = GivenName;
            this.Surname = Surname;
            this.Role = Role;
            this.Notes = Notes;
            this.SchoolBusOwnerContactPhones = SchoolBusOwnerContactPhones;
            this.SchoolBusOwnerContactAddresses = SchoolBusOwnerContactAddresses;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// The given name of the contact.
        /// </summary>
        /// <value>The given name of the contact.</value>
        [MetaDataExtension (Description = "The given name of the contact.")]
        public string GivenName { get; set; }

        /// <summary>
        /// The surname of the contact.
        /// </summary>
        /// <value>The surname of the contact.</value>
        [MetaDataExtension (Description = "The surname of the contact.")]
        public string Surname { get; set; }

        /// <summary>
        /// The role of the contact. UI controlled as to whether it is free form or selected from an enumerated list.
        /// </summary>
        /// <value>The role of the contact. UI controlled as to whether it is free form or selected from an enumerated list.</value>
        [MetaDataExtension (Description = "The role of the contact. UI controlled as to whether it is free form or selected from an enumerated list.")]
        public string Role { get; set; }

        /// <summary>
        /// Notes about the contact.
        /// </summary>
        /// <value>Notes about the contact.</value>
        [MetaDataExtension (Description = "Notes about the contact.")]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusOwnerContactPhones
        /// </summary>
        public List<SchoolBusOwnerContactPhone> SchoolBusOwnerContactPhones { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusOwnerContactAddresses
        /// </summary>
        public List<SchoolBusOwnerContactAddress> SchoolBusOwnerContactAddresses { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchoolBusOwnerContact {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  GivenName: ").Append(GivenName).Append("\n");
            sb.Append("  Surname: ").Append(Surname).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  SchoolBusOwnerContactPhones: ").Append(SchoolBusOwnerContactPhones).Append("\n");
            sb.Append("  SchoolBusOwnerContactAddresses: ").Append(SchoolBusOwnerContactAddresses).Append("\n");
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
            return Equals((SchoolBusOwnerContact)obj);
        }

        /// <summary>
        /// Returns true if SchoolBusOwnerContact instances are equal
        /// </summary>
        /// <param name="other">Instance of SchoolBusOwnerContact to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchoolBusOwnerContact other)
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
                    this.SchoolBusOwnerContactPhones == other.SchoolBusOwnerContactPhones ||
                    this.SchoolBusOwnerContactPhones != null &&
                    this.SchoolBusOwnerContactPhones.SequenceEqual(other.SchoolBusOwnerContactPhones)
                ) && 
                (
                    this.SchoolBusOwnerContactAddresses == other.SchoolBusOwnerContactAddresses ||
                    this.SchoolBusOwnerContactAddresses != null &&
                    this.SchoolBusOwnerContactAddresses.SequenceEqual(other.SchoolBusOwnerContactAddresses)
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
                
                if (this.GivenName != null)
                {
                    hash = hash * 59 + this.GivenName.GetHashCode();
                }
                if (this.Surname != null)
                {
                    hash = hash * 59 + this.Surname.GetHashCode();
                }
                if (this.Role != null)
                {
                    hash = hash * 59 + this.Role.GetHashCode();
                }
                if (this.Notes != null)
                {
                    hash = hash * 59 + this.Notes.GetHashCode();
                }
                if (this.SchoolBusOwnerContactPhones != null)
                {
                    hash = hash * 59 + this.SchoolBusOwnerContactPhones.GetHashCode();
                }
                if (this.SchoolBusOwnerContactAddresses != null)
                {
                    hash = hash * 59 + this.SchoolBusOwnerContactAddresses.GetHashCode();
                }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(SchoolBusOwnerContact left, SchoolBusOwnerContact right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SchoolBusOwnerContact left, SchoolBusOwnerContact right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
