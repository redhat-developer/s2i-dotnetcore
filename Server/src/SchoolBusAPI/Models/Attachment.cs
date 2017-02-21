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
    /// Attachments uploaded by users about instance of entities - e.g. School Buses and School Bus Owners
    /// </summary>
        [MetaDataExtension (Description = "Attachments uploaded by users about instance of entities - e.g. School Buses and School Bus Owners")]

    public partial class Attachment : IEquatable<Attachment>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public Attachment()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attachment" /> class.
        /// </summary>
        /// <param name="Id">A system-generated unique identifier for an Attachment (required).</param>
        /// <param name="FileName">Filename as passed by the user uploading the file.</param>
        /// <param name="FileContents">Binary contents of the file.</param>
        /// <param name="Description">A note about the attachment,  optionally maintained by the user..</param>
        /// <param name="Type">Type of attachment.</param>
        public Attachment(int Id, string FileName = null, byte[] FileContents = null, string Description = null, string Type = null)
        {   
            this.Id = Id;
            this.FileName = FileName;
            this.FileContents = FileContents;
            this.Description = Description;
            this.Type = Type;
        }

        /// <summary>
        /// A system-generated unique identifier for an Attachment
        /// </summary>
        /// <value>A system-generated unique identifier for an Attachment</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for an Attachment")]
        public int Id { get; set; }
        
        /// <summary>
        /// Filename as passed by the user uploading the file
        /// </summary>
        /// <value>Filename as passed by the user uploading the file</value>
        [MetaDataExtension (Description = "Filename as passed by the user uploading the file")]
        [MaxLength(2048)]
        
        public string FileName { get; set; }
        
        /// <summary>
        /// Binary contents of the file
        /// </summary>
        /// <value>Binary contents of the file</value>
        [MetaDataExtension (Description = "Binary contents of the file")]
        public byte[] FileContents { get; set; }
        
        /// <summary>
        /// A note about the attachment,  optionally maintained by the user.
        /// </summary>
        /// <value>A note about the attachment,  optionally maintained by the user.</value>
        [MetaDataExtension (Description = "A note about the attachment,  optionally maintained by the user.")]
        [MaxLength(2048)]
        
        public string Description { get; set; }
        
        /// <summary>
        /// Type of attachment
        /// </summary>
        /// <value>Type of attachment</value>
        [MetaDataExtension (Description = "Type of attachment")]
        [MaxLength(255)]
        
        public string Type { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Attachment {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  FileName: ").Append(FileName).Append("\n");
            sb.Append("  FileContents: ").Append(FileContents).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return Equals((Attachment)obj);
        }

        /// <summary>
        /// Returns true if Attachment instances are equal
        /// </summary>
        /// <param name="other">Instance of Attachment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Attachment other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.FileName == other.FileName ||
                    this.FileName != null &&
                    this.FileName.Equals(other.FileName)
                ) &&                 
                (
                    this.FileContents == other.FileContents ||
                    this.FileContents != null &&
                    this.FileContents.Equals(other.FileContents)
                ) &&                 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) &&                 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
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
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.FileName != null)
                {
                    hash = hash * 59 + this.FileName.GetHashCode();
                }                
                                if (this.FileContents != null)
                {
                    hash = hash * 59 + this.FileContents.GetHashCode();
                }                
                                if (this.Description != null)
                {
                    hash = hash * 59 + this.Description.GetHashCode();
                }                
                                if (this.Type != null)
                {
                    hash = hash * 59 + this.Type.GetHashCode();
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
        public static bool operator ==(Attachment left, Attachment right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Attachment left, Attachment right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
