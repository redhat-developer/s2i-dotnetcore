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

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// The School Bus entity, including only information that is of specific interest to the School Bus inspector and not tracked in other systems such as ICBC or NSC
    /// </summary>
    public partial class SchoolBus : IEquatable<SchoolBus>
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
        /// <param name="Regi">The ICBC Registration number for the School Bus.</param>
        /// <param name="Plate">The ICBC Plate Number for the School Bus.</param>
        /// <param name="VIN">The VIN for the School Bus.</param>
        /// <param name="SchoolBusOwner">SchoolBusOwner.</param>
        /// <param name="PermitNumber">The (generated) permit number for the School Bus. This will be added by the Inspector before the School Bus Permit can be printed and the bus can go into service..</param>
        /// <param name="Status">Enumerated type of Status - Inactive, Active, Archived.</param>
        /// <param name="IsOutOfProvince">IsOutOfProvince.</param>
        /// <param name="Location">Location.</param>
        /// <param name="BusLocationAddr1">Address 1 of physical location of the School Bus..</param>
        /// <param name="BusLocationAddr2">Address 2 of physical location of the School Bus..</param>
        /// <param name="BusLocationCity">City of physical location of the School Bus..</param>
        /// <param name="BusLocationProv">Province of physical location of the School Bus - free form..</param>
        /// <param name="BusLocationPostCode">Postal Code of physical location of the School Bus..</param>
        /// <param name="Restrictions">Text of any restrictions to be printed on the school bus permit..</param>
        /// <param name="NextInspectionDate">The next inspection date for this School Bus. Set at the time an inspection is set..</param>
        /// <param name="NextInspectionType">An enumerated type (by the UI) to indicate the type of the next inspection - Annual or Re-inspection based on the Pass/Fail status of the most recent inspection..</param>
        /// <param name="SchoolBusDistrict">The School District in which the School Bus operates. The school bus may or may not be associated with the School District itself - we just track where it is regardless..</param>
        /// <param name="IsIndependentSchool">True if the School Bus is associated with an Independent School. If true, the name of the Independent School should be in the companion field..</param>
        /// <param name="NameOfIndependentSchool">The name of the Independent School to which the School Bus is associated. Should be null if the companion isIndependentSchool is false..</param>
        /// <param name="SchoolBusClass">The enumerated class of School Bus..</param>
        /// <param name="SchoolBusUnitNumber">The unit number of the Bus as defined by the School Bus owner - freeform text..</param>
        /// <param name="SchoolBusSeatingCapacity">The maximum number of passengers in the bus based on the specific use of the bus. For example, the same 2-per seat / 24-passenger model might have a seating capacity of 36 if the specific bus is to be used for small children, 3 per seat..</param>
        /// <param name="MobilityAidCapacity">The number of mobility aid passenger seats in the bus..</param>
        public SchoolBus(int Id, string Regi = null, string Plate = null, string VIN = null, SchoolBusOwner SchoolBusOwner = null, string PermitNumber = null, string Status = null, bool? IsOutOfProvince = null, ServiceArea Location = null, string BusLocationAddr1 = null, string BusLocationAddr2 = null, City BusLocationCity = null, string BusLocationProv = null, string BusLocationPostCode = null, string Restrictions = null, DateTime? NextInspectionDate = null, string NextInspectionType = null, SchoolDistrict SchoolBusDistrict = null, bool? IsIndependentSchool = null, string NameOfIndependentSchool = null, string SchoolBusClass = null, string SchoolBusUnitNumber = null, int? SchoolBusSeatingCapacity = null, int? MobilityAidCapacity = null)
        {
            
            this.Id = Id;
            this.Regi = Regi;
            this.Plate = Plate;
            this.VIN = VIN;
            this.SchoolBusOwner = SchoolBusOwner;
            this.PermitNumber = PermitNumber;
            this.Status = Status;
            this.IsOutOfProvince = IsOutOfProvince;
            this.Location = Location;
            this.BusLocationAddr1 = BusLocationAddr1;
            this.BusLocationAddr2 = BusLocationAddr2;
            this.BusLocationCity = BusLocationCity;
            this.BusLocationProv = BusLocationProv;
            this.BusLocationPostCode = BusLocationPostCode;
            this.Restrictions = Restrictions;
            this.NextInspectionDate = NextInspectionDate;
            this.NextInspectionType = NextInspectionType;
            this.SchoolBusDistrict = SchoolBusDistrict;
            this.IsIndependentSchool = IsIndependentSchool;
            this.NameOfIndependentSchool = NameOfIndependentSchool;
            this.SchoolBusClass = SchoolBusClass;
            this.SchoolBusUnitNumber = SchoolBusUnitNumber;
            this.SchoolBusSeatingCapacity = SchoolBusSeatingCapacity;
            this.MobilityAidCapacity = MobilityAidCapacity;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// The ICBC Registration number for the School Bus
        /// </summary>
        /// <value>The ICBC Registration number for the School Bus</value>
        [MetaDataExtension (Description = "The ICBC Registration number for the School Bus")]
        public string Regi { get; set; }

        /// <summary>
        /// The ICBC Plate Number for the School Bus
        /// </summary>
        /// <value>The ICBC Plate Number for the School Bus</value>
        [MetaDataExtension (Description = "The ICBC Plate Number for the School Bus")]
        public string Plate { get; set; }

        /// <summary>
        /// The VIN for the School Bus
        /// </summary>
        /// <value>The VIN for the School Bus</value>
        [MetaDataExtension (Description = "The VIN for the School Bus")]
        public string VIN { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusOwner
        /// </summary>
        public SchoolBusOwner SchoolBusOwner { get; set; }

        /// <summary>
        /// The (generated) permit number for the School Bus. This will be added by the Inspector before the School Bus Permit can be printed and the bus can go into service.
        /// </summary>
        /// <value>The (generated) permit number for the School Bus. This will be added by the Inspector before the School Bus Permit can be printed and the bus can go into service.</value>
        [MetaDataExtension (Description = "The (generated) permit number for the School Bus. This will be added by the Inspector before the School Bus Permit can be printed and the bus can go into service.")]
        public string PermitNumber { get; set; }

        /// <summary>
        /// Enumerated type of Status - Inactive, Active, Archived
        /// </summary>
        /// <value>Enumerated type of Status - Inactive, Active, Archived</value>
        [MetaDataExtension (Description = "Enumerated type of Status - Inactive, Active, Archived")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets IsOutOfProvince
        /// </summary>
        public bool? IsOutOfProvince { get; set; }

        /// <summary>
        /// Gets or Sets Location
        /// </summary>
        public ServiceArea Location { get; set; }

        /// <summary>
        /// Address 1 of physical location of the School Bus.
        /// </summary>
        /// <value>Address 1 of physical location of the School Bus.</value>
        [MetaDataExtension (Description = "Address 1 of physical location of the School Bus.")]
        public string BusLocationAddr1 { get; set; }

        /// <summary>
        /// Address 2 of physical location of the School Bus.
        /// </summary>
        /// <value>Address 2 of physical location of the School Bus.</value>
        [MetaDataExtension (Description = "Address 2 of physical location of the School Bus.")]
        public string BusLocationAddr2 { get; set; }

        /// <summary>
        /// City of physical location of the School Bus.
        /// </summary>
        /// <value>City of physical location of the School Bus.</value>
        [MetaDataExtension (Description = "City of physical location of the School Bus.")]
        public City BusLocationCity { get; set; }

        /// <summary>
        /// Province of physical location of the School Bus - free form.
        /// </summary>
        /// <value>Province of physical location of the School Bus - free form.</value>
        [MetaDataExtension (Description = "Province of physical location of the School Bus - free form.")]
        public string BusLocationProv { get; set; }

        /// <summary>
        /// Postal Code of physical location of the School Bus.
        /// </summary>
        /// <value>Postal Code of physical location of the School Bus.</value>
        [MetaDataExtension (Description = "Postal Code of physical location of the School Bus.")]
        public string BusLocationPostCode { get; set; }

        /// <summary>
        /// Text of any restrictions to be printed on the school bus permit.
        /// </summary>
        /// <value>Text of any restrictions to be printed on the school bus permit.</value>
        [MetaDataExtension (Description = "Text of any restrictions to be printed on the school bus permit.")]
        public string Restrictions { get; set; }

        /// <summary>
        /// The next inspection date for this School Bus. Set at the time an inspection is set.
        /// </summary>
        /// <value>The next inspection date for this School Bus. Set at the time an inspection is set.</value>
        [MetaDataExtension (Description = "The next inspection date for this School Bus. Set at the time an inspection is set.")]
        public DateTime? NextInspectionDate { get; set; }

        /// <summary>
        /// An enumerated type (by the UI) to indicate the type of the next inspection - Annual or Re-inspection based on the Pass/Fail status of the most recent inspection.
        /// </summary>
        /// <value>An enumerated type (by the UI) to indicate the type of the next inspection - Annual or Re-inspection based on the Pass/Fail status of the most recent inspection.</value>
        [MetaDataExtension (Description = "An enumerated type (by the UI) to indicate the type of the next inspection - Annual or Re-inspection based on the Pass/Fail status of the most recent inspection.")]
        public string NextInspectionType { get; set; }

        /// <summary>
        /// The School District in which the School Bus operates. The school bus may or may not be associated with the School District itself - we just track where it is regardless.
        /// </summary>
        /// <value>The School District in which the School Bus operates. The school bus may or may not be associated with the School District itself - we just track where it is regardless.</value>
        [MetaDataExtension (Description = "The School District in which the School Bus operates. The school bus may or may not be associated with the School District itself - we just track where it is regardless.")]
        public SchoolDistrict SchoolBusDistrict { get; set; }

        /// <summary>
        /// True if the School Bus is associated with an Independent School. If true, the name of the Independent School should be in the companion field.
        /// </summary>
        /// <value>True if the School Bus is associated with an Independent School. If true, the name of the Independent School should be in the companion field.</value>
        [MetaDataExtension (Description = "True if the School Bus is associated with an Independent School. If true, the name of the Independent School should be in the companion field.")]
        public bool? IsIndependentSchool { get; set; }

        /// <summary>
        /// The name of the Independent School to which the School Bus is associated. Should be null if the companion isIndependentSchool is false.
        /// </summary>
        /// <value>The name of the Independent School to which the School Bus is associated. Should be null if the companion isIndependentSchool is false.</value>
        [MetaDataExtension (Description = "The name of the Independent School to which the School Bus is associated. Should be null if the companion isIndependentSchool is false.")]
        public string NameOfIndependentSchool { get; set; }

        /// <summary>
        /// The enumerated class of School Bus.
        /// </summary>
        /// <value>The enumerated class of School Bus.</value>
        [MetaDataExtension (Description = "The enumerated class of School Bus.")]
        public string SchoolBusClass { get; set; }

        /// <summary>
        /// The unit number of the Bus as defined by the School Bus owner - freeform text.
        /// </summary>
        /// <value>The unit number of the Bus as defined by the School Bus owner - freeform text.</value>
        [MetaDataExtension (Description = "The unit number of the Bus as defined by the School Bus owner - freeform text.")]
        public string SchoolBusUnitNumber { get; set; }

        /// <summary>
        /// The maximum number of passengers in the bus based on the specific use of the bus. For example, the same 2-per seat / 24-passenger model might have a seating capacity of 36 if the specific bus is to be used for small children, 3 per seat.
        /// </summary>
        /// <value>The maximum number of passengers in the bus based on the specific use of the bus. For example, the same 2-per seat / 24-passenger model might have a seating capacity of 36 if the specific bus is to be used for small children, 3 per seat.</value>
        [MetaDataExtension (Description = "The maximum number of passengers in the bus based on the specific use of the bus. For example, the same 2-per seat / 24-passenger model might have a seating capacity of 36 if the specific bus is to be used for small children, 3 per seat.")]
        public int? SchoolBusSeatingCapacity { get; set; }

        /// <summary>
        /// The number of mobility aid passenger seats in the bus.
        /// </summary>
        /// <value>The number of mobility aid passenger seats in the bus.</value>
        [MetaDataExtension (Description = "The number of mobility aid passenger seats in the bus.")]
        public int? MobilityAidCapacity { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchoolBus {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Regi: ").Append(Regi).Append("\n");
            sb.Append("  Plate: ").Append(Plate).Append("\n");
            sb.Append("  VIN: ").Append(VIN).Append("\n");
            sb.Append("  SchoolBusOwner: ").Append(SchoolBusOwner).Append("\n");
            sb.Append("  PermitNumber: ").Append(PermitNumber).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  IsOutOfProvince: ").Append(IsOutOfProvince).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  BusLocationAddr1: ").Append(BusLocationAddr1).Append("\n");
            sb.Append("  BusLocationAddr2: ").Append(BusLocationAddr2).Append("\n");
            sb.Append("  BusLocationCity: ").Append(BusLocationCity).Append("\n");
            sb.Append("  BusLocationProv: ").Append(BusLocationProv).Append("\n");
            sb.Append("  BusLocationPostCode: ").Append(BusLocationPostCode).Append("\n");
            sb.Append("  Restrictions: ").Append(Restrictions).Append("\n");
            sb.Append("  NextInspectionDate: ").Append(NextInspectionDate).Append("\n");
            sb.Append("  NextInspectionType: ").Append(NextInspectionType).Append("\n");
            sb.Append("  SchoolBusDistrict: ").Append(SchoolBusDistrict).Append("\n");
            sb.Append("  IsIndependentSchool: ").Append(IsIndependentSchool).Append("\n");
            sb.Append("  NameOfIndependentSchool: ").Append(NameOfIndependentSchool).Append("\n");
            sb.Append("  SchoolBusClass: ").Append(SchoolBusClass).Append("\n");
            sb.Append("  SchoolBusUnitNumber: ").Append(SchoolBusUnitNumber).Append("\n");
            sb.Append("  SchoolBusSeatingCapacity: ").Append(SchoolBusSeatingCapacity).Append("\n");
            sb.Append("  MobilityAidCapacity: ").Append(MobilityAidCapacity).Append("\n");
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
                    this.Regi == other.Regi ||
                    this.Regi != null &&
                    this.Regi.Equals(other.Regi)
                ) && 
                (
                    this.Plate == other.Plate ||
                    this.Plate != null &&
                    this.Plate.Equals(other.Plate)
                ) && 
                (
                    this.VIN == other.VIN ||
                    this.VIN != null &&
                    this.VIN.Equals(other.VIN)
                ) && 
                (
                    this.SchoolBusOwner == other.SchoolBusOwner ||
                    this.SchoolBusOwner != null &&
                    this.SchoolBusOwner.Equals(other.SchoolBusOwner)
                ) && 
                (
                    this.PermitNumber == other.PermitNumber ||
                    this.PermitNumber != null &&
                    this.PermitNumber.Equals(other.PermitNumber)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.IsOutOfProvince == other.IsOutOfProvince ||
                    this.IsOutOfProvince != null &&
                    this.IsOutOfProvince.Equals(other.IsOutOfProvince)
                ) && 
                (
                    this.Location == other.Location ||
                    this.Location != null &&
                    this.Location.Equals(other.Location)
                ) && 
                (
                    this.BusLocationAddr1 == other.BusLocationAddr1 ||
                    this.BusLocationAddr1 != null &&
                    this.BusLocationAddr1.Equals(other.BusLocationAddr1)
                ) && 
                (
                    this.BusLocationAddr2 == other.BusLocationAddr2 ||
                    this.BusLocationAddr2 != null &&
                    this.BusLocationAddr2.Equals(other.BusLocationAddr2)
                ) && 
                (
                    this.BusLocationCity == other.BusLocationCity ||
                    this.BusLocationCity != null &&
                    this.BusLocationCity.Equals(other.BusLocationCity)
                ) && 
                (
                    this.BusLocationProv == other.BusLocationProv ||
                    this.BusLocationProv != null &&
                    this.BusLocationProv.Equals(other.BusLocationProv)
                ) && 
                (
                    this.BusLocationPostCode == other.BusLocationPostCode ||
                    this.BusLocationPostCode != null &&
                    this.BusLocationPostCode.Equals(other.BusLocationPostCode)
                ) && 
                (
                    this.Restrictions == other.Restrictions ||
                    this.Restrictions != null &&
                    this.Restrictions.Equals(other.Restrictions)
                ) && 
                (
                    this.NextInspectionDate == other.NextInspectionDate ||
                    this.NextInspectionDate != null &&
                    this.NextInspectionDate.Equals(other.NextInspectionDate)
                ) && 
                (
                    this.NextInspectionType == other.NextInspectionType ||
                    this.NextInspectionType != null &&
                    this.NextInspectionType.Equals(other.NextInspectionType)
                ) && 
                (
                    this.SchoolBusDistrict == other.SchoolBusDistrict ||
                    this.SchoolBusDistrict != null &&
                    this.SchoolBusDistrict.Equals(other.SchoolBusDistrict)
                ) && 
                (
                    this.IsIndependentSchool == other.IsIndependentSchool ||
                    this.IsIndependentSchool != null &&
                    this.IsIndependentSchool.Equals(other.IsIndependentSchool)
                ) && 
                (
                    this.NameOfIndependentSchool == other.NameOfIndependentSchool ||
                    this.NameOfIndependentSchool != null &&
                    this.NameOfIndependentSchool.Equals(other.NameOfIndependentSchool)
                ) && 
                (
                    this.SchoolBusClass == other.SchoolBusClass ||
                    this.SchoolBusClass != null &&
                    this.SchoolBusClass.Equals(other.SchoolBusClass)
                ) && 
                (
                    this.SchoolBusUnitNumber == other.SchoolBusUnitNumber ||
                    this.SchoolBusUnitNumber != null &&
                    this.SchoolBusUnitNumber.Equals(other.SchoolBusUnitNumber)
                ) && 
                (
                    this.SchoolBusSeatingCapacity == other.SchoolBusSeatingCapacity ||
                    this.SchoolBusSeatingCapacity != null &&
                    this.SchoolBusSeatingCapacity.Equals(other.SchoolBusSeatingCapacity)
                ) && 
                (
                    this.MobilityAidCapacity == other.MobilityAidCapacity ||
                    this.MobilityAidCapacity != null &&
                    this.MobilityAidCapacity.Equals(other.MobilityAidCapacity)
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
                if (this.Regi != null)
                {
                    hash = hash * 59 + this.Regi.GetHashCode();
                }
                if (this.Plate != null)
                {
                    hash = hash * 59 + this.Plate.GetHashCode();
                }
                if (this.VIN != null)
                {
                    hash = hash * 59 + this.VIN.GetHashCode();
                }
                if (this.SchoolBusOwner != null)
                {
                    hash = hash * 59 + this.SchoolBusOwner.GetHashCode();
                }
                if (this.PermitNumber != null)
                {
                    hash = hash * 59 + this.PermitNumber.GetHashCode();
                }
                if (this.Status != null)
                {
                    hash = hash * 59 + this.Status.GetHashCode();
                }
                if (this.IsOutOfProvince != null)
                {
                    hash = hash * 59 + this.IsOutOfProvince.GetHashCode();
                }
                if (this.Location != null)
                {
                    hash = hash * 59 + this.Location.GetHashCode();
                }
                if (this.BusLocationAddr1 != null)
                {
                    hash = hash * 59 + this.BusLocationAddr1.GetHashCode();
                }
                if (this.BusLocationAddr2 != null)
                {
                    hash = hash * 59 + this.BusLocationAddr2.GetHashCode();
                }
                if (this.BusLocationCity != null)
                {
                    hash = hash * 59 + this.BusLocationCity.GetHashCode();
                }
                if (this.BusLocationProv != null)
                {
                    hash = hash * 59 + this.BusLocationProv.GetHashCode();
                }
                if (this.BusLocationPostCode != null)
                {
                    hash = hash * 59 + this.BusLocationPostCode.GetHashCode();
                }
                if (this.Restrictions != null)
                {
                    hash = hash * 59 + this.Restrictions.GetHashCode();
                }
                if (this.NextInspectionDate != null)
                {
                    hash = hash * 59 + this.NextInspectionDate.GetHashCode();
                }
                if (this.NextInspectionType != null)
                {
                    hash = hash * 59 + this.NextInspectionType.GetHashCode();
                }
                if (this.SchoolBusDistrict != null)
                {
                    hash = hash * 59 + this.SchoolBusDistrict.GetHashCode();
                }
                if (this.IsIndependentSchool != null)
                {
                    hash = hash * 59 + this.IsIndependentSchool.GetHashCode();
                }
                if (this.NameOfIndependentSchool != null)
                {
                    hash = hash * 59 + this.NameOfIndependentSchool.GetHashCode();
                }
                if (this.SchoolBusClass != null)
                {
                    hash = hash * 59 + this.SchoolBusClass.GetHashCode();
                }
                if (this.SchoolBusUnitNumber != null)
                {
                    hash = hash * 59 + this.SchoolBusUnitNumber.GetHashCode();
                }
                if (this.SchoolBusSeatingCapacity != null)
                {
                    hash = hash * 59 + this.SchoolBusSeatingCapacity.GetHashCode();
                }
                if (this.MobilityAidCapacity != null)
                {
                    hash = hash * 59 + this.MobilityAidCapacity.GetHashCode();
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
