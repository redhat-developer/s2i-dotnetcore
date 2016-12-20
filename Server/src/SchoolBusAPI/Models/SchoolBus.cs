/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
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
    /// 
    /// </summary>
    [DataContract]
    public partial class SchoolBus :  IEquatable<SchoolBus>
    {

        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public SchoolBus()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolBus" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="SchoolBusOwner">SchoolBusOwner.</param>
        /// <param name="IsActive">IsActive.</param>
        /// <param name="IsOutOfProvince">IsOutOfProvince.</param>
        /// <param name="NextInspection">NextInspection.</param>
        /// <param name="CRNO">CR Number..</param>
        /// <param name="NameOfIndependentSchool">NameOfIndependentSchool.</param>
        /// <param name="CCWData">CCWData.</param>
        public SchoolBus(int Id, SchoolBusOwner SchoolBusOwner = null, bool? IsActive = null, bool? IsOutOfProvince = null, DateTime? NextInspection = null, string CRNO = null, string NameOfIndependentSchool = null, CCWData CCWData = null)
        {
            
            this.Id = Id;            
            this.SchoolBusOwner = SchoolBusOwner;
            this.IsActive = IsActive;
            this.IsOutOfProvince = IsOutOfProvince;
            this.NextInspection = NextInspection;
            this.CRNO = CRNO;
            this.NameOfIndependentSchool = NameOfIndependentSchool;
            this.CCWData = CCWData;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name="id")]
        [MetaDataExtension (Description = "Primary Key")]        
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusOwner
        /// </summary>
        [DataMember(Name="SchoolBusOwner")]
                
        public SchoolBusOwner SchoolBusOwner { get; set; }

        /// <summary>
        /// Gets or Sets IsActive
        /// </summary>
        [DataMember(Name="IsActive")]
                
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or Sets IsOutOfProvince
        /// </summary>
        [DataMember(Name="IsOutOfProvince")]
                
        public bool? IsOutOfProvince { get; set; }

        /// <summary>
        /// Gets or Sets NextInspection
        /// </summary>
        [DataMember(Name="NextInspection")]
                
        public DateTime? NextInspection { get; set; }

        /// <summary>
        /// CR Number.
        /// </summary>
        /// <value>CR Number.</value>
        [DataMember(Name="CRNO")]
        [MetaDataExtension (Description = "CR Number.")]        
        public string CRNO { get; set; }

        /// <summary>
        /// Gets or Sets NameOfIndependentSchool
        /// </summary>
        [DataMember(Name="NameOfIndependentSchool")]
                
        public string NameOfIndependentSchool { get; set; }

        /// <summary>
        /// Gets or Sets CCWData
        /// </summary>
        [DataMember(Name="CCWData")]
                
        public CCWData CCWData { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchoolBus {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  SchoolBusOwner: ").Append(SchoolBusOwner).Append("\n");
            sb.Append("  IsActive: ").Append(IsActive).Append("\n");
            sb.Append("  IsOutOfProvince: ").Append(IsOutOfProvince).Append("\n");
            sb.Append("  NextInspection: ").Append(NextInspection).Append("\n");
            sb.Append("  CRNO: ").Append(CRNO).Append("\n");
            sb.Append("  NameOfIndependentSchool: ").Append(NameOfIndependentSchool).Append("\n");
            sb.Append("  CCWData: ").Append(CCWData).Append("\n");
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
            return Equals((SchoolBus)obj);
        }

        /// <summary>
        /// Returns true if SchoolBus instances are equal
        /// </summary>
        /// <param name="other">Instance of SchoolBus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchoolBus other)
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
                    this.SchoolBusOwner == other.SchoolBusOwner ||
                    this.SchoolBusOwner != null &&
                    this.SchoolBusOwner.Equals(other.SchoolBusOwner)
                ) && 
                (
                    this.IsActive == other.IsActive ||
                    this.IsActive != null &&
                    this.IsActive.Equals(other.IsActive)
                ) && 
                (
                    this.IsOutOfProvince == other.IsOutOfProvince ||
                    this.IsOutOfProvince != null &&
                    this.IsOutOfProvince.Equals(other.IsOutOfProvince)
                ) && 
                (
                    this.NextInspection == other.NextInspection ||
                    this.NextInspection != null &&
                    this.NextInspection.Equals(other.NextInspection)
                ) && 
                (
                    this.CRNO == other.CRNO ||
                    this.CRNO != null &&
                    this.CRNO.Equals(other.CRNO)
                ) && 
                (
                    this.NameOfIndependentSchool == other.NameOfIndependentSchool ||
                    this.NameOfIndependentSchool != null &&
                    this.NameOfIndependentSchool.Equals(other.NameOfIndependentSchool)
                ) && 
                (
                    this.CCWData == other.CCWData ||
                    this.CCWData != null &&
                    this.CCWData.Equals(other.CCWData)
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
                    if (this.SchoolBusOwner != null)
                    { 
                        hash = hash * 59 + this.SchoolBusOwner.GetHashCode();
                    }
                    if (this.IsActive != null)
                    { 
                        hash = hash * 59 + this.IsActive.GetHashCode();
                    }
                    if (this.IsOutOfProvince != null)
                    { 
                        hash = hash * 59 + this.IsOutOfProvince.GetHashCode();
                    }
                    if (this.NextInspection != null)
                    { 
                        hash = hash * 59 + this.NextInspection.GetHashCode();
                    }
                    if (this.CRNO != null)
                    { 
                        hash = hash * 59 + this.CRNO.GetHashCode();
                    }
                    if (this.NameOfIndependentSchool != null)
                    { 
                        hash = hash * 59 + this.NameOfIndependentSchool.GetHashCode();
                    }
                    if (this.CCWData != null)
                    { 
                        hash = hash * 59 + this.CCWData.GetHashCode();
                    }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(SchoolBus left, SchoolBus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SchoolBus left, SchoolBus right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
