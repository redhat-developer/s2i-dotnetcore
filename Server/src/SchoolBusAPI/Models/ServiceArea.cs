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
    /// 
    /// </summary>

    public partial class ServiceArea : IEquatable<ServiceArea>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public ServiceArea()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceArea" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="MinistryServiceAreaID">The Ministry ID for the Service Area.</param>
        /// <param name="Name">The name of the Service Area.</param>
        /// <param name="District">The district in which the Service Area is found..</param>
        /// <param name="StartDate">The effective date of the Service Area - NOT CURRENTLY ENFORCED IN SCHOOL BUS.</param>
        /// <param name="EndDate">The end date of the Service Area; null if active - NOT CURRENTLY ENFORCED IN SCHOOL BUS.</param>
        public ServiceArea(int Id, int? MinistryServiceAreaID = null, string Name = null, District District = null, DateTime? StartDate = null, DateTime? EndDate = null)
        {   
            this.Id = Id;
            this.MinistryServiceAreaID = MinistryServiceAreaID;
            this.Name = Name;
            this.District = District;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }
        
        /// <summary>
        /// The Ministry ID for the Service Area
        /// </summary>
        /// <value>The Ministry ID for the Service Area</value>
        [MetaDataExtension (Description = "The Ministry ID for the Service Area")]
        public int? MinistryServiceAreaID { get; set; }
        
        /// <summary>
        /// The name of the Service Area
        /// </summary>
        /// <value>The name of the Service Area</value>
        [MetaDataExtension (Description = "The name of the Service Area")]
        [MaxLength(255)]
        
        public string Name { get; set; }
        
        /// <summary>
        /// The district in which the Service Area is found.
        /// </summary>
        /// <value>The district in which the Service Area is found.</value>
        [MetaDataExtension (Description = "The district in which the Service Area is found.")]
        public District District { get; set; }
        
        /// <summary>
        /// Foreign key for District 
        /// </summary>       
        [ForeignKey("District")]
        public int? DistrictRefId { get; set; }
        
        /// <summary>
        /// The effective date of the Service Area - NOT CURRENTLY ENFORCED IN SCHOOL BUS
        /// </summary>
        /// <value>The effective date of the Service Area - NOT CURRENTLY ENFORCED IN SCHOOL BUS</value>
        [MetaDataExtension (Description = "The effective date of the Service Area - NOT CURRENTLY ENFORCED IN SCHOOL BUS")]
        public DateTime? StartDate { get; set; }
        
        /// <summary>
        /// The end date of the Service Area; null if active - NOT CURRENTLY ENFORCED IN SCHOOL BUS
        /// </summary>
        /// <value>The end date of the Service Area; null if active - NOT CURRENTLY ENFORCED IN SCHOOL BUS</value>
        [MetaDataExtension (Description = "The end date of the Service Area; null if active - NOT CURRENTLY ENFORCED IN SCHOOL BUS")]
        public DateTime? EndDate { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ServiceArea {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  MinistryServiceAreaID: ").Append(MinistryServiceAreaID).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  District: ").Append(District).Append("\n");
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
            return Equals((ServiceArea)obj);
        }

        /// <summary>
        /// Returns true if ServiceArea instances are equal
        /// </summary>
        /// <param name="other">Instance of ServiceArea to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ServiceArea other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.MinistryServiceAreaID == other.MinistryServiceAreaID ||
                    this.MinistryServiceAreaID != null &&
                    this.MinistryServiceAreaID.Equals(other.MinistryServiceAreaID)
                ) &&                 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) &&                 
                (
                    this.District == other.District ||
                    this.District != null &&
                    this.District.Equals(other.District)
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
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.MinistryServiceAreaID != null)
                {
                    hash = hash * 59 + this.MinistryServiceAreaID.GetHashCode();
                }                
                                if (this.Name != null)
                {
                    hash = hash * 59 + this.Name.GetHashCode();
                }                
                                   
                if (this.District != null)
                {
                    hash = hash * 59 + this.District.GetHashCode();
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
        public static bool operator ==(ServiceArea left, ServiceArea right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ServiceArea left, ServiceArea right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
