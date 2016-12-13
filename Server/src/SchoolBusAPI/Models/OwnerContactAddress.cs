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
    public partial class OwnerContactAddress :  IEquatable<OwnerContactAddress>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerContactAddress" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="OwnerContact">OwnerContact.</param>
        public OwnerContactAddress(int Id, OwnerContact OwnerContact = null)
        {
            
            this.Id = Id;            
            this.OwnerContact = OwnerContact;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name="Id")]
        [MetaDataExtension (Description = "Primary Key")]        
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets OwnerContact
        /// </summary>
        [DataMember(Name="OwnerContact")]
                
        public OwnerContact OwnerContact { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OwnerContactAddress {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  OwnerContact: ").Append(OwnerContact).Append("\n");
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
            return Equals((OwnerContactAddress)obj);
        }

        /// <summary>
        /// Returns true if OwnerContactAddress instances are equal
        /// </summary>
        /// <param name="other">Instance of OwnerContactAddress to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OwnerContactAddress other)
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
                    this.OwnerContact == other.OwnerContact ||
                    this.OwnerContact != null &&
                    this.OwnerContact.Equals(other.OwnerContact)
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
                    if (this.OwnerContact != null)
                    { 
                        hash = hash * 59 + this.OwnerContact.GetHashCode();
                    }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(OwnerContactAddress left, OwnerContactAddress right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OwnerContactAddress left, OwnerContactAddress right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
