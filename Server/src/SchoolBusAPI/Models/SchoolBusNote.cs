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
    /// Notes entered by users about a specific School Bus
    /// </summary>
    public partial class SchoolBusNote : IEquatable<SchoolBusNote>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public SchoolBusNote()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolBusNote" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="Note">The contents of the note..</param>
        /// <param name="Expired">A flag indicating when true that the note is no longer relevant to support retaining the history but communicating when a note is no longer to be used..</param>
        /// <param name="SchoolBus">SchoolBus.</param>
        public SchoolBusNote(int Id, string Note = null, bool? Expired = null, SchoolBus SchoolBus = null)
        {
            
            this.Id = Id;
            this.Note = Note;
            this.Expired = Expired;
            this.SchoolBus = SchoolBus;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// The contents of the note.
        /// </summary>
        /// <value>The contents of the note.</value>
        [MetaDataExtension (Description = "The contents of the note.")]
        public string Note { get; set; }

        /// <summary>
        /// A flag indicating when true that the note is no longer relevant to support retaining the history but communicating when a note is no longer to be used.
        /// </summary>
        /// <value>A flag indicating when true that the note is no longer relevant to support retaining the history but communicating when a note is no longer to be used.</value>
        [MetaDataExtension (Description = "A flag indicating when true that the note is no longer relevant to support retaining the history but communicating when a note is no longer to be used.")]
        public bool? Expired { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBus
        /// </summary>
        public SchoolBus SchoolBus { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchoolBusNote {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
            sb.Append("  Expired: ").Append(Expired).Append("\n");
            sb.Append("  SchoolBus: ").Append(SchoolBus).Append("\n");
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
            return Equals((SchoolBusNote)obj);
        }

        /// <summary>
        /// Returns true if SchoolBusNote instances are equal
        /// </summary>
        /// <param name="other">Instance of SchoolBusNote to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchoolBusNote other)
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
                    this.Note == other.Note ||
                    this.Note != null &&
                    this.Note.Equals(other.Note)
                ) && 
                (
                    this.Expired == other.Expired ||
                    this.Expired != null &&
                    this.Expired.Equals(other.Expired)
                ) && 
                (
                    this.SchoolBus == other.SchoolBus ||
                    this.SchoolBus != null &&
                    this.SchoolBus.Equals(other.SchoolBus)
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
                if (this.Note != null)
                {
                    hash = hash * 59 + this.Note.GetHashCode();
                }
                if (this.Expired != null)
                {
                    hash = hash * 59 + this.Expired.GetHashCode();
                }
                if (this.SchoolBus != null)
                {
                    hash = hash * 59 + this.SchoolBus.GetHashCode();
                }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(SchoolBusNote left, SchoolBusNote right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SchoolBusNote left, SchoolBusNote right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
