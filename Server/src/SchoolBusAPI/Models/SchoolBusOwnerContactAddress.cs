/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
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
    [DataContract]
    public partial class SchoolBusOwnerContactAddress :  IEquatable<SchoolBusOwnerContactAddress>
    {

        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public SchoolBusOwnerContactAddress()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolBusOwnerContactAddress" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="SchoolBusOwnerContact">SchoolBusOwnerContact.</param>
        public SchoolBusOwnerContactAddress(int Id, SchoolBusOwnerContact SchoolBusOwnerContact = null)
        {
            
            this.Id = Id;            
            this.SchoolBusOwnerContact = SchoolBusOwnerContact;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name="id")]
        [MetaDataExtension (Description = "Primary Key")]        
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusOwnerContact
        /// </summary>
        [DataMember(Name="SchoolBusOwnerContact")]
                
        public SchoolBusOwnerContact SchoolBusOwnerContact { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchoolBusOwnerContactAddress {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  SchoolBusOwnerContact: ").Append(SchoolBusOwnerContact).Append("\n");
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
            return Equals((SchoolBusOwnerContactAddress)obj);
        }

        /// <summary>
        /// Returns true if SchoolBusOwnerContactAddress instances are equal
        /// </summary>
        /// <param name="other">Instance of SchoolBusOwnerContactAddress to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchoolBusOwnerContactAddress other)
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
                    this.SchoolBusOwnerContact == other.SchoolBusOwnerContact ||
                    this.SchoolBusOwnerContact != null &&
                    this.SchoolBusOwnerContact.Equals(other.SchoolBusOwnerContact)
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
                    if (this.SchoolBusOwnerContact != null)
                    { 
                        hash = hash * 59 + this.SchoolBusOwnerContact.GetHashCode();
                    }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(SchoolBusOwnerContactAddress left, SchoolBusOwnerContactAddress right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SchoolBusOwnerContactAddress left, SchoolBusOwnerContactAddress right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
