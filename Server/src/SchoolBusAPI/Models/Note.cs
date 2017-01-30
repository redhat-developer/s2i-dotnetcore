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
    /// Notes entered by users about instance of entities - e.g. School Buses and School Bus Owners
    /// </summary>
        [MetaDataExtension (Description = "Notes entered by users about instance of entities - e.g. School Buses and School Bus Owners")]

    public partial class Note : IEquatable<Note>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public Note()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Note" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="NoteText">The contents of the note..</param>
        /// <param name="IsNoLongerRelevant">A user set flag that the note is no longer relevant. Allows the note to be retained for historical reasons,  but identified to other users as no longer applicable..</param>
        public Note(int Id, string NoteText = null, bool? IsNoLongerRelevant = null)
        {   
            this.Id = Id;
            this.NoteText = NoteText;
            this.IsNoLongerRelevant = IsNoLongerRelevant;
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
        [MaxLength(2048)]
        
        public string NoteText { get; set; }
        
        /// <summary>
        /// A user set flag that the note is no longer relevant. Allows the note to be retained for historical reasons,  but identified to other users as no longer applicable.
        /// </summary>
        /// <value>A user set flag that the note is no longer relevant. Allows the note to be retained for historical reasons,  but identified to other users as no longer applicable.</value>
        [MetaDataExtension (Description = "A user set flag that the note is no longer relevant. Allows the note to be retained for historical reasons,  but identified to other users as no longer applicable.")]
        public bool? IsNoLongerRelevant { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Note {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  NoteText: ").Append(NoteText).Append("\n");
            sb.Append("  IsNoLongerRelevant: ").Append(IsNoLongerRelevant).Append("\n");
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
            return Equals((Note)obj);
        }

        /// <summary>
        /// Returns true if Note instances are equal
        /// </summary>
        /// <param name="other">Instance of Note to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Note other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.NoteText == other.NoteText ||
                    this.NoteText != null &&
                    this.NoteText.Equals(other.NoteText)
                ) &&                 
                (
                    this.IsNoLongerRelevant == other.IsNoLongerRelevant ||
                    this.IsNoLongerRelevant != null &&
                    this.IsNoLongerRelevant.Equals(other.IsNoLongerRelevant)
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
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.NoteText != null)
                {
                    hash = hash * 59 + this.NoteText.GetHashCode();
                }                
                                if (this.IsNoLongerRelevant != null)
                {
                    hash = hash * 59 + this.IsNoLongerRelevant.GetHashCode();
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
        public static bool operator ==(Note left, Note right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Note left, Note right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
