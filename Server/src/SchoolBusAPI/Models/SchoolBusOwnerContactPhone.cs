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



    public partial class SchoolBusOwnerContactPhone : IEquatable<SchoolBusOwnerContactPhone>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public SchoolBusOwnerContactPhone()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolBusOwnerContactPhone" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="Type">The type of the phone number. UI controlled as to whether it is free form or selected from an enumerated list..</param>
        /// <param name="PhoneNumber">The phone number of the contact. Entered as free form to support a range of formats..</param>
        public SchoolBusOwnerContactPhone(int Id, string Type = null, string PhoneNumber = null)
        {
            
            this.Id = Id;
            this.Type = Type;
            this.PhoneNumber = PhoneNumber;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// The type of the phone number. UI controlled as to whether it is free form or selected from an enumerated list.
        /// </summary>
        /// <value>The type of the phone number. UI controlled as to whether it is free form or selected from an enumerated list.</value>
        [MetaDataExtension (Description = "The type of the phone number. UI controlled as to whether it is free form or selected from an enumerated list.")]
        public string Type { get; set; }

        /// <summary>
        /// The phone number of the contact. Entered as free form to support a range of formats.
        /// </summary>
        /// <value>The phone number of the contact. Entered as free form to support a range of formats.</value>
        [MetaDataExtension (Description = "The phone number of the contact. Entered as free form to support a range of formats.")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchoolBusOwnerContactPhone {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
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
            return Equals((SchoolBusOwnerContactPhone)obj);
        }

        /// <summary>
        /// Returns true if SchoolBusOwnerContactPhone instances are equal
        /// </summary>
        /// <param name="other">Instance of SchoolBusOwnerContactPhone to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchoolBusOwnerContactPhone other)
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
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) && 
                (
                    this.PhoneNumber == other.PhoneNumber ||
                    this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(other.PhoneNumber)
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
                
                if (this.Type != null)
                {
                    hash = hash * 59 + this.Type.GetHashCode();
                }
                if (this.PhoneNumber != null)
                {
                    hash = hash * 59 + this.PhoneNumber.GetHashCode();
                }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(SchoolBusOwnerContactPhone left, SchoolBusOwnerContactPhone right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SchoolBusOwnerContactPhone left, SchoolBusOwnerContactPhone right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
