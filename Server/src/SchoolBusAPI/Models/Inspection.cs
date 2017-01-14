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
        /// <param name="Id">Primary Key make this match the Inspection Details page (required).</param>
        /// <param name="SchoolBus">SchoolBus.</param>
        /// <param name="Inspector">Defaults for a new inspection to the current user, but can be changed as needed..</param>
        /// <param name="InspectionDate">The date the inspection was conducted..</param>
        /// <param name="InspectionType">The type of the inspection - enumerated type of Annual or Re-inspection, pulled from the School Bus record at the time the inspection record is created.</param>
        /// <param name="InspectionResult">The result of the inspection - enumerated type of Passed or Failed. The detailed results of the inspection are in RIP and not duplicated here..</param>
        /// <param name="Notes">A note about the inspection independent of what goes into the RIP inspection - this is just for the School Bus application..</param>
        /// <param name="Restrictions">The \&quot;Restrictions\&quot; text from the School Bus record. This is visible on the Inspections screen as a convenience for adjusting it prior to printing the Permit Page..</param>
        /// <param name="RIPInspectionId">The ID of the RIP inspection. The expectation is that the user will manually enter a RIP ID such that an external URL can be formed to allow the user to open the RIP inspection and see the inspection details..</param>
        public Inspection(int Id, SchoolBus SchoolBus = null, User Inspector = null, DateTime? InspectionDate = null, string InspectionType = null, string InspectionResult = null, string Notes = null, string Restrictions = null, string RIPInspectionId = null)
        {
            
            this.Id = Id;
            this.SchoolBus = SchoolBus;
            this.Inspector = Inspector;
            this.InspectionDate = InspectionDate;
            this.InspectionType = InspectionType;
            this.InspectionResult = InspectionResult;
            this.Notes = Notes;
            this.Restrictions = Restrictions;
            this.RIPInspectionId = RIPInspectionId;
            
        }

        /// <summary>
        /// Primary Key make this match the Inspection Details page
        /// </summary>
        /// <value>Primary Key make this match the Inspection Details page</value>
        [MetaDataExtension (Description = "Primary Key make this match the Inspection Details page")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBus
        /// </summary>
        public SchoolBus SchoolBus { get; set; }
        [ForeignKey("SchoolBus")]
        public int? SchoolBusRefId { get; set; }

        /// <summary>
        /// Defaults for a new inspection to the current user, but can be changed as needed.
        /// </summary>
        /// <value>Defaults for a new inspection to the current user, but can be changed as needed.</value>
        [MetaDataExtension (Description = "Defaults for a new inspection to the current user, but can be changed as needed.")]
        public User Inspector { get; set; }
        [ForeignKey("Inspector")]
        public int? InspectorRefId { get; set; }

        /// <summary>
        /// The date the inspection was conducted.
        /// </summary>
        /// <value>The date the inspection was conducted.</value>
        [MetaDataExtension (Description = "The date the inspection was conducted.")]
        public DateTime? InspectionDate { get; set; }

        /// <summary>
        /// The type of the inspection - enumerated type of Annual or Re-inspection, pulled from the School Bus record at the time the inspection record is created
        /// </summary>
        /// <value>The type of the inspection - enumerated type of Annual or Re-inspection, pulled from the School Bus record at the time the inspection record is created</value>
        [MetaDataExtension (Description = "The type of the inspection - enumerated type of Annual or Re-inspection, pulled from the School Bus record at the time the inspection record is created")]
        public string InspectionType { get; set; }

        /// <summary>
        /// The result of the inspection - enumerated type of Passed or Failed. The detailed results of the inspection are in RIP and not duplicated here.
        /// </summary>
        /// <value>The result of the inspection - enumerated type of Passed or Failed. The detailed results of the inspection are in RIP and not duplicated here.</value>
        [MetaDataExtension (Description = "The result of the inspection - enumerated type of Passed or Failed. The detailed results of the inspection are in RIP and not duplicated here.")]
        public string InspectionResult { get; set; }

        /// <summary>
        /// A note about the inspection independent of what goes into the RIP inspection - this is just for the School Bus application.
        /// </summary>
        /// <value>A note about the inspection independent of what goes into the RIP inspection - this is just for the School Bus application.</value>
        [MetaDataExtension (Description = "A note about the inspection independent of what goes into the RIP inspection - this is just for the School Bus application.")]
        public string Notes { get; set; }

        /// <summary>
        /// The \"Restrictions\" text from the School Bus record. This is visible on the Inspections screen as a convenience for adjusting it prior to printing the Permit Page.
        /// </summary>
        /// <value>The \"Restrictions\" text from the School Bus record. This is visible on the Inspections screen as a convenience for adjusting it prior to printing the Permit Page.</value>
        [MetaDataExtension (Description = "The &quot;Restrictions&quot; text from the School Bus record. This is visible on the Inspections screen as a convenience for adjusting it prior to printing the Permit Page.")]
        public string Restrictions { get; set; }

        /// <summary>
        /// The ID of the RIP inspection. The expectation is that the user will manually enter a RIP ID such that an external URL can be formed to allow the user to open the RIP inspection and see the inspection details.
        /// </summary>
        /// <value>The ID of the RIP inspection. The expectation is that the user will manually enter a RIP ID such that an external URL can be formed to allow the user to open the RIP inspection and see the inspection details.</value>
        [MetaDataExtension (Description = "The ID of the RIP inspection. The expectation is that the user will manually enter a RIP ID such that an external URL can be formed to allow the user to open the RIP inspection and see the inspection details.")]
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
            sb.Append("  SchoolBus: ").Append(SchoolBus).Append("\n");
            sb.Append("  Inspector: ").Append(Inspector).Append("\n");
            sb.Append("  InspectionDate: ").Append(InspectionDate).Append("\n");
            sb.Append("  InspectionType: ").Append(InspectionType).Append("\n");
            sb.Append("  InspectionResult: ").Append(InspectionResult).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  Restrictions: ").Append(Restrictions).Append("\n");
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
                    this.InspectionDate == other.InspectionDate ||
                    this.InspectionDate != null &&
                    this.InspectionDate.Equals(other.InspectionDate)
                ) && 
                (
                    this.InspectionType == other.InspectionType ||
                    this.InspectionType != null &&
                    this.InspectionType.Equals(other.InspectionType)
                ) && 
                (
                    this.InspectionResult == other.InspectionResult ||
                    this.InspectionResult != null &&
                    this.InspectionResult.Equals(other.InspectionResult)
                ) && 
                (
                    this.Notes == other.Notes ||
                    this.Notes != null &&
                    this.Notes.Equals(other.Notes)
                ) && 
                (
                    this.Restrictions == other.Restrictions ||
                    this.Restrictions != null &&
                    this.Restrictions.Equals(other.Restrictions)
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
                                
                if (this.SchoolBus != null)
                {
                    hash = hash * 59 + this.SchoolBus.GetHashCode();
                }
                if (this.Inspector != null)
                {
                    hash = hash * 59 + this.Inspector.GetHashCode();
                }
                if (this.InspectionDate != null)
                {
                    hash = hash * 59 + this.InspectionDate.GetHashCode();
                }
                if (this.InspectionType != null)
                {
                    hash = hash * 59 + this.InspectionType.GetHashCode();
                }
                if (this.InspectionResult != null)
                {
                    hash = hash * 59 + this.InspectionResult.GetHashCode();
                }
                if (this.Notes != null)
                {
                    hash = hash * 59 + this.Notes.GetHashCode();
                }
                if (this.Restrictions != null)
                {
                    hash = hash * 59 + this.Restrictions.GetHashCode();
                }
                if (this.RIPInspectionId != null)
                {
                    hash = hash * 59 + this.RIPInspectionId.GetHashCode();
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
