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
    /// School Bus inspection details supplementary to the RIP inspection
    /// </summary>
        [MetaDataExtension (Description = "School Bus inspection details supplementary to the RIP inspection")]

    public partial class Inspection : AuditableEntity,  IEquatable<Inspection>
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
        /// <param name="Id">A system-generated unique identifier for an Inspection (required).</param>
        /// <param name="InspectionDate">The date and time the inspection was conducted. (required).</param>
        /// <param name="InspectionTypeCode">The type of the inspection - enumerated type of Annual or Re-inspection,  pulled from the School Bus record at the time the inspection record is created (required).</param>
        /// <param name="InspectionResultCode">The result of the inspection - enumerated type of Passed or Failed. The detailed results of the inspection are in RIP and not duplicated here. (required).</param>
        /// <param name="CreatedDate">Record creation date and time (required).</param>
        /// <param name="SchoolBus">SchoolBus.</param>
        /// <param name="Inspector">Defaults for a new inspection to the current user,  but can be changed as needed..</param>
        /// <param name="Notes">A note about the inspection independent of what goes into the RIP inspection - this is just for the School Bus application..</param>
        /// <param name="RIPInspectionId">The ID of the RIP inspection. The expectation is that the user will manually enter a RIP ID such that an external URL can be formed to allow the user to open the RIP inspection and see the inspection details..</param>
        public Inspection(int Id, DateTime InspectionDate, string InspectionTypeCode, string InspectionResultCode, DateTime CreatedDate, SchoolBus SchoolBus = null, User Inspector = null, string Notes = null, string RIPInspectionId = null)
        {   
            this.Id = Id;
            this.InspectionDate = InspectionDate;
            this.InspectionTypeCode = InspectionTypeCode;
            this.InspectionResultCode = InspectionResultCode;
            this.CreatedDate = CreatedDate;




            this.SchoolBus = SchoolBus;
            this.Inspector = Inspector;
            this.Notes = Notes;
            this.RIPInspectionId = RIPInspectionId;
        }

        /// <summary>
        /// A system-generated unique identifier for an Inspection
        /// </summary>
        /// <value>A system-generated unique identifier for an Inspection</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for an Inspection")]
        public int Id { get; set; }
        
        /// <summary>
        /// The date and time the inspection was conducted.
        /// </summary>
        /// <value>The date and time the inspection was conducted.</value>
        [MetaDataExtension (Description = "The date and time the inspection was conducted.")]
        public DateTime InspectionDate { get; set; }
        
        /// <summary>
        /// The type of the inspection - enumerated type of Annual or Re-inspection,  pulled from the School Bus record at the time the inspection record is created
        /// </summary>
        /// <value>The type of the inspection - enumerated type of Annual or Re-inspection,  pulled from the School Bus record at the time the inspection record is created</value>
        [MetaDataExtension (Description = "The type of the inspection - enumerated type of Annual or Re-inspection,  pulled from the School Bus record at the time the inspection record is created")]
        [MaxLength(255)]
        
        public string InspectionTypeCode { get; set; }
        
        /// <summary>
        /// The result of the inspection - enumerated type of Passed or Failed. The detailed results of the inspection are in RIP and not duplicated here.
        /// </summary>
        /// <value>The result of the inspection - enumerated type of Passed or Failed. The detailed results of the inspection are in RIP and not duplicated here.</value>
        [MetaDataExtension (Description = "The result of the inspection - enumerated type of Passed or Failed. The detailed results of the inspection are in RIP and not duplicated here.")]
        [MaxLength(255)]
        
        public string InspectionResultCode { get; set; }
        
        /// <summary>
        /// Record creation date and time
        /// </summary>
        /// <value>Record creation date and time</value>
        [MetaDataExtension (Description = "Record creation date and time")]
        public DateTime CreatedDate { get; set; }
        
        /// <summary>
        /// Gets or Sets SchoolBus
        /// </summary>
        public SchoolBus SchoolBus { get; set; }
        
        /// <summary>
        /// Foreign key for SchoolBus 
        /// </summary>       
        [ForeignKey("SchoolBus")]
        public int? SchoolBusRefId { get; set; }
        
        /// <summary>
        /// Defaults for a new inspection to the current user,  but can be changed as needed.
        /// </summary>
        /// <value>Defaults for a new inspection to the current user,  but can be changed as needed.</value>
        [MetaDataExtension (Description = "Defaults for a new inspection to the current user,  but can be changed as needed.")]
        public User Inspector { get; set; }
        
        /// <summary>
        /// Foreign key for Inspector 
        /// </summary>       
        [ForeignKey("Inspector")]
        public int? InspectorRefId { get; set; }
        
        /// <summary>
        /// A note about the inspection independent of what goes into the RIP inspection - this is just for the School Bus application.
        /// </summary>
        /// <value>A note about the inspection independent of what goes into the RIP inspection - this is just for the School Bus application.</value>
        [MetaDataExtension (Description = "A note about the inspection independent of what goes into the RIP inspection - this is just for the School Bus application.")]
        [MaxLength(2048)]
        
        public string Notes { get; set; }
        
        /// <summary>
        /// The ID of the RIP inspection. The expectation is that the user will manually enter a RIP ID such that an external URL can be formed to allow the user to open the RIP inspection and see the inspection details.
        /// </summary>
        /// <value>The ID of the RIP inspection. The expectation is that the user will manually enter a RIP ID such that an external URL can be formed to allow the user to open the RIP inspection and see the inspection details.</value>
        [MetaDataExtension (Description = "The ID of the RIP inspection. The expectation is that the user will manually enter a RIP ID such that an external URL can be formed to allow the user to open the RIP inspection and see the inspection details.")]
        [MaxLength(255)]
        
        public string RIPInspectionId { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Inspection {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InspectionDate: ").Append(InspectionDate).Append("\n");
            sb.Append("  InspectionTypeCode: ").Append(InspectionTypeCode).Append("\n");
            sb.Append("  InspectionResultCode: ").Append(InspectionResultCode).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  SchoolBus: ").Append(SchoolBus).Append("\n");
            sb.Append("  Inspector: ").Append(Inspector).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  RIPInspectionId: ").Append(RIPInspectionId).Append("\n");
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
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.InspectionDate == other.InspectionDate ||
                    this.InspectionDate != null &&
                    this.InspectionDate.Equals(other.InspectionDate)
                ) &&                 
                (
                    this.InspectionTypeCode == other.InspectionTypeCode ||
                    this.InspectionTypeCode != null &&
                    this.InspectionTypeCode.Equals(other.InspectionTypeCode)
                ) &&                 
                (
                    this.InspectionResultCode == other.InspectionResultCode ||
                    this.InspectionResultCode != null &&
                    this.InspectionResultCode.Equals(other.InspectionResultCode)
                ) &&                 
                (
                    this.CreatedDate == other.CreatedDate ||
                    this.CreatedDate != null &&
                    this.CreatedDate.Equals(other.CreatedDate)
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
                ) &&                 
                (
                    this.Notes == other.Notes ||
                    this.Notes != null &&
                    this.Notes.Equals(other.Notes)
                ) &&                 
                (
                    this.RIPInspectionId == other.RIPInspectionId ||
                    this.RIPInspectionId != null &&
                    this.RIPInspectionId.Equals(other.RIPInspectionId)
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
                if (this.InspectionDate != null)
                {
                    hash = hash * 59 + this.InspectionDate.GetHashCode();
                }                if (this.InspectionTypeCode != null)
                {
                    hash = hash * 59 + this.InspectionTypeCode.GetHashCode();
                }                
                                if (this.InspectionResultCode != null)
                {
                    hash = hash * 59 + this.InspectionResultCode.GetHashCode();
                }                
                                   
                if (this.CreatedDate != null)
                {
                    hash = hash * 59 + this.CreatedDate.GetHashCode();
                }                   
                if (this.SchoolBus != null)
                {
                    hash = hash * 59 + this.SchoolBus.GetHashCode();
                }                   
                if (this.Inspector != null)
                {
                    hash = hash * 59 + this.Inspector.GetHashCode();
                }                if (this.Notes != null)
                {
                    hash = hash * 59 + this.Notes.GetHashCode();
                }                
                                if (this.RIPInspectionId != null)
                {
                    hash = hash * 59 + this.RIPInspectionId.GetHashCode();
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
        public static bool operator ==(Inspection left, Inspection right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Inspection left, Inspection right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
