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
    public partial class Owner :  IEquatable<Owner>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Owner" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="FleetNum">FleetNum.</param>
        /// <param name="MCCode">MCCode.</param>
        /// <param name="FleetSize">FleetSize.</param>
        /// <param name="HasBuses">HasBuses.</param>
        /// <param name="Diff">Diff.</param>
        /// <param name="LeaseSize">LeaseSize.</param>
        /// <param name="HasDups">HasDups.</param>
        /// <param name="SchoolDistrict">SchoolDistrict.</param>
        /// <param name="City">City.</param>
        public Owner(int Id, int? FleetNum = null, string MCCode = null, string FleetSize = null, int? HasBuses = null, string Diff = null, string LeaseSize = null, int? HasDups = null, SchoolDistrict SchoolDistrict = null, City City = null)
        {
            
            this.Id = Id;            
            this.FleetNum = FleetNum;
            this.MCCode = MCCode;
            this.FleetSize = FleetSize;
            this.HasBuses = HasBuses;
            this.Diff = Diff;
            this.LeaseSize = LeaseSize;
            this.HasDups = HasDups;
            this.SchoolDistrict = SchoolDistrict;
            this.City = City;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name="id")]
        [MetaDataExtension (Description = "Primary Key")]        
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets FleetNum
        /// </summary>
        [DataMember(Name="FleetNum")]
                
        public int? FleetNum { get; set; }

        /// <summary>
        /// Gets or Sets MCCode
        /// </summary>
        [DataMember(Name="MCCode")]
                
        public string MCCode { get; set; }

        /// <summary>
        /// Gets or Sets FleetSize
        /// </summary>
        [DataMember(Name="FleetSize")]
                
        public string FleetSize { get; set; }

        /// <summary>
        /// Gets or Sets HasBuses
        /// </summary>
        [DataMember(Name="HasBuses")]
                
        public int? HasBuses { get; set; }

        /// <summary>
        /// Gets or Sets Diff
        /// </summary>
        [DataMember(Name="Diff")]
                
        public string Diff { get; set; }

        /// <summary>
        /// Gets or Sets LeaseSize
        /// </summary>
        [DataMember(Name="LeaseSize")]
                
        public string LeaseSize { get; set; }

        /// <summary>
        /// Gets or Sets HasDups
        /// </summary>
        [DataMember(Name="HasDups")]
                
        public int? HasDups { get; set; }

        /// <summary>
        /// Gets or Sets SchoolDistrict
        /// </summary>
        [DataMember(Name="SchoolDistrict")]
                
        public SchoolDistrict SchoolDistrict { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        [DataMember(Name="City")]
                
        public City City { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Owner {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  FleetNum: ").Append(FleetNum).Append("\n");
            sb.Append("  MCCode: ").Append(MCCode).Append("\n");
            sb.Append("  FleetSize: ").Append(FleetSize).Append("\n");
            sb.Append("  HasBuses: ").Append(HasBuses).Append("\n");
            sb.Append("  Diff: ").Append(Diff).Append("\n");
            sb.Append("  LeaseSize: ").Append(LeaseSize).Append("\n");
            sb.Append("  HasDups: ").Append(HasDups).Append("\n");
            sb.Append("  SchoolDistrict: ").Append(SchoolDistrict).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
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
            return Equals((Owner)obj);
        }

        /// <summary>
        /// Returns true if Owner instances are equal
        /// </summary>
        /// <param name="other">Instance of Owner to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Owner other)
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
                    this.FleetNum == other.FleetNum ||
                    this.FleetNum != null &&
                    this.FleetNum.Equals(other.FleetNum)
                ) && 
                (
                    this.MCCode == other.MCCode ||
                    this.MCCode != null &&
                    this.MCCode.Equals(other.MCCode)
                ) && 
                (
                    this.FleetSize == other.FleetSize ||
                    this.FleetSize != null &&
                    this.FleetSize.Equals(other.FleetSize)
                ) && 
                (
                    this.HasBuses == other.HasBuses ||
                    this.HasBuses != null &&
                    this.HasBuses.Equals(other.HasBuses)
                ) && 
                (
                    this.Diff == other.Diff ||
                    this.Diff != null &&
                    this.Diff.Equals(other.Diff)
                ) && 
                (
                    this.LeaseSize == other.LeaseSize ||
                    this.LeaseSize != null &&
                    this.LeaseSize.Equals(other.LeaseSize)
                ) && 
                (
                    this.HasDups == other.HasDups ||
                    this.HasDups != null &&
                    this.HasDups.Equals(other.HasDups)
                ) && 
                (
                    this.SchoolDistrict == other.SchoolDistrict ||
                    this.SchoolDistrict != null &&
                    this.SchoolDistrict.Equals(other.SchoolDistrict)
                ) && 
                (
                    this.City == other.City ||
                    this.City != null &&
                    this.City.Equals(other.City)
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
                    if (this.FleetNum != null)
                    { 
                        hash = hash * 59 + this.FleetNum.GetHashCode();
                    }
                    if (this.MCCode != null)
                    { 
                        hash = hash * 59 + this.MCCode.GetHashCode();
                    }
                    if (this.FleetSize != null)
                    { 
                        hash = hash * 59 + this.FleetSize.GetHashCode();
                    }
                    if (this.HasBuses != null)
                    { 
                        hash = hash * 59 + this.HasBuses.GetHashCode();
                    }
                    if (this.Diff != null)
                    { 
                        hash = hash * 59 + this.Diff.GetHashCode();
                    }
                    if (this.LeaseSize != null)
                    { 
                        hash = hash * 59 + this.LeaseSize.GetHashCode();
                    }
                    if (this.HasDups != null)
                    { 
                        hash = hash * 59 + this.HasDups.GetHashCode();
                    }
                    if (this.SchoolDistrict != null)
                    { 
                        hash = hash * 59 + this.SchoolDistrict.GetHashCode();
                    }
                    if (this.City != null)
                    { 
                        hash = hash * 59 + this.City.GetHashCode();
                    }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Owner left, Owner right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Owner left, Owner right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
