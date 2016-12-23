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
    public partial class SchoolBusOwnerNote : IEquatable<SchoolBusOwnerNote>
    {

        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public SchoolBusOwnerNote()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolBusOwnerNote" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="Expired">Expired.</param>
        /// <param name="Value">The note text.</param>
        /// <param name="SchoolBusOwner">SchoolBusOwner.</param>
        public SchoolBusOwnerNote(int Id, bool? Expired = null, string Value = null, SchoolBusOwner SchoolBusOwner = null)
        {

            this.Id = Id;
            this.Expired = Expired;
            this.Value = Value;
            this.SchoolBusOwner = SchoolBusOwner;

        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name = "id")]
        [MetaDataExtension(Description = "Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Expired
        /// </summary>
        [DataMember(Name = "Expired")]

        public bool? Expired { get; set; }

        /// <summary>
        /// The note text
        /// </summary>
        /// <value>The note text</value>
        [DataMember(Name = "Value")]
        [MetaDataExtension(Description = "The note text")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusOwner
        /// </summary>
        [DataMember(Name = "SchoolBusOwner")]

        public SchoolBusOwner SchoolBusOwner { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchoolBusOwnerNote {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Expired: ").Append(Expired).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  SchoolBusOwner: ").Append(SchoolBusOwner).Append("\n");
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
            return Equals((SchoolBusOwnerNote)obj);
        }

        /// <summary>
        /// Returns true if SchoolBusOwnerNote instances are equal
        /// </summary>
        /// <param name="other">Instance of SchoolBusOwnerNote to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchoolBusOwnerNote other)
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
                    this.Expired == other.Expired ||
                    this.Expired != null &&
                    this.Expired.Equals(other.Expired)
                ) &&
                (
                    this.Value == other.Value ||
                    this.Value != null &&
                    this.Value.Equals(other.Value)
                ) &&
                (
                    this.SchoolBusOwner == other.SchoolBusOwner ||
                    this.SchoolBusOwner != null &&
                    this.SchoolBusOwner.Equals(other.SchoolBusOwner)
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
                if (this.Expired != null)
                {
                    hash = hash * 59 + this.Expired.GetHashCode();
                }
                if (this.Value != null)
                {
                    hash = hash * 59 + this.Value.GetHashCode();
                }
                if (this.SchoolBusOwner != null)
                {
                    hash = hash * 59 + this.SchoolBusOwner.GetHashCode();
                }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(SchoolBusOwnerNote left, SchoolBusOwnerNote right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SchoolBusOwnerNote left, SchoolBusOwnerNote right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
