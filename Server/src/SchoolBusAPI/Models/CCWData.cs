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
    public partial class CCWData :  IEquatable<CCWData>
    {

        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public CCWData()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CCWData" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="ModelYear">Vehicle Year.</param>
        /// <param name="RateClass">RateClass.</param>
        /// <param name="CVIPDecal">CVIPDecal.</param>
        /// <param name="FleetUnitNo">FleetUnitNo.</param>
        /// <param name="GVW">GVW.</param>
        /// <param name="Body">Body.</param>
        /// <param name="RebuiltStatus">RebuiltStatus.</param>
        /// <param name="CVIPExpiry">CVIPExpiry.</param>
        /// <param name="NetWt">NetWt.</param>
        /// <param name="Model">Model.</param>
        /// <param name="Fuel">Fuel.</param>
        /// <param name="SeatingCapacity">SeatingCapacity.</param>
        /// <param name="Colour">Colour.</param>
        public CCWData(int Id, int? ModelYear = null, string RateClass = null, string CVIPDecal = null, int? FleetUnitNo = null, int? GVW = null, string Body = null, string RebuiltStatus = null, DateTime? CVIPExpiry = null, int? NetWt = null, string Model = null, string Fuel = null, int? SeatingCapacity = null, string Colour = null)
        {
            
            this.Id = Id;            
            this.ModelYear = ModelYear;
            this.RateClass = RateClass;
            this.CVIPDecal = CVIPDecal;
            this.FleetUnitNo = FleetUnitNo;
            this.GVW = GVW;
            this.Body = Body;
            this.RebuiltStatus = RebuiltStatus;
            this.CVIPExpiry = CVIPExpiry;
            this.NetWt = NetWt;
            this.Model = Model;
            this.Fuel = Fuel;
            this.SeatingCapacity = SeatingCapacity;
            this.Colour = Colour;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name="id")]
        [MetaDataExtension (Description = "Primary Key")]        
        public int Id { get; set; }

        /// <summary>
        /// Vehicle Year
        /// </summary>
        /// <value>Vehicle Year</value>
        [DataMember(Name="ModelYear")]
        [MetaDataExtension (Description = "Vehicle Year")]        
        public int? ModelYear { get; set; }

        /// <summary>
        /// Gets or Sets RateClass
        /// </summary>
        [DataMember(Name="RateClass")]
                
        public string RateClass { get; set; }

        /// <summary>
        /// Gets or Sets CVIPDecal
        /// </summary>
        [DataMember(Name="CVIPDecal")]
                
        public string CVIPDecal { get; set; }

        /// <summary>
        /// Gets or Sets FleetUnitNo
        /// </summary>
        [DataMember(Name="FleetUnitNo")]
                
        public int? FleetUnitNo { get; set; }

        /// <summary>
        /// Gets or Sets GVW
        /// </summary>
        [DataMember(Name="GVW")]
                
        public int? GVW { get; set; }

        /// <summary>
        /// Gets or Sets Body
        /// </summary>
        [DataMember(Name="Body")]
                
        public string Body { get; set; }

        /// <summary>
        /// Gets or Sets RebuiltStatus
        /// </summary>
        [DataMember(Name="RebuiltStatus")]
                
        public string RebuiltStatus { get; set; }

        /// <summary>
        /// Gets or Sets CVIPExpiry
        /// </summary>
        [DataMember(Name="CVIPExpiry")]
                
        public DateTime? CVIPExpiry { get; set; }

        /// <summary>
        /// Gets or Sets NetWt
        /// </summary>
        [DataMember(Name="NetWt")]
                
        public int? NetWt { get; set; }

        /// <summary>
        /// Gets or Sets Model
        /// </summary>
        [DataMember(Name="Model")]
                
        public string Model { get; set; }

        /// <summary>
        /// Gets or Sets Fuel
        /// </summary>
        [DataMember(Name="Fuel")]
                
        public string Fuel { get; set; }

        /// <summary>
        /// Gets or Sets SeatingCapacity
        /// </summary>
        [DataMember(Name="SeatingCapacity")]
                
        public int? SeatingCapacity { get; set; }

        /// <summary>
        /// Gets or Sets Colour
        /// </summary>
        [DataMember(Name="Colour")]
                
        public string Colour { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CCWData {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ModelYear: ").Append(ModelYear).Append("\n");
            sb.Append("  RateClass: ").Append(RateClass).Append("\n");
            sb.Append("  CVIPDecal: ").Append(CVIPDecal).Append("\n");
            sb.Append("  FleetUnitNo: ").Append(FleetUnitNo).Append("\n");
            sb.Append("  GVW: ").Append(GVW).Append("\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("  RebuiltStatus: ").Append(RebuiltStatus).Append("\n");
            sb.Append("  CVIPExpiry: ").Append(CVIPExpiry).Append("\n");
            sb.Append("  NetWt: ").Append(NetWt).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  Fuel: ").Append(Fuel).Append("\n");
            sb.Append("  SeatingCapacity: ").Append(SeatingCapacity).Append("\n");
            sb.Append("  Colour: ").Append(Colour).Append("\n");
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
            return Equals((CCWData)obj);
        }

        /// <summary>
        /// Returns true if CCWData instances are equal
        /// </summary>
        /// <param name="other">Instance of CCWData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CCWData other)
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
                    this.ModelYear == other.ModelYear ||
                    this.ModelYear != null &&
                    this.ModelYear.Equals(other.ModelYear)
                ) && 
                (
                    this.RateClass == other.RateClass ||
                    this.RateClass != null &&
                    this.RateClass.Equals(other.RateClass)
                ) && 
                (
                    this.CVIPDecal == other.CVIPDecal ||
                    this.CVIPDecal != null &&
                    this.CVIPDecal.Equals(other.CVIPDecal)
                ) && 
                (
                    this.FleetUnitNo == other.FleetUnitNo ||
                    this.FleetUnitNo != null &&
                    this.FleetUnitNo.Equals(other.FleetUnitNo)
                ) && 
                (
                    this.GVW == other.GVW ||
                    this.GVW != null &&
                    this.GVW.Equals(other.GVW)
                ) && 
                (
                    this.Body == other.Body ||
                    this.Body != null &&
                    this.Body.Equals(other.Body)
                ) && 
                (
                    this.RebuiltStatus == other.RebuiltStatus ||
                    this.RebuiltStatus != null &&
                    this.RebuiltStatus.Equals(other.RebuiltStatus)
                ) && 
                (
                    this.CVIPExpiry == other.CVIPExpiry ||
                    this.CVIPExpiry != null &&
                    this.CVIPExpiry.Equals(other.CVIPExpiry)
                ) && 
                (
                    this.NetWt == other.NetWt ||
                    this.NetWt != null &&
                    this.NetWt.Equals(other.NetWt)
                ) && 
                (
                    this.Model == other.Model ||
                    this.Model != null &&
                    this.Model.Equals(other.Model)
                ) && 
                (
                    this.Fuel == other.Fuel ||
                    this.Fuel != null &&
                    this.Fuel.Equals(other.Fuel)
                ) && 
                (
                    this.SeatingCapacity == other.SeatingCapacity ||
                    this.SeatingCapacity != null &&
                    this.SeatingCapacity.Equals(other.SeatingCapacity)
                ) && 
                (
                    this.Colour == other.Colour ||
                    this.Colour != null &&
                    this.Colour.Equals(other.Colour)
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
                    if (this.ModelYear != null)
                    { 
                        hash = hash * 59 + this.ModelYear.GetHashCode();
                    }
                    if (this.RateClass != null)
                    { 
                        hash = hash * 59 + this.RateClass.GetHashCode();
                    }
                    if (this.CVIPDecal != null)
                    { 
                        hash = hash * 59 + this.CVIPDecal.GetHashCode();
                    }
                    if (this.FleetUnitNo != null)
                    { 
                        hash = hash * 59 + this.FleetUnitNo.GetHashCode();
                    }
                    if (this.GVW != null)
                    { 
                        hash = hash * 59 + this.GVW.GetHashCode();
                    }
                    if (this.Body != null)
                    { 
                        hash = hash * 59 + this.Body.GetHashCode();
                    }
                    if (this.RebuiltStatus != null)
                    { 
                        hash = hash * 59 + this.RebuiltStatus.GetHashCode();
                    }
                    if (this.CVIPExpiry != null)
                    { 
                        hash = hash * 59 + this.CVIPExpiry.GetHashCode();
                    }
                    if (this.NetWt != null)
                    { 
                        hash = hash * 59 + this.NetWt.GetHashCode();
                    }
                    if (this.Model != null)
                    { 
                        hash = hash * 59 + this.Model.GetHashCode();
                    }
                    if (this.Fuel != null)
                    { 
                        hash = hash * 59 + this.Fuel.GetHashCode();
                    }
                    if (this.SeatingCapacity != null)
                    { 
                        hash = hash * 59 + this.SeatingCapacity.GetHashCode();
                    }
                    if (this.Colour != null)
                    { 
                        hash = hash * 59 + this.Colour.GetHashCode();
                    }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(CCWData left, CCWData right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CCWData left, CCWData right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
