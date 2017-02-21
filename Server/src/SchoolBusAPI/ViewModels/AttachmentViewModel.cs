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

namespace SchoolBusAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class AttachmentViewModel : IEquatable<AttachmentViewModel>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public AttachmentViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentViewModel" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="FileName">Filename as passed by the user uploading the file.</param>
        /// <param name="Description">A note about the attachment,  optionally maintained by the user..</param>
        /// <param name="Type">Type of attachment.</param>
        public AttachmentViewModel(int Id, string FileName = null, string Description = null, string Type = null)
        {   
            this.Id = Id;
            this.FileName = FileName;
            this.Description = Description;
            this.Type = Type;
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name="id")]
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// Filename as passed by the user uploading the file
        /// </summary>
        /// <value>Filename as passed by the user uploading the file</value>
        [DataMember(Name="fileName")]
        [MetaDataExtension (Description = "Filename as passed by the user uploading the file")]
        public string FileName { get; set; }

        /// <summary>
        /// A note about the attachment,  optionally maintained by the user.
        /// </summary>
        /// <value>A note about the attachment,  optionally maintained by the user.</value>
        [DataMember(Name="description")]
        [MetaDataExtension (Description = "A note about the attachment,  optionally maintained by the user.")]
        public string Description { get; set; }

        /// <summary>
        /// Type of attachment
        /// </summary>
        /// <value>Type of attachment</value>
        [DataMember(Name="type")]
        [MetaDataExtension (Description = "Type of attachment")]
        public string Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AttachmentViewModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  FileName: ").Append(FileName).Append("\n");
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
            return Equals((AttachmentViewModel)obj);
        }

        /// <summary>
        /// Returns true if AttachmentViewModel instances are equal
        /// </summary>
        /// <param name="other">Instance of AttachmentViewModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AttachmentViewModel other)
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
        public static bool operator ==(AttachmentViewModel left, AttachmentViewModel right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(AttachmentViewModel left, AttachmentViewModel right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
