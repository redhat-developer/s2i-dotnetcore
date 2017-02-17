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
    /// The contents of the Jurisdiction table from CCW so that the user can select a Jurisdiction for passing to CCW on certain Out of Province School Bus Web Service calls
    /// </summary>
        [MetaDataExtension (Description = "The contents of the Jurisdiction table from CCW so that the user can select a Jurisdiction for passing to CCW on certain Out of Province School Bus Web Service calls")]

    public partial class CCWJurisdiction : IEquatable<CCWJurisdiction>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public CCWJurisdiction()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CCWJurisdiction" /> class.
        /// </summary>
        /// <param name="Id">A system-generated unique identifier for a CCWJurisdiction (required).</param>
        /// <param name="JurisdictionId">The CCW system-generated unique identifier for a CCWJurisdiction. Needed for updating the table from CCW if necessary..</param>
        /// <param name="EffectiveDate">The effective date of the CCWJurisdiction record - NOT CURRENTLY ENFORCED IN SCHOOL BUS.</param>
        /// <param name="ExpiryDate">The end date of the CCWJurisdiction record; null if active - NOT CURRENTLY ENFORCED IN SCHOOL BUS.</param>
        /// <param name="ActiveFlag">Flag from CCW indicating if the record is still active - Y indicating it is active. NOT CURRENTLY ENFORCED IN SCHOOL BUS.</param>
        /// <param name="Code">A short version of the Jurisdiction - the familiar two-letter province or state code.</param>
        /// <param name="Description">The full version of the Jurisdiction name..</param>
        public CCWJurisdiction(int Id, int? JurisdictionId = null, DateTime? EffectiveDate = null, DateTime? ExpiryDate = null, bool? ActiveFlag = null, string Code = null, string Description = null)
        {   
            this.Id = Id;
            this.JurisdictionId = JurisdictionId;
            this.EffectiveDate = EffectiveDate;
            this.ExpiryDate = ExpiryDate;
            this.ActiveFlag = ActiveFlag;
            this.Code = Code;
            this.Description = Description;
        }

        /// <summary>
        /// A system-generated unique identifier for a CCWJurisdiction
        /// </summary>
        /// <value>A system-generated unique identifier for a CCWJurisdiction</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for a CCWJurisdiction")]
        public int Id { get; set; }
        
        /// <summary>
        /// The CCW system-generated unique identifier for a CCWJurisdiction. Needed for updating the table from CCW if necessary.
        /// </summary>
        /// <value>The CCW system-generated unique identifier for a CCWJurisdiction. Needed for updating the table from CCW if necessary.</value>
        [MetaDataExtension (Description = "The CCW system-generated unique identifier for a CCWJurisdiction. Needed for updating the table from CCW if necessary.")]
        public int? JurisdictionId { get; set; }
        
        /// <summary>
        /// The effective date of the CCWJurisdiction record - NOT CURRENTLY ENFORCED IN SCHOOL BUS
        /// </summary>
        /// <value>The effective date of the CCWJurisdiction record - NOT CURRENTLY ENFORCED IN SCHOOL BUS</value>
        [MetaDataExtension (Description = "The effective date of the CCWJurisdiction record - NOT CURRENTLY ENFORCED IN SCHOOL BUS")]
        public DateTime? EffectiveDate { get; set; }
        
        /// <summary>
        /// The end date of the CCWJurisdiction record; null if active - NOT CURRENTLY ENFORCED IN SCHOOL BUS
        /// </summary>
        /// <value>The end date of the CCWJurisdiction record; null if active - NOT CURRENTLY ENFORCED IN SCHOOL BUS</value>
        [MetaDataExtension (Description = "The end date of the CCWJurisdiction record; null if active - NOT CURRENTLY ENFORCED IN SCHOOL BUS")]
        public DateTime? ExpiryDate { get; set; }
        
        /// <summary>
        /// Flag from CCW indicating if the record is still active - Y indicating it is active. NOT CURRENTLY ENFORCED IN SCHOOL BUS
        /// </summary>
        /// <value>Flag from CCW indicating if the record is still active - Y indicating it is active. NOT CURRENTLY ENFORCED IN SCHOOL BUS</value>
        [MetaDataExtension (Description = "Flag from CCW indicating if the record is still active - Y indicating it is active. NOT CURRENTLY ENFORCED IN SCHOOL BUS")]
        public bool? ActiveFlag { get; set; }
        
        /// <summary>
        /// A short version of the Jurisdiction - the familiar two-letter province or state code
        /// </summary>
        /// <value>A short version of the Jurisdiction - the familiar two-letter province or state code</value>
        [MetaDataExtension (Description = "A short version of the Jurisdiction - the familiar two-letter province or state code")]
        [MaxLength(10)]
        
        public string Code { get; set; }
        
        /// <summary>
        /// The full version of the Jurisdiction name.
        /// </summary>
        /// <value>The full version of the Jurisdiction name.</value>
        [MetaDataExtension (Description = "The full version of the Jurisdiction name.")]
        [MaxLength(50)]
        
        public string Description { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CCWJurisdiction {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  JurisdictionId: ").Append(JurisdictionId).Append("\n");
            sb.Append("  EffectiveDate: ").Append(EffectiveDate).Append("\n");
            sb.Append("  ExpiryDate: ").Append(ExpiryDate).Append("\n");
            sb.Append("  ActiveFlag: ").Append(ActiveFlag).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return Equals((CCWJurisdiction)obj);
        }

        /// <summary>
        /// Returns true if CCWJurisdiction instances are equal
        /// </summary>
        /// <param name="other">Instance of CCWJurisdiction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CCWJurisdiction other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.JurisdictionId == other.JurisdictionId ||
                    this.JurisdictionId != null &&
                    this.JurisdictionId.Equals(other.JurisdictionId)
                ) &&                 
                (
                    this.EffectiveDate == other.EffectiveDate ||
                    this.EffectiveDate != null &&
                    this.EffectiveDate.Equals(other.EffectiveDate)
                ) &&                 
                (
                    this.ExpiryDate == other.ExpiryDate ||
                    this.ExpiryDate != null &&
                    this.ExpiryDate.Equals(other.ExpiryDate)
                ) &&                 
                (
                    this.ActiveFlag == other.ActiveFlag ||
                    this.ActiveFlag != null &&
                    this.ActiveFlag.Equals(other.ActiveFlag)
                ) &&                 
                (
                    this.Code == other.Code ||
                    this.Code != null &&
                    this.Code.Equals(other.Code)
                ) &&                 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
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
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.JurisdictionId != null)
                {
                    hash = hash * 59 + this.JurisdictionId.GetHashCode();
                }                
                                if (this.EffectiveDate != null)
                {
                    hash = hash * 59 + this.EffectiveDate.GetHashCode();
                }                
                                if (this.ExpiryDate != null)
                {
                    hash = hash * 59 + this.ExpiryDate.GetHashCode();
                }                
                                if (this.ActiveFlag != null)
                {
                    hash = hash * 59 + this.ActiveFlag.GetHashCode();
                }                
                                if (this.Code != null)
                {
                    hash = hash * 59 + this.Code.GetHashCode();
                }                
                                if (this.Description != null)
                {
                    hash = hash * 59 + this.Description.GetHashCode();
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
        public static bool operator ==(CCWJurisdiction left, CCWJurisdiction right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(CCWJurisdiction left, CCWJurisdiction right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
