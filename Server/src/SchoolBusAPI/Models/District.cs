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
using SchoolBusAPI.Models;

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// The MOTI-defined Districts - must match the official MOTI List
    /// </summary>
        [MetaDataExtension (Description = "The MOTI-defined Districts - must match the official MOTI List")]

    public partial class District : AuditableEntity, IEquatable<District>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public District()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="District" /> class.
        /// </summary>
        /// <param name="Id">A system-generated unique identifier for a District (required).</param>
        /// <param name="MinistryDistrictID">The Ministry ID for the District (required).</param>
        /// <param name="Name">The name of the District (required).</param>
        /// <param name="Region">The region in which the District is found..</param>
        /// <param name="StartDate">The effective date of the District record - NOT CURRENTLY ENFORCED IN SCHOOL BUS.</param>
        /// <param name="EndDate">The end date of the District record; null if active - NOT CURRENTLY ENFORCED IN SCHOOL BUS.</param>
        public District(int Id, int MinistryDistrictID, string Name, Region Region = null, DateTime? StartDate = null, DateTime? EndDate = null)
        {   
            this.Id = Id;
            this.MinistryDistrictID = MinistryDistrictID;
            this.Name = Name;


            this.Region = Region;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        /// <summary>
        /// A system-generated unique identifier for a District
        /// </summary>
        /// <value>A system-generated unique identifier for a District</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for a District")]
        public int Id { get; set; }
        
        /// <summary>
        /// The Ministry ID for the District
        /// </summary>
        /// <value>The Ministry ID for the District</value>
        [MetaDataExtension (Description = "The Ministry ID for the District")]
        public int MinistryDistrictID { get; set; }
        
        /// <summary>
        /// The name of the District
        /// </summary>
        /// <value>The name of the District</value>
        [MetaDataExtension (Description = "The name of the District")]
        [MaxLength(255)]
        
        public string Name { get; set; }
        
        /// <summary>
        /// The region in which the District is found.
        /// </summary>
        /// <value>The region in which the District is found.</value>
        [MetaDataExtension (Description = "The region in which the District is found.")]
        public Region Region { get; set; }
        
        /// <summary>
        /// Foreign key for Region 
        /// </summary>       
        [ForeignKey("Region")]
        public int? RegionRefId { get; set; }
        
        /// <summary>
        /// The effective date of the District record - NOT CURRENTLY ENFORCED IN SCHOOL BUS
        /// </summary>
        /// <value>The effective date of the District record - NOT CURRENTLY ENFORCED IN SCHOOL BUS</value>
        [MetaDataExtension (Description = "The effective date of the District record - NOT CURRENTLY ENFORCED IN SCHOOL BUS")]
        public DateTime? StartDate { get; set; }
        
        /// <summary>
        /// The end date of the District record; null if active - NOT CURRENTLY ENFORCED IN SCHOOL BUS
        /// </summary>
        /// <value>The end date of the District record; null if active - NOT CURRENTLY ENFORCED IN SCHOOL BUS</value>
        [MetaDataExtension (Description = "The end date of the District record; null if active - NOT CURRENTLY ENFORCED IN SCHOOL BUS")]
        public DateTime? EndDate { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class District {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  MinistryDistrictID: ").Append(MinistryDistrictID).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Region: ").Append(Region).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
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
            return Equals((District)obj);
        }

        /// <summary>
        /// Returns true if District instances are equal
        /// </summary>
        /// <param name="other">Instance of District to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(District other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.MinistryDistrictID == other.MinistryDistrictID ||
                    this.MinistryDistrictID.Equals(other.MinistryDistrictID)
                ) &&                 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) &&                 
                (
                    this.Region == other.Region ||
                    this.Region != null &&
                    this.Region.Equals(other.Region)
                ) &&                 
                (
                    this.StartDate == other.StartDate ||
                    this.StartDate != null &&
                    this.StartDate.Equals(other.StartDate)
                ) &&                 
                (
                    this.EndDate == other.EndDate ||
                    this.EndDate != null &&
                    this.EndDate.Equals(other.EndDate)
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
                hash = hash * 59 + this.MinistryDistrictID.GetHashCode();                if (this.Name != null)
                {
                    hash = hash * 59 + this.Name.GetHashCode();
                }                
                                   
                if (this.Region != null)
                {
                    hash = hash * 59 + this.Region.GetHashCode();
                }                if (this.StartDate != null)
                {
                    hash = hash * 59 + this.StartDate.GetHashCode();
                }                
                                if (this.EndDate != null)
                {
                    hash = hash * 59 + this.EndDate.GetHashCode();
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
        public static bool operator ==(District left, District right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(District left, District right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
