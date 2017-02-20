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
    /// The School Bus vehicle information supplementary to the vehicle information in ICBC
    /// </summary>
        [MetaDataExtension (Description = "The School Bus vehicle information supplementary to the vehicle information in ICBC")]

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
        /// <param name="Id">A system-generated unique identifier for a SchoolBus (required).</param>
        /// <param name="Status">Status of the school bus record - current values are Inactive, Active, Archived (required).</param>
        /// <param name="PermitClassCode">The enumerated class of School Bus from drop down (required).</param>
        /// <param name="BodyTypeCode">The enumerated body type of the School Bus from drop down (required).</param>
        /// <param name="SchoolBusSeatingCapacity">The maximum number of passengers in the bus based on the specific use of the bus including the driver. For example,  the same 2-per seat &amp;#x2F; 24-passenger model might have a seating capacity of 36 if the specific bus is to be used for small children,  3 per seat. (required).</param>
        /// <param name="ICBCRegistrationNumber">The registration number of the vehicle as entered by the user and confirmed by the CCW Web Services.</param>
        /// <param name="LicencePlateNumber">The License Plate Number for the vehicle.</param>
        /// <param name="VehicleIdentificationNumber">A code used by the automotive industry to uniquely identify individual motor vehicles. A vehicle identification number is frequently referred to using the acronym VIN and it is occasionally referred to as a chassis number..</param>
        /// <param name="SchoolBusOwner">SchoolBusOwner.</param>
        /// <param name="PermitNumber">The (generated) permit number for the School Bus. The number is set by the system when the inspector generates a permit based on a business rule permit number format..</param>
        /// <param name="PermitIssueDate">The date a permit number was established for this School Bus..</param>
        /// <param name="IsOutOfProvince">True if the School Bus is registered outside of BC..</param>
        /// <param name="CCWJurisdiction">The Jurisdication of an Out Of Province Bus. Needed for querying CCW..</param>
        /// <param name="District">District.</param>
        /// <param name="HomeTerminalAddress1">Address Line 1 of physical location of the School Bus..</param>
        /// <param name="HomeTerminalAddress2">Address Line 2 of physical location of the School Bus..</param>
        /// <param name="HomeTerminalCity">City of physical location of the School Bus..</param>
        /// <param name="HomeTerminalProvince">Province of physical location of the School Bus - free form..</param>
        /// <param name="HomeTerminalPostalCode">Postal Code of physical location of the School Bus..</param>
        /// <param name="HomeTerminalComment">A comment about the physical location of the bus so that the Inspector can more easily find it for an inspection..</param>
        /// <param name="RestrictionsText">Text of any restrictions to be printed on the school bus permit. Standard comments are associated with the Permit Class but the inspector can enter free form text..</param>
        /// <param name="NextInspectionDate">The next inspection date for this School Bus which is set when inspection results are saved.</param>
        /// <param name="NextInspectionTypeCode">Annual or Re-inspection based on the Pass&amp;#x2F;Fail status of the most recent inspection - An enumerated type (by the UI) to indicate the type of the next inspection.</param>
        /// <param name="SchoolDistrict">The School District in which the School Bus operates. The school bus may or may not be associated with the School District itself - we just track where it is regardless..</param>
        /// <param name="IsIndependentSchool">True if the School Bus is associated with an Independent School. If true,  the name of the Independent School should be in the companion field..</param>
        /// <param name="IndependentSchoolName">The name of the Independent School to which the School Bus is associated. Should be null if the companion isIndependentSchool is false..</param>
        /// <param name="UnitNumber">The unit number of the Bus as defined by the School Bus owner - freeform text..</param>
        /// <param name="MobilityAidCapacity">The number of mobility aid passenger seats in the bus..</param>
        /// <param name="Inspector">The inspector assigned to this schoolbus.</param>
        /// <param name="Notes">The set of notes about the school bus entered by users..</param>
        /// <param name="Attachments">The set of attachments about the school bus uploaded by the users..</param>
        /// <param name="History">The history of updates made to the School Bus..</param>
        /// <param name="CCWData">CCWData for this School Bus.</param>
        public SchoolBus(int Id, string Status, string PermitClassCode, string BodyTypeCode, int SchoolBusSeatingCapacity, string ICBCRegistrationNumber = null, string LicencePlateNumber = null, string VehicleIdentificationNumber = null, SchoolBusOwner SchoolBusOwner = null, int? PermitNumber = null, DateTime? PermitIssueDate = null, bool? IsOutOfProvince = null, CCWJurisdiction CCWJurisdiction = null, District District = null, string HomeTerminalAddress1 = null, string HomeTerminalAddress2 = null, City HomeTerminalCity = null, string HomeTerminalProvince = null, string HomeTerminalPostalCode = null, string HomeTerminalComment = null, string RestrictionsText = null, DateTime? NextInspectionDate = null, string NextInspectionTypeCode = null, SchoolDistrict SchoolDistrict = null, bool? IsIndependentSchool = null, string IndependentSchoolName = null, string UnitNumber = null, int? MobilityAidCapacity = null, User Inspector = null, List<Note> Notes = null, List<Attachment> Attachments = null, List<History> History = null, CCWData CCWData = null)
        {   
            this.Id = Id;
            this.Status = Status;
            this.PermitClassCode = PermitClassCode;
            this.BodyTypeCode = BodyTypeCode;
            this.SchoolBusSeatingCapacity = SchoolBusSeatingCapacity;




            this.ICBCRegistrationNumber = ICBCRegistrationNumber;
            this.LicencePlateNumber = LicencePlateNumber;
            this.VehicleIdentificationNumber = VehicleIdentificationNumber;
            this.SchoolBusOwner = SchoolBusOwner;
            this.PermitNumber = PermitNumber;
            this.PermitIssueDate = PermitIssueDate;
            this.IsOutOfProvince = IsOutOfProvince;
            this.CCWJurisdiction = CCWJurisdiction;
            this.District = District;
            this.HomeTerminalAddress1 = HomeTerminalAddress1;
            this.HomeTerminalAddress2 = HomeTerminalAddress2;
            this.HomeTerminalCity = HomeTerminalCity;
            this.HomeTerminalProvince = HomeTerminalProvince;
            this.HomeTerminalPostalCode = HomeTerminalPostalCode;
            this.HomeTerminalComment = HomeTerminalComment;
            this.RestrictionsText = RestrictionsText;
            this.NextInspectionDate = NextInspectionDate;
            this.NextInspectionTypeCode = NextInspectionTypeCode;
            this.SchoolDistrict = SchoolDistrict;
            this.IsIndependentSchool = IsIndependentSchool;
            this.IndependentSchoolName = IndependentSchoolName;
            this.UnitNumber = UnitNumber;
            this.MobilityAidCapacity = MobilityAidCapacity;
            this.Inspector = Inspector;
            this.Notes = Notes;
            this.Attachments = Attachments;
            this.History = History;
            this.CCWData = CCWData;
        }

        /// <summary>
        /// A system-generated unique identifier for a SchoolBus
        /// </summary>
        /// <value>A system-generated unique identifier for a SchoolBus</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for a SchoolBus")]
        public int Id { get; set; }
        
        /// <summary>
        /// Status of the school bus record - current values are Inactive, Active, Archived
        /// </summary>
        /// <value>Status of the school bus record - current values are Inactive, Active, Archived</value>
        [MetaDataExtension (Description = "Status of the school bus record - current values are Inactive, Active, Archived")]
        [MaxLength(20)]
        
        public string Status { get; set; }
        
        /// <summary>
        /// The enumerated class of School Bus from drop down
        /// </summary>
        /// <value>The enumerated class of School Bus from drop down</value>
        [MetaDataExtension (Description = "The enumerated class of School Bus from drop down")]
        [MaxLength(50)]
        
        public string PermitClassCode { get; set; }
        
        /// <summary>
        /// The enumerated body type of the School Bus from drop down
        /// </summary>
        /// <value>The enumerated body type of the School Bus from drop down</value>
        [MetaDataExtension (Description = "The enumerated body type of the School Bus from drop down")]
        [MaxLength(50)]
        
        public string BodyTypeCode { get; set; }
        
        /// <summary>
        /// The maximum number of passengers in the bus based on the specific use of the bus including the driver. For example,  the same 2-per seat &#x2F; 24-passenger model might have a seating capacity of 36 if the specific bus is to be used for small children,  3 per seat.
        /// </summary>
        /// <value>The maximum number of passengers in the bus based on the specific use of the bus including the driver. For example,  the same 2-per seat &#x2F; 24-passenger model might have a seating capacity of 36 if the specific bus is to be used for small children,  3 per seat.</value>
        [MetaDataExtension (Description = "The maximum number of passengers in the bus based on the specific use of the bus including the driver. For example,  the same 2-per seat &#x2F; 24-passenger model might have a seating capacity of 36 if the specific bus is to be used for small children,  3 per seat.")]
        public int SchoolBusSeatingCapacity { get; set; }
        
        /// <summary>
        /// The registration number of the vehicle as entered by the user and confirmed by the CCW Web Services
        /// </summary>
        /// <value>The registration number of the vehicle as entered by the user and confirmed by the CCW Web Services</value>
        [MetaDataExtension (Description = "The registration number of the vehicle as entered by the user and confirmed by the CCW Web Services")]
        [MaxLength(40)]
        
        public string ICBCRegistrationNumber { get; set; }
        
        /// <summary>
        /// The License Plate Number for the vehicle
        /// </summary>
        /// <value>The License Plate Number for the vehicle</value>
        [MetaDataExtension (Description = "The License Plate Number for the vehicle")]
        [MaxLength(15)]
        
        public string LicencePlateNumber { get; set; }
        
        /// <summary>
        /// A code used by the automotive industry to uniquely identify individual motor vehicles. A vehicle identification number is frequently referred to using the acronym VIN and it is occasionally referred to as a chassis number.
        /// </summary>
        /// <value>A code used by the automotive industry to uniquely identify individual motor vehicles. A vehicle identification number is frequently referred to using the acronym VIN and it is occasionally referred to as a chassis number.</value>
        [MetaDataExtension (Description = "A code used by the automotive industry to uniquely identify individual motor vehicles. A vehicle identification number is frequently referred to using the acronym VIN and it is occasionally referred to as a chassis number.")]
        [MaxLength(17)]
        
        public string VehicleIdentificationNumber { get; set; }
        
        /// <summary>
        /// Gets or Sets SchoolBusOwner
        /// </summary>
        public SchoolBusOwner SchoolBusOwner { get; set; }
        
        /// <summary>
        /// Foreign key for SchoolBusOwner 
        /// </summary>       
        [ForeignKey("SchoolBusOwner")]
        public int? SchoolBusOwnerRefId { get; set; }
        
        /// <summary>
        /// The (generated) permit number for the School Bus. The number is set by the system when the inspector generates a permit based on a business rule permit number format.
        /// </summary>
        /// <value>The (generated) permit number for the School Bus. The number is set by the system when the inspector generates a permit based on a business rule permit number format.</value>
        [MetaDataExtension (Description = "The (generated) permit number for the School Bus. The number is set by the system when the inspector generates a permit based on a business rule permit number format.")]
        public int? PermitNumber { get; set; }
        
        /// <summary>
        /// The date a permit number was established for this School Bus.
        /// </summary>
        /// <value>The date a permit number was established for this School Bus.</value>
        [MetaDataExtension (Description = "The date a permit number was established for this School Bus.")]
        public DateTime? PermitIssueDate { get; set; }
        
        /// <summary>
        /// True if the School Bus is registered outside of BC.
        /// </summary>
        /// <value>True if the School Bus is registered outside of BC.</value>
        [MetaDataExtension (Description = "True if the School Bus is registered outside of BC.")]
        public bool? IsOutOfProvince { get; set; }
        
        /// <summary>
        /// The Jurisdication of an Out Of Province Bus. Needed for querying CCW.
        /// </summary>
        /// <value>The Jurisdication of an Out Of Province Bus. Needed for querying CCW.</value>
        [MetaDataExtension (Description = "The Jurisdication of an Out Of Province Bus. Needed for querying CCW.")]
        public CCWJurisdiction CCWJurisdiction { get; set; }
        
        /// <summary>
        /// Foreign key for CCWJurisdiction 
        /// </summary>       
        [ForeignKey("CCWJurisdiction")]
        public int? CCWJurisdictionRefId { get; set; }
        
        /// <summary>
        /// Gets or Sets District
        /// </summary>
        public District District { get; set; }
        
        /// <summary>
        /// Foreign key for District 
        /// </summary>       
        [ForeignKey("District")]
        public int? DistrictRefId { get; set; }
        
        /// <summary>
        /// Address Line 1 of physical location of the School Bus.
        /// </summary>
        /// <value>Address Line 1 of physical location of the School Bus.</value>
        [MetaDataExtension (Description = "Address Line 1 of physical location of the School Bus.")]
        [MaxLength(80)]
        
        public string HomeTerminalAddress1 { get; set; }
        
        /// <summary>
        /// Address Line 2 of physical location of the School Bus.
        /// </summary>
        /// <value>Address Line 2 of physical location of the School Bus.</value>
        [MetaDataExtension (Description = "Address Line 2 of physical location of the School Bus.")]
        [MaxLength(80)]
        
        public string HomeTerminalAddress2 { get; set; }
        
        /// <summary>
        /// City of physical location of the School Bus.
        /// </summary>
        /// <value>City of physical location of the School Bus.</value>
        [MetaDataExtension (Description = "City of physical location of the School Bus.")]
        public City HomeTerminalCity { get; set; }
        
        /// <summary>
        /// Foreign key for HomeTerminalCity 
        /// </summary>       
        [ForeignKey("HomeTerminalCity")]
        public int? HomeTerminalCityRefId { get; set; }
        
        /// <summary>
        /// Province of physical location of the School Bus - free form.
        /// </summary>
        /// <value>Province of physical location of the School Bus - free form.</value>
        [MetaDataExtension (Description = "Province of physical location of the School Bus - free form.")]
        [MaxLength(40)]
        
        public string HomeTerminalProvince { get; set; }
        
        /// <summary>
        /// Postal Code of physical location of the School Bus.
        /// </summary>
        /// <value>Postal Code of physical location of the School Bus.</value>
        [MetaDataExtension (Description = "Postal Code of physical location of the School Bus.")]
        [MaxLength(15)]
        
        public string HomeTerminalPostalCode { get; set; }
        
        /// <summary>
        /// A comment about the physical location of the bus so that the Inspector can more easily find it for an inspection.
        /// </summary>
        /// <value>A comment about the physical location of the bus so that the Inspector can more easily find it for an inspection.</value>
        [MetaDataExtension (Description = "A comment about the physical location of the bus so that the Inspector can more easily find it for an inspection.")]
        [MaxLength(2048)]
        
        public string HomeTerminalComment { get; set; }
        
        /// <summary>
        /// Text of any restrictions to be printed on the school bus permit. Standard comments are associated with the Permit Class but the inspector can enter free form text.
        /// </summary>
        /// <value>Text of any restrictions to be printed on the school bus permit. Standard comments are associated with the Permit Class but the inspector can enter free form text.</value>
        [MetaDataExtension (Description = "Text of any restrictions to be printed on the school bus permit. Standard comments are associated with the Permit Class but the inspector can enter free form text.")]
        [MaxLength(2048)]
        
        public string RestrictionsText { get; set; }
        
        /// <summary>
        /// The next inspection date for this School Bus which is set when inspection results are saved
        /// </summary>
        /// <value>The next inspection date for this School Bus which is set when inspection results are saved</value>
        [MetaDataExtension (Description = "The next inspection date for this School Bus which is set when inspection results are saved")]
        public DateTime? NextInspectionDate { get; set; }
        
        /// <summary>
        /// Annual or Re-inspection based on the Pass&#x2F;Fail status of the most recent inspection - An enumerated type (by the UI) to indicate the type of the next inspection
        /// </summary>
        /// <value>Annual or Re-inspection based on the Pass&#x2F;Fail status of the most recent inspection - An enumerated type (by the UI) to indicate the type of the next inspection</value>
        [MetaDataExtension (Description = "Annual or Re-inspection based on the Pass&#x2F;Fail status of the most recent inspection - An enumerated type (by the UI) to indicate the type of the next inspection")]
        [MaxLength(30)]
        
        public string NextInspectionTypeCode { get; set; }
        
        /// <summary>
        /// The School District in which the School Bus operates. The school bus may or may not be associated with the School District itself - we just track where it is regardless.
        /// </summary>
        /// <value>The School District in which the School Bus operates. The school bus may or may not be associated with the School District itself - we just track where it is regardless.</value>
        [MetaDataExtension (Description = "The School District in which the School Bus operates. The school bus may or may not be associated with the School District itself - we just track where it is regardless.")]
        public SchoolDistrict SchoolDistrict { get; set; }
        
        /// <summary>
        /// Foreign key for SchoolDistrict 
        /// </summary>       
        [ForeignKey("SchoolDistrict")]
        public int? SchoolDistrictRefId { get; set; }
        
        /// <summary>
        /// True if the School Bus is associated with an Independent School. If true,  the name of the Independent School should be in the companion field.
        /// </summary>
        /// <value>True if the School Bus is associated with an Independent School. If true,  the name of the Independent School should be in the companion field.</value>
        [MetaDataExtension (Description = "True if the School Bus is associated with an Independent School. If true,  the name of the Independent School should be in the companion field.")]
        public bool? IsIndependentSchool { get; set; }
        
        /// <summary>
        /// The name of the Independent School to which the School Bus is associated. Should be null if the companion isIndependentSchool is false.
        /// </summary>
        /// <value>The name of the Independent School to which the School Bus is associated. Should be null if the companion isIndependentSchool is false.</value>
        [MetaDataExtension (Description = "The name of the Independent School to which the School Bus is associated. Should be null if the companion isIndependentSchool is false.")]
        [MaxLength(120)]
        
        public string IndependentSchoolName { get; set; }
        
        /// <summary>
        /// The unit number of the Bus as defined by the School Bus owner - freeform text.
        /// </summary>
        /// <value>The unit number of the Bus as defined by the School Bus owner - freeform text.</value>
        [MetaDataExtension (Description = "The unit number of the Bus as defined by the School Bus owner - freeform text.")]
        [MaxLength(30)]
        
        public string UnitNumber { get; set; }
        
        /// <summary>
        /// The number of mobility aid passenger seats in the bus.
        /// </summary>
        /// <value>The number of mobility aid passenger seats in the bus.</value>
        [MetaDataExtension (Description = "The number of mobility aid passenger seats in the bus.")]
        public int? MobilityAidCapacity { get; set; }
        
        /// <summary>
        /// The inspector assigned to this schoolbus
        /// </summary>
        /// <value>The inspector assigned to this schoolbus</value>
        [MetaDataExtension (Description = "The inspector assigned to this schoolbus")]
        public User Inspector { get; set; }
        
        /// <summary>
        /// Foreign key for Inspector 
        /// </summary>       
        [ForeignKey("Inspector")]
        public int? InspectorRefId { get; set; }
        
        /// <summary>
        /// The set of notes about the school bus entered by users.
        /// </summary>
        /// <value>The set of notes about the school bus entered by users.</value>
        [MetaDataExtension (Description = "The set of notes about the school bus entered by users.")]
        public List<Note> Notes { get; set; }
        
        /// <summary>
        /// The set of attachments about the school bus uploaded by the users.
        /// </summary>
        /// <value>The set of attachments about the school bus uploaded by the users.</value>
        [MetaDataExtension (Description = "The set of attachments about the school bus uploaded by the users.")]
        public List<Attachment> Attachments { get; set; }
        
        /// <summary>
        /// The history of updates made to the School Bus.
        /// </summary>
        /// <value>The history of updates made to the School Bus.</value>
        [MetaDataExtension (Description = "The history of updates made to the School Bus.")]
        public List<History> History { get; set; }
        
        /// <summary>
        /// CCWData for this School Bus
        /// </summary>
        /// <value>CCWData for this School Bus</value>
        [MetaDataExtension (Description = "CCWData for this School Bus")]
        public CCWData CCWData { get; set; }
        
        /// <summary>
        /// Foreign key for CCWData 
        /// </summary>       
        [ForeignKey("CCWData")]
        public int? CCWDataRefId { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchoolBus {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  PermitClassCode: ").Append(PermitClassCode).Append("\n");
            sb.Append("  BodyTypeCode: ").Append(BodyTypeCode).Append("\n");
            sb.Append("  SchoolBusSeatingCapacity: ").Append(SchoolBusSeatingCapacity).Append("\n");
            sb.Append("  ICBCRegistrationNumber: ").Append(ICBCRegistrationNumber).Append("\n");
            sb.Append("  LicencePlateNumber: ").Append(LicencePlateNumber).Append("\n");
            sb.Append("  VehicleIdentificationNumber: ").Append(VehicleIdentificationNumber).Append("\n");
            sb.Append("  SchoolBusOwner: ").Append(SchoolBusOwner).Append("\n");
            sb.Append("  PermitNumber: ").Append(PermitNumber).Append("\n");
            sb.Append("  PermitIssueDate: ").Append(PermitIssueDate).Append("\n");
            sb.Append("  IsOutOfProvince: ").Append(IsOutOfProvince).Append("\n");
            sb.Append("  CCWJurisdiction: ").Append(CCWJurisdiction).Append("\n");
            sb.Append("  District: ").Append(District).Append("\n");
            sb.Append("  HomeTerminalAddress1: ").Append(HomeTerminalAddress1).Append("\n");
            sb.Append("  HomeTerminalAddress2: ").Append(HomeTerminalAddress2).Append("\n");
            sb.Append("  HomeTerminalCity: ").Append(HomeTerminalCity).Append("\n");
            sb.Append("  HomeTerminalProvince: ").Append(HomeTerminalProvince).Append("\n");
            sb.Append("  HomeTerminalPostalCode: ").Append(HomeTerminalPostalCode).Append("\n");
            sb.Append("  HomeTerminalComment: ").Append(HomeTerminalComment).Append("\n");
            sb.Append("  RestrictionsText: ").Append(RestrictionsText).Append("\n");
            sb.Append("  NextInspectionDate: ").Append(NextInspectionDate).Append("\n");
            sb.Append("  NextInspectionTypeCode: ").Append(NextInspectionTypeCode).Append("\n");
            sb.Append("  SchoolDistrict: ").Append(SchoolDistrict).Append("\n");
            sb.Append("  IsIndependentSchool: ").Append(IsIndependentSchool).Append("\n");
            sb.Append("  IndependentSchoolName: ").Append(IndependentSchoolName).Append("\n");
            sb.Append("  UnitNumber: ").Append(UnitNumber).Append("\n");
            sb.Append("  MobilityAidCapacity: ").Append(MobilityAidCapacity).Append("\n");
            sb.Append("  Inspector: ").Append(Inspector).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  Attachments: ").Append(Attachments).Append("\n");
            sb.Append("  History: ").Append(History).Append("\n");
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
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) &&                 
                (
                    this.PermitClassCode == other.PermitClassCode ||
                    this.PermitClassCode != null &&
                    this.PermitClassCode.Equals(other.PermitClassCode)
                ) &&                 
                (
                    this.BodyTypeCode == other.BodyTypeCode ||
                    this.BodyTypeCode != null &&
                    this.BodyTypeCode.Equals(other.BodyTypeCode)
                ) &&                 
                (
                    this.SchoolBusSeatingCapacity == other.SchoolBusSeatingCapacity ||
                    this.SchoolBusSeatingCapacity.Equals(other.SchoolBusSeatingCapacity)
                ) &&                 
                (
                    this.ICBCRegistrationNumber == other.ICBCRegistrationNumber ||
                    this.ICBCRegistrationNumber != null &&
                    this.ICBCRegistrationNumber.Equals(other.ICBCRegistrationNumber)
                ) &&                 
                (
                    this.LicencePlateNumber == other.LicencePlateNumber ||
                    this.LicencePlateNumber != null &&
                    this.LicencePlateNumber.Equals(other.LicencePlateNumber)
                ) &&                 
                (
                    this.VehicleIdentificationNumber == other.VehicleIdentificationNumber ||
                    this.VehicleIdentificationNumber != null &&
                    this.VehicleIdentificationNumber.Equals(other.VehicleIdentificationNumber)
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
                    this.PermitIssueDate == other.PermitIssueDate ||
                    this.PermitIssueDate != null &&
                    this.PermitIssueDate.Equals(other.PermitIssueDate)
                ) &&                 
                (
                    this.IsOutOfProvince == other.IsOutOfProvince ||
                    this.IsOutOfProvince != null &&
                    this.IsOutOfProvince.Equals(other.IsOutOfProvince)
                ) &&                 
                (
                    this.CCWJurisdiction == other.CCWJurisdiction ||
                    this.CCWJurisdiction != null &&
                    this.CCWJurisdiction.Equals(other.CCWJurisdiction)
                ) &&                 
                (
                    this.District == other.District ||
                    this.District != null &&
                    this.District.Equals(other.District)
                ) &&                 
                (
                    this.HomeTerminalAddress1 == other.HomeTerminalAddress1 ||
                    this.HomeTerminalAddress1 != null &&
                    this.HomeTerminalAddress1.Equals(other.HomeTerminalAddress1)
                ) &&                 
                (
                    this.HomeTerminalAddress2 == other.HomeTerminalAddress2 ||
                    this.HomeTerminalAddress2 != null &&
                    this.HomeTerminalAddress2.Equals(other.HomeTerminalAddress2)
                ) &&                 
                (
                    this.HomeTerminalCity == other.HomeTerminalCity ||
                    this.HomeTerminalCity != null &&
                    this.HomeTerminalCity.Equals(other.HomeTerminalCity)
                ) &&                 
                (
                    this.HomeTerminalProvince == other.HomeTerminalProvince ||
                    this.HomeTerminalProvince != null &&
                    this.HomeTerminalProvince.Equals(other.HomeTerminalProvince)
                ) &&                 
                (
                    this.HomeTerminalPostalCode == other.HomeTerminalPostalCode ||
                    this.HomeTerminalPostalCode != null &&
                    this.HomeTerminalPostalCode.Equals(other.HomeTerminalPostalCode)
                ) &&                 
                (
                    this.HomeTerminalComment == other.HomeTerminalComment ||
                    this.HomeTerminalComment != null &&
                    this.HomeTerminalComment.Equals(other.HomeTerminalComment)
                ) &&                 
                (
                    this.RestrictionsText == other.RestrictionsText ||
                    this.RestrictionsText != null &&
                    this.RestrictionsText.Equals(other.RestrictionsText)
                ) &&                 
                (
                    this.NextInspectionDate == other.NextInspectionDate ||
                    this.NextInspectionDate != null &&
                    this.NextInspectionDate.Equals(other.NextInspectionDate)
                ) &&                 
                (
                    this.NextInspectionTypeCode == other.NextInspectionTypeCode ||
                    this.NextInspectionTypeCode != null &&
                    this.NextInspectionTypeCode.Equals(other.NextInspectionTypeCode)
                ) &&                 
                (
                    this.SchoolDistrict == other.SchoolDistrict ||
                    this.SchoolDistrict != null &&
                    this.SchoolDistrict.Equals(other.SchoolDistrict)
                ) &&                 
                (
                    this.IsIndependentSchool == other.IsIndependentSchool ||
                    this.IsIndependentSchool != null &&
                    this.IsIndependentSchool.Equals(other.IsIndependentSchool)
                ) &&                 
                (
                    this.IndependentSchoolName == other.IndependentSchoolName ||
                    this.IndependentSchoolName != null &&
                    this.IndependentSchoolName.Equals(other.IndependentSchoolName)
                ) &&                 
                (
                    this.UnitNumber == other.UnitNumber ||
                    this.UnitNumber != null &&
                    this.UnitNumber.Equals(other.UnitNumber)
                ) &&                 
                (
                    this.MobilityAidCapacity == other.MobilityAidCapacity ||
                    this.MobilityAidCapacity != null &&
                    this.MobilityAidCapacity.Equals(other.MobilityAidCapacity)
                ) &&                 
                (
                    this.Inspector == other.Inspector ||
                    this.Inspector != null &&
                    this.Inspector.Equals(other.Inspector)
                ) && 
                (
                    this.Notes == other.Notes ||
                    this.Notes != null &&
                    this.Notes.SequenceEqual(other.Notes)
                ) && 
                (
                    this.Attachments == other.Attachments ||
                    this.Attachments != null &&
                    this.Attachments.SequenceEqual(other.Attachments)
                ) && 
                (
                    this.History == other.History ||
                    this.History != null &&
                    this.History.SequenceEqual(other.History)
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
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.Status != null)
                {
                    hash = hash * 59 + this.Status.GetHashCode();
                }                
                                if (this.PermitClassCode != null)
                {
                    hash = hash * 59 + this.PermitClassCode.GetHashCode();
                }                
                                if (this.BodyTypeCode != null)
                {
                    hash = hash * 59 + this.BodyTypeCode.GetHashCode();
                }                
                                                   
                hash = hash * 59 + this.SchoolBusSeatingCapacity.GetHashCode();                if (this.ICBCRegistrationNumber != null)
                {
                    hash = hash * 59 + this.ICBCRegistrationNumber.GetHashCode();
                }                
                                if (this.LicencePlateNumber != null)
                {
                    hash = hash * 59 + this.LicencePlateNumber.GetHashCode();
                }                
                                if (this.VehicleIdentificationNumber != null)
                {
                    hash = hash * 59 + this.VehicleIdentificationNumber.GetHashCode();
                }                
                                   
                if (this.SchoolBusOwner != null)
                {
                    hash = hash * 59 + this.SchoolBusOwner.GetHashCode();
                }                if (this.PermitNumber != null)
                {
                    hash = hash * 59 + this.PermitNumber.GetHashCode();
                }                
                                if (this.PermitIssueDate != null)
                {
                    hash = hash * 59 + this.PermitIssueDate.GetHashCode();
                }                
                                if (this.IsOutOfProvince != null)
                {
                    hash = hash * 59 + this.IsOutOfProvince.GetHashCode();
                }                
                                   
                if (this.CCWJurisdiction != null)
                {
                    hash = hash * 59 + this.CCWJurisdiction.GetHashCode();
                }                   
                if (this.District != null)
                {
                    hash = hash * 59 + this.District.GetHashCode();
                }                if (this.HomeTerminalAddress1 != null)
                {
                    hash = hash * 59 + this.HomeTerminalAddress1.GetHashCode();
                }                
                                if (this.HomeTerminalAddress2 != null)
                {
                    hash = hash * 59 + this.HomeTerminalAddress2.GetHashCode();
                }                
                                   
                if (this.HomeTerminalCity != null)
                {
                    hash = hash * 59 + this.HomeTerminalCity.GetHashCode();
                }                if (this.HomeTerminalProvince != null)
                {
                    hash = hash * 59 + this.HomeTerminalProvince.GetHashCode();
                }                
                                if (this.HomeTerminalPostalCode != null)
                {
                    hash = hash * 59 + this.HomeTerminalPostalCode.GetHashCode();
                }                
                                if (this.HomeTerminalComment != null)
                {
                    hash = hash * 59 + this.HomeTerminalComment.GetHashCode();
                }                
                                if (this.RestrictionsText != null)
                {
                    hash = hash * 59 + this.RestrictionsText.GetHashCode();
                }                
                                if (this.NextInspectionDate != null)
                {
                    hash = hash * 59 + this.NextInspectionDate.GetHashCode();
                }                
                                if (this.NextInspectionTypeCode != null)
                {
                    hash = hash * 59 + this.NextInspectionTypeCode.GetHashCode();
                }                
                                   
                if (this.SchoolDistrict != null)
                {
                    hash = hash * 59 + this.SchoolDistrict.GetHashCode();
                }                if (this.IsIndependentSchool != null)
                {
                    hash = hash * 59 + this.IsIndependentSchool.GetHashCode();
                }                
                                if (this.IndependentSchoolName != null)
                {
                    hash = hash * 59 + this.IndependentSchoolName.GetHashCode();
                }                
                                if (this.UnitNumber != null)
                {
                    hash = hash * 59 + this.UnitNumber.GetHashCode();
                }                
                                if (this.MobilityAidCapacity != null)
                {
                    hash = hash * 59 + this.MobilityAidCapacity.GetHashCode();
                }                
                                   
                if (this.Inspector != null)
                {
                    hash = hash * 59 + this.Inspector.GetHashCode();
                }                   
                if (this.Notes != null)
                {
                    hash = hash * 59 + this.Notes.GetHashCode();
                }                   
                if (this.Attachments != null)
                {
                    hash = hash * 59 + this.Attachments.GetHashCode();
                }                   
                if (this.History != null)
                {
                    hash = hash * 59 + this.History.GetHashCode();
                }                   
                if (this.CCWData != null)
                {
                    hash = hash * 59 + this.CCWData.GetHashCode();
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
        public static bool operator ==(SchoolBus left, SchoolBus right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(SchoolBus left, SchoolBus right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
