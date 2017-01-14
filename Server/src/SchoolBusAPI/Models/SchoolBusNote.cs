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
    /// Notes entered by users about a specific School Bus.
    /// </summary>
        [MetaDataExtension (Description = "Notes entered by users about a specific School Bus.")]


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
        /// <param name="IsNoLongerRelevant">A user set flag that the note is no longer relevant. Allows the note to be retained for historical reasons, but identified to the user as no longer relevant..</param>
        /// <param name="SchoolBus">SchoolBus.</param>
        public SchoolBusNote(int Id, string Note = null, bool? IsNoLongerRelevant = null, SchoolBus SchoolBus = null)
        {
            
            this.Id = Id;
            this.Note = Note;
            this.IsNoLongerRelevant = IsNoLongerRelevant;
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
        /// A user set flag that the note is no longer relevant. Allows the note to be retained for historical reasons, but identified to the user as no longer relevant.
        /// </summary>
        /// <value>A user set flag that the note is no longer relevant. Allows the note to be retained for historical reasons, but identified to the user as no longer relevant.</value>
        [MetaDataExtension (Description = "A user set flag that the note is no longer relevant. Allows the note to be retained for historical reasons, but identified to the user as no longer relevant.")]
        public bool? IsNoLongerRelevant { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBus
        /// </summary>
        public SchoolBus SchoolBus { get; set; }
        [ForeignKey("SchoolBus")]
        public int? SchoolBusRefId { get; set; }

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
            sb.Append("  IsNoLongerRelevant: ").Append(IsNoLongerRelevant).Append("\n");
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
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Note == other.Note ||
                    this.Note != null &&
                    this.Note.Equals(other.Note)
                ) && 
                (
                    this.IsNoLongerRelevant == other.IsNoLongerRelevant ||
                    this.IsNoLongerRelevant != null &&
                    this.IsNoLongerRelevant.Equals(other.IsNoLongerRelevant)
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
                hash = hash * 59 + this.Id.GetHashCode();
                
                if (this.Note != null)
                {
                    hash = hash * 59 + this.Note.GetHashCode();
                }
                if (this.IsNoLongerRelevant != null)
                {
                    hash = hash * 59 + this.IsNoLongerRelevant.GetHashCode();
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
