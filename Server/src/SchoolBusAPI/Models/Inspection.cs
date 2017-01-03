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
    public partial class Inspection : IEquatable<Inspection>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public Inspection()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Inspection" /> class.
        /// </summary>
        /// <param name="Id">Primary Key  make this match the Inspection Details page (required).</param>
        /// <param name="SchoolBus">SchoolBus.</param>
        /// <param name="Inspector">Inspector.</param>
        public Inspection(int Id, SchoolBus SchoolBus = null, User Inspector = null)
        {
            
            this.Id = Id;
            this.SchoolBus = SchoolBus;
            this.Inspector = Inspector;
            
        }

        /// <summary>
        /// Primary Key  make this match the Inspection Details page
        /// </summary>
        /// <value>Primary Key  make this match the Inspection Details page</value>
        [MetaDataExtension (Description = "Primary Key  make this match the Inspection Details page")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBus
        /// </summary>
        public SchoolBus SchoolBus { get; set; }

        /// <summary>
        /// Gets or Sets Inspector
        /// </summary>
        public User Inspector { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Inspection {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  SchoolBus: ").Append(SchoolBus).Append("\n");
            sb.Append("  Inspector: ").Append(Inspector).Append("\n");
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
            return Equals((Inspection)obj);
        }

        /// <summary>
        /// Returns true if Inspection instances are equal
        /// </summary>
        /// <param name="other">Instance of Inspection to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Inspection other)
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
                    this.SchoolBus == other.SchoolBus ||
                    this.SchoolBus != null &&
                    this.SchoolBus.Equals(other.SchoolBus)
                ) && 
                (
                    this.Inspector == other.Inspector ||
                    this.Inspector != null &&
                    this.Inspector.Equals(other.Inspector)
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
                if (this.SchoolBus != null)
                {
                    hash = hash * 59 + this.SchoolBus.GetHashCode();
                }
                if (this.Inspector != null)
                {
                    hash = hash * 59 + this.Inspector.GetHashCode();
                }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Inspection left, Inspection right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Inspection left, Inspection right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
