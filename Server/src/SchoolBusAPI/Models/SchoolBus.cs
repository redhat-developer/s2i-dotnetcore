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
        /// Initializes a new instance of the <see cref="SchoolBus" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="Owner">Owner.</param>
        /// <param name="CRNO">CR Number..</param>
        /// <param name="LesseeNumber">LesseeNumber.</param>
        /// <param name="LicenseExpiryDate">LicenseExpiryDate.</param>
        /// <param name="PermitExpiryDate">PermitExpiryDate.</param>
        /// <param name="NextInspectionDate">NextInspectionDate.</param>
        /// <param name="ManYear">ManYear.</param>
        /// <param name="SBCap">SBCap.</param>
        /// <param name="MCCap">MCCap.</param>
        /// <param name="WCCap">WCCap.</param>
        /// <param name="LastUpdate">LastUpdate.</param>
        /// <param name="Plate">Plate.</param>
        /// <param name="CCWData">CCWData.</param>
        public SchoolBus(int Id, Owner Owner = null, string CRNO = null, int? LesseeNumber = null, DateTime? LicenseExpiryDate = null, DateTime? PermitExpiryDate = null, DateTime? NextInspectionDate = null, int? ManYear = null, string SBCap = null, string MCCap = null, string WCCap = null, DateTime? LastUpdate = null, string Plate = null, CCWData CCWData = null)
        {
            
            this.Id = Id;            
            this.Owner = Owner;
            this.CRNO = CRNO;
            this.LesseeNumber = LesseeNumber;
            this.LicenseExpiryDate = LicenseExpiryDate;
            this.PermitExpiryDate = PermitExpiryDate;
            this.NextInspectionDate = NextInspectionDate;
            this.ManYear = ManYear;
            this.SBCap = SBCap;
            this.MCCap = MCCap;
            this.WCCap = WCCap;
            this.LastUpdate = LastUpdate;
            this.Plate = Plate;
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
        /// Gets or Sets Owner
        /// </summary>
        [DataMember(Name="Owner")]
                
        public Owner Owner { get; set; }

        /// <summary>
        /// CR Number.
        /// </summary>
        /// <value>CR Number.</value>
        [DataMember(Name="CRNO")]
        [MetaDataExtension (Description = "CR Number.")]        
        public string CRNO { get; set; }

        /// <summary>
        /// Gets or Sets LesseeNumber
        /// </summary>
        [DataMember(Name="LesseeNumber")]
                
        public int? LesseeNumber { get; set; }

        /// <summary>
        /// Gets or Sets LicenseExpiryDate
        /// </summary>
        [DataMember(Name="LicenseExpiryDate")]
                
        public DateTime? LicenseExpiryDate { get; set; }

        /// <summary>
        /// Gets or Sets PermitExpiryDate
        /// </summary>
        [DataMember(Name="PermitExpiryDate")]
                
        public DateTime? PermitExpiryDate { get; set; }

        /// <summary>
        /// Gets or Sets NextInspectionDate
        /// </summary>
        [DataMember(Name="NextInspectionDate")]
                
        public DateTime? NextInspectionDate { get; set; }

        /// <summary>
        /// Gets or Sets ManYear
        /// </summary>
        [DataMember(Name="ManYear")]
                
        public int? ManYear { get; set; }

        /// <summary>
        /// Gets or Sets SBCap
        /// </summary>
        [DataMember(Name="SB_Cap")]
                
        public string SBCap { get; set; }

        /// <summary>
        /// Gets or Sets MCCap
        /// </summary>
        [DataMember(Name="MC_Cap")]
                
        public string MCCap { get; set; }

        /// <summary>
        /// Gets or Sets WCCap
        /// </summary>
        [DataMember(Name="WC_Cap")]
                
        public string WCCap { get; set; }

        /// <summary>
        /// Gets or Sets LastUpdate
        /// </summary>
        [DataMember(Name="LastUpdate")]
                
        public DateTime? LastUpdate { get; set; }

        /// <summary>
        /// Gets or Sets Plate
        /// </summary>
        [DataMember(Name="Plate")]
                
        public string Plate { get; set; }

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
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  CRNO: ").Append(CRNO).Append("\n");
            sb.Append("  LesseeNumber: ").Append(LesseeNumber).Append("\n");
            sb.Append("  LicenseExpiryDate: ").Append(LicenseExpiryDate).Append("\n");
            sb.Append("  PermitExpiryDate: ").Append(PermitExpiryDate).Append("\n");
            sb.Append("  NextInspectionDate: ").Append(NextInspectionDate).Append("\n");
            sb.Append("  ManYear: ").Append(ManYear).Append("\n");
            sb.Append("  SBCap: ").Append(SBCap).Append("\n");
            sb.Append("  MCCap: ").Append(MCCap).Append("\n");
            sb.Append("  WCCap: ").Append(WCCap).Append("\n");
            sb.Append("  LastUpdate: ").Append(LastUpdate).Append("\n");
            sb.Append("  Plate: ").Append(Plate).Append("\n");
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
                    this.Id == other.Id &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Owner == other.Owner ||
                    this.Owner != null &&
                    this.Owner.Equals(other.Owner)
                ) && 
                (
                    this.CRNO == other.CRNO ||
                    this.CRNO != null &&
                    this.CRNO.Equals(other.CRNO)
                ) && 
                (
                    this.LesseeNumber == other.LesseeNumber ||
                    this.LesseeNumber != null &&
                    this.LesseeNumber.Equals(other.LesseeNumber)
                ) && 
                (
                    this.LicenseExpiryDate == other.LicenseExpiryDate ||
                    this.LicenseExpiryDate != null &&
                    this.LicenseExpiryDate.Equals(other.LicenseExpiryDate)
                ) && 
                (
                    this.PermitExpiryDate == other.PermitExpiryDate ||
                    this.PermitExpiryDate != null &&
                    this.PermitExpiryDate.Equals(other.PermitExpiryDate)
                ) && 
                (
                    this.NextInspectionDate == other.NextInspectionDate ||
                    this.NextInspectionDate != null &&
                    this.NextInspectionDate.Equals(other.NextInspectionDate)
                ) && 
                (
                    this.ManYear == other.ManYear ||
                    this.ManYear != null &&
                    this.ManYear.Equals(other.ManYear)
                ) && 
                (
                    this.SBCap == other.SBCap ||
                    this.SBCap != null &&
                    this.SBCap.Equals(other.SBCap)
                ) && 
                (
                    this.MCCap == other.MCCap ||
                    this.MCCap != null &&
                    this.MCCap.Equals(other.MCCap)
                ) && 
                (
                    this.WCCap == other.WCCap ||
                    this.WCCap != null &&
                    this.WCCap.Equals(other.WCCap)
                ) && 
                (
                    this.LastUpdate == other.LastUpdate ||
                    this.LastUpdate != null &&
                    this.LastUpdate.Equals(other.LastUpdate)
                ) && 
                (
                    this.Plate == other.Plate ||
                    this.Plate != null &&
                    this.Plate.Equals(other.Plate)
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
                    if (this.Owner != null)
                    { 
                        hash = hash * 59 + this.Owner.GetHashCode();
                    }
                    if (this.CRNO != null)
                    { 
                        hash = hash * 59 + this.CRNO.GetHashCode();
                    }
                    if (this.LesseeNumber != null)
                    { 
                        hash = hash * 59 + this.LesseeNumber.GetHashCode();
                    }
                    if (this.LicenseExpiryDate != null)
                    { 
                        hash = hash * 59 + this.LicenseExpiryDate.GetHashCode();
                    }
                    if (this.PermitExpiryDate != null)
                    { 
                        hash = hash * 59 + this.PermitExpiryDate.GetHashCode();
                    }
                    if (this.NextInspectionDate != null)
                    { 
                        hash = hash * 59 + this.NextInspectionDate.GetHashCode();
                    }
                    if (this.ManYear != null)
                    { 
                        hash = hash * 59 + this.ManYear.GetHashCode();
                    }
                    if (this.SBCap != null)
                    { 
                        hash = hash * 59 + this.SBCap.GetHashCode();
                    }
                    if (this.MCCap != null)
                    { 
                        hash = hash * 59 + this.MCCap.GetHashCode();
                    }
                    if (this.WCCap != null)
                    { 
                        hash = hash * 59 + this.WCCap.GetHashCode();
                    }
                    if (this.LastUpdate != null)
                    { 
                        hash = hash * 59 + this.LastUpdate.GetHashCode();
                    }
                    if (this.Plate != null)
                    { 
                        hash = hash * 59 + this.Plate.GetHashCode();
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
