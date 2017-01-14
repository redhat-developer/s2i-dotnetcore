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
    /// Data pulled in from external sources (ICBC, NSC, etc) about School Buses and retained but not updated in the School Bus app. All data elements are simply copied from the comparable fields in the WSDLs of the Web Service Calls.
    /// </summary>
        [MetaDataExtension (Description = "Data pulled in from external sources (ICBC, NSC, etc) about School Buses and retained but not updated in the School Bus app. All data elements are simply copied from the comparable fields in the WSDLs of the Web Service Calls.")]


    public partial class CCWData : IEquatable<CCWData>
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
        /// <param name="ICBCRegi">The Registration Number (Regi) is the link between the CCW information and a specific School Bus.</param>
        /// <param name="ICBCModelYear">Vehicle Year.</param>
        /// <param name="ICBCVehicleType">ICBCVehicleType.</param>
        /// <param name="ICBCRateClass">ICBCRateClass.</param>
        /// <param name="ICBCCVIPDecal">ICBCCVIPDecal.</param>
        /// <param name="ICBCFleetUnitNo">ICBCFleetUnitNo.</param>
        /// <param name="ICBCGrossVehicleWeight">ICBCGrossVehicleWeight.</param>
        /// <param name="ICBCMake">ICBCMake.</param>
        /// <param name="ICBCBody">ICBCBody.</param>
        /// <param name="ICBCRebuiltStatus">ICBCRebuiltStatus.</param>
        /// <param name="ICBCCVIPExpiry">ICBCCVIPExpiry.</param>
        /// <param name="ICBCNetWt">ICBCNetWt.</param>
        /// <param name="ICBCModel">ICBCModel.</param>
        /// <param name="ICBCFuel">ICBCFuel.</param>
        /// <param name="ICBCSeatingCapacity">ICBCSeatingCapacity.</param>
        /// <param name="ICBCColour">ICBCColour.</param>
        /// <param name="ICBCNotesAndOrders">ICBCNotesAndOrders.</param>
        /// <param name="ICBCOrderedOn">ICBCOrderedOn.</param>
        /// <param name="ICBCRegOwnerName">ICBCRegOwnerName.</param>
        /// <param name="ICBCRegOwnerAddr1">ICBCRegOwnerAddr1.</param>
        /// <param name="ICBCRegOwnerAddr2">ICBCRegOwnerAddr2.</param>
        /// <param name="ICBCRegOwnerCity">ICBCRegOwnerCity.</param>
        /// <param name="ICBCRegOwnerProv">ICBCRegOwnerProv.</param>
        /// <param name="ICBCRegOwnerPostalCode">ICBCRegOwnerPostalCode.</param>
        /// <param name="ICBCRegOwnerStatus">ICBCRegOwnerStatus.</param>
        /// <param name="ICBCRegOwnerRODL">ICBCRegOwnerRODL.</param>
        /// <param name="ICBCRegOwnerPool">ICBCRegOwnerPool.</param>
        /// <param name="NSCClientNum">NSCClientNum.</param>
        /// <param name="NSCCarrierName">NSCCarrierName.</param>
        /// <param name="NSCCarrierConditions">NSCCarrierConditions.</param>
        /// <param name="NSCCarrierSafetyRating">NSCCarrierSafetyRating.</param>
        /// <param name="NSCPolicyNumber">NSCPolicyNumber.</param>
        /// <param name="NSCPolicyEffectiveDate">NSCPolicyEffectiveDate.</param>
        /// <param name="NSCPolicyStatusDate">NSCPolicyStatusDate.</param>
        /// <param name="NSCPolicyExpiryDate">NSCPolicyExpiryDate.</param>
        /// <param name="NSCPolicyStatus">NSCPolicyStatus.</param>
        /// <param name="NSCPlateDecal">NSCPlateDecal.</param>
        public CCWData(int Id, string ICBCRegi = null, int? ICBCModelYear = null, string ICBCVehicleType = null, string ICBCRateClass = null, string ICBCCVIPDecal = null, int? ICBCFleetUnitNo = null, int? ICBCGrossVehicleWeight = null, string ICBCMake = null, string ICBCBody = null, string ICBCRebuiltStatus = null, DateTime? ICBCCVIPExpiry = null, int? ICBCNetWt = null, string ICBCModel = null, string ICBCFuel = null, int? ICBCSeatingCapacity = null, string ICBCColour = null, string ICBCNotesAndOrders = null, DateTime? ICBCOrderedOn = null, string ICBCRegOwnerName = null, string ICBCRegOwnerAddr1 = null, string ICBCRegOwnerAddr2 = null, string ICBCRegOwnerCity = null, string ICBCRegOwnerProv = null, string ICBCRegOwnerPostalCode = null, string ICBCRegOwnerStatus = null, string ICBCRegOwnerRODL = null, string ICBCRegOwnerPool = null, string NSCClientNum = null, string NSCCarrierName = null, string NSCCarrierConditions = null, string NSCCarrierSafetyRating = null, string NSCPolicyNumber = null, DateTime? NSCPolicyEffectiveDate = null, DateTime? NSCPolicyStatusDate = null, DateTime? NSCPolicyExpiryDate = null, string NSCPolicyStatus = null, string NSCPlateDecal = null)
        {
            
            this.Id = Id;
            this.ICBCRegi = ICBCRegi;
            this.ICBCModelYear = ICBCModelYear;
            this.ICBCVehicleType = ICBCVehicleType;
            this.ICBCRateClass = ICBCRateClass;
            this.ICBCCVIPDecal = ICBCCVIPDecal;
            this.ICBCFleetUnitNo = ICBCFleetUnitNo;
            this.ICBCGrossVehicleWeight = ICBCGrossVehicleWeight;
            this.ICBCMake = ICBCMake;
            this.ICBCBody = ICBCBody;
            this.ICBCRebuiltStatus = ICBCRebuiltStatus;
            this.ICBCCVIPExpiry = ICBCCVIPExpiry;
            this.ICBCNetWt = ICBCNetWt;
            this.ICBCModel = ICBCModel;
            this.ICBCFuel = ICBCFuel;
            this.ICBCSeatingCapacity = ICBCSeatingCapacity;
            this.ICBCColour = ICBCColour;
            this.ICBCNotesAndOrders = ICBCNotesAndOrders;
            this.ICBCOrderedOn = ICBCOrderedOn;
            this.ICBCRegOwnerName = ICBCRegOwnerName;
            this.ICBCRegOwnerAddr1 = ICBCRegOwnerAddr1;
            this.ICBCRegOwnerAddr2 = ICBCRegOwnerAddr2;
            this.ICBCRegOwnerCity = ICBCRegOwnerCity;
            this.ICBCRegOwnerProv = ICBCRegOwnerProv;
            this.ICBCRegOwnerPostalCode = ICBCRegOwnerPostalCode;
            this.ICBCRegOwnerStatus = ICBCRegOwnerStatus;
            this.ICBCRegOwnerRODL = ICBCRegOwnerRODL;
            this.ICBCRegOwnerPool = ICBCRegOwnerPool;
            this.NSCClientNum = NSCClientNum;
            this.NSCCarrierName = NSCCarrierName;
            this.NSCCarrierConditions = NSCCarrierConditions;
            this.NSCCarrierSafetyRating = NSCCarrierSafetyRating;
            this.NSCPolicyNumber = NSCPolicyNumber;
            this.NSCPolicyEffectiveDate = NSCPolicyEffectiveDate;
            this.NSCPolicyStatusDate = NSCPolicyStatusDate;
            this.NSCPolicyExpiryDate = NSCPolicyExpiryDate;
            this.NSCPolicyStatus = NSCPolicyStatus;
            this.NSCPlateDecal = NSCPlateDecal;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// The Registration Number (Regi) is the link between the CCW information and a specific School Bus
        /// </summary>
        /// <value>The Registration Number (Regi) is the link between the CCW information and a specific School Bus</value>
        [MetaDataExtension (Description = "The Registration Number (Regi) is the link between the CCW information and a specific School Bus")]
        public string ICBCRegi { get; set; }

        /// <summary>
        /// Vehicle Year
        /// </summary>
        /// <value>Vehicle Year</value>
        [MetaDataExtension (Description = "Vehicle Year")]
        public int? ICBCModelYear { get; set; }

        /// <summary>
        /// Gets or Sets ICBCVehicleType
        /// </summary>
        public string ICBCVehicleType { get; set; }

        /// <summary>
        /// Gets or Sets ICBCRateClass
        /// </summary>
        public string ICBCRateClass { get; set; }

        /// <summary>
        /// Gets or Sets ICBCCVIPDecal
        /// </summary>
        public string ICBCCVIPDecal { get; set; }

        /// <summary>
        /// Gets or Sets ICBCFleetUnitNo
        /// </summary>
        public int? ICBCFleetUnitNo { get; set; }

        /// <summary>
        /// Gets or Sets ICBCGrossVehicleWeight
        /// </summary>
        public int? ICBCGrossVehicleWeight { get; set; }

        /// <summary>
        /// Gets or Sets ICBCMake
        /// </summary>
        public string ICBCMake { get; set; }

        /// <summary>
        /// Gets or Sets ICBCBody
        /// </summary>
        public string ICBCBody { get; set; }

        /// <summary>
        /// Gets or Sets ICBCRebuiltStatus
        /// </summary>
        public string ICBCRebuiltStatus { get; set; }

        /// <summary>
        /// Gets or Sets ICBCCVIPExpiry
        /// </summary>
        public DateTime? ICBCCVIPExpiry { get; set; }

        /// <summary>
        /// Gets or Sets ICBCNetWt
        /// </summary>
        public int? ICBCNetWt { get; set; }

        /// <summary>
        /// Gets or Sets ICBCModel
        /// </summary>
        public string ICBCModel { get; set; }

        /// <summary>
        /// Gets or Sets ICBCFuel
        /// </summary>
        public string ICBCFuel { get; set; }

        /// <summary>
        /// Gets or Sets ICBCSeatingCapacity
        /// </summary>
        public int? ICBCSeatingCapacity { get; set; }

        /// <summary>
        /// Gets or Sets ICBCColour
        /// </summary>
        public string ICBCColour { get; set; }

        /// <summary>
        /// Gets or Sets ICBCNotesAndOrders
        /// </summary>
        public string ICBCNotesAndOrders { get; set; }

        /// <summary>
        /// Gets or Sets ICBCOrderedOn
        /// </summary>
        public DateTime? ICBCOrderedOn { get; set; }

        /// <summary>
        /// Gets or Sets ICBCRegOwnerName
        /// </summary>
        public string ICBCRegOwnerName { get; set; }

        /// <summary>
        /// Gets or Sets ICBCRegOwnerAddr1
        /// </summary>
        public string ICBCRegOwnerAddr1 { get; set; }

        /// <summary>
        /// Gets or Sets ICBCRegOwnerAddr2
        /// </summary>
        public string ICBCRegOwnerAddr2 { get; set; }

        /// <summary>
        /// Gets or Sets ICBCRegOwnerCity
        /// </summary>
        public string ICBCRegOwnerCity { get; set; }

        /// <summary>
        /// Gets or Sets ICBCRegOwnerProv
        /// </summary>
        public string ICBCRegOwnerProv { get; set; }

        /// <summary>
        /// Gets or Sets ICBCRegOwnerPostalCode
        /// </summary>
        public string ICBCRegOwnerPostalCode { get; set; }

        /// <summary>
        /// Gets or Sets ICBCRegOwnerStatus
        /// </summary>
        public string ICBCRegOwnerStatus { get; set; }

        /// <summary>
        /// Gets or Sets ICBCRegOwnerRODL
        /// </summary>
        public string ICBCRegOwnerRODL { get; set; }

        /// <summary>
        /// Gets or Sets ICBCRegOwnerPool
        /// </summary>
        public string ICBCRegOwnerPool { get; set; }

        /// <summary>
        /// Gets or Sets NSCClientNum
        /// </summary>
        public string NSCClientNum { get; set; }

        /// <summary>
        /// Gets or Sets NSCCarrierName
        /// </summary>
        public string NSCCarrierName { get; set; }

        /// <summary>
        /// Gets or Sets NSCCarrierConditions
        /// </summary>
        public string NSCCarrierConditions { get; set; }

        /// <summary>
        /// Gets or Sets NSCCarrierSafetyRating
        /// </summary>
        public string NSCCarrierSafetyRating { get; set; }

        /// <summary>
        /// Gets or Sets NSCPolicyNumber
        /// </summary>
        public string NSCPolicyNumber { get; set; }

        /// <summary>
        /// Gets or Sets NSCPolicyEffectiveDate
        /// </summary>
        public DateTime? NSCPolicyEffectiveDate { get; set; }

        /// <summary>
        /// Gets or Sets NSCPolicyStatusDate
        /// </summary>
        public DateTime? NSCPolicyStatusDate { get; set; }

        /// <summary>
        /// Gets or Sets NSCPolicyExpiryDate
        /// </summary>
        public DateTime? NSCPolicyExpiryDate { get; set; }

        /// <summary>
        /// Gets or Sets NSCPolicyStatus
        /// </summary>
        public string NSCPolicyStatus { get; set; }

        /// <summary>
        /// Gets or Sets NSCPlateDecal
        /// </summary>
        public string NSCPlateDecal { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CCWData {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ICBCRegi: ").Append(ICBCRegi).Append("\n");
            sb.Append("  ICBCModelYear: ").Append(ICBCModelYear).Append("\n");
            sb.Append("  ICBCVehicleType: ").Append(ICBCVehicleType).Append("\n");
            sb.Append("  ICBCRateClass: ").Append(ICBCRateClass).Append("\n");
            sb.Append("  ICBCCVIPDecal: ").Append(ICBCCVIPDecal).Append("\n");
            sb.Append("  ICBCFleetUnitNo: ").Append(ICBCFleetUnitNo).Append("\n");
            sb.Append("  ICBCGrossVehicleWeight: ").Append(ICBCGrossVehicleWeight).Append("\n");
            sb.Append("  ICBCMake: ").Append(ICBCMake).Append("\n");
            sb.Append("  ICBCBody: ").Append(ICBCBody).Append("\n");
            sb.Append("  ICBCRebuiltStatus: ").Append(ICBCRebuiltStatus).Append("\n");
            sb.Append("  ICBCCVIPExpiry: ").Append(ICBCCVIPExpiry).Append("\n");
            sb.Append("  ICBCNetWt: ").Append(ICBCNetWt).Append("\n");
            sb.Append("  ICBCModel: ").Append(ICBCModel).Append("\n");
            sb.Append("  ICBCFuel: ").Append(ICBCFuel).Append("\n");
            sb.Append("  ICBCSeatingCapacity: ").Append(ICBCSeatingCapacity).Append("\n");
            sb.Append("  ICBCColour: ").Append(ICBCColour).Append("\n");
            sb.Append("  ICBCNotesAndOrders: ").Append(ICBCNotesAndOrders).Append("\n");
            sb.Append("  ICBCOrderedOn: ").Append(ICBCOrderedOn).Append("\n");
            sb.Append("  ICBCRegOwnerName: ").Append(ICBCRegOwnerName).Append("\n");
            sb.Append("  ICBCRegOwnerAddr1: ").Append(ICBCRegOwnerAddr1).Append("\n");
            sb.Append("  ICBCRegOwnerAddr2: ").Append(ICBCRegOwnerAddr2).Append("\n");
            sb.Append("  ICBCRegOwnerCity: ").Append(ICBCRegOwnerCity).Append("\n");
            sb.Append("  ICBCRegOwnerProv: ").Append(ICBCRegOwnerProv).Append("\n");
            sb.Append("  ICBCRegOwnerPostalCode: ").Append(ICBCRegOwnerPostalCode).Append("\n");
            sb.Append("  ICBCRegOwnerStatus: ").Append(ICBCRegOwnerStatus).Append("\n");
            sb.Append("  ICBCRegOwnerRODL: ").Append(ICBCRegOwnerRODL).Append("\n");
            sb.Append("  ICBCRegOwnerPool: ").Append(ICBCRegOwnerPool).Append("\n");
            sb.Append("  NSCClientNum: ").Append(NSCClientNum).Append("\n");
            sb.Append("  NSCCarrierName: ").Append(NSCCarrierName).Append("\n");
            sb.Append("  NSCCarrierConditions: ").Append(NSCCarrierConditions).Append("\n");
            sb.Append("  NSCCarrierSafetyRating: ").Append(NSCCarrierSafetyRating).Append("\n");
            sb.Append("  NSCPolicyNumber: ").Append(NSCPolicyNumber).Append("\n");
            sb.Append("  NSCPolicyEffectiveDate: ").Append(NSCPolicyEffectiveDate).Append("\n");
            sb.Append("  NSCPolicyStatusDate: ").Append(NSCPolicyStatusDate).Append("\n");
            sb.Append("  NSCPolicyExpiryDate: ").Append(NSCPolicyExpiryDate).Append("\n");
            sb.Append("  NSCPolicyStatus: ").Append(NSCPolicyStatus).Append("\n");
            sb.Append("  NSCPlateDecal: ").Append(NSCPlateDecal).Append("\n");
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
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.ICBCRegi == other.ICBCRegi ||
                    this.ICBCRegi != null &&
                    this.ICBCRegi.Equals(other.ICBCRegi)
                ) && 
                (
                    this.ICBCModelYear == other.ICBCModelYear ||
                    this.ICBCModelYear != null &&
                    this.ICBCModelYear.Equals(other.ICBCModelYear)
                ) && 
                (
                    this.ICBCVehicleType == other.ICBCVehicleType ||
                    this.ICBCVehicleType != null &&
                    this.ICBCVehicleType.Equals(other.ICBCVehicleType)
                ) && 
                (
                    this.ICBCRateClass == other.ICBCRateClass ||
                    this.ICBCRateClass != null &&
                    this.ICBCRateClass.Equals(other.ICBCRateClass)
                ) && 
                (
                    this.ICBCCVIPDecal == other.ICBCCVIPDecal ||
                    this.ICBCCVIPDecal != null &&
                    this.ICBCCVIPDecal.Equals(other.ICBCCVIPDecal)
                ) && 
                (
                    this.ICBCFleetUnitNo == other.ICBCFleetUnitNo ||
                    this.ICBCFleetUnitNo != null &&
                    this.ICBCFleetUnitNo.Equals(other.ICBCFleetUnitNo)
                ) && 
                (
                    this.ICBCGrossVehicleWeight == other.ICBCGrossVehicleWeight ||
                    this.ICBCGrossVehicleWeight != null &&
                    this.ICBCGrossVehicleWeight.Equals(other.ICBCGrossVehicleWeight)
                ) && 
                (
                    this.ICBCMake == other.ICBCMake ||
                    this.ICBCMake != null &&
                    this.ICBCMake.Equals(other.ICBCMake)
                ) && 
                (
                    this.ICBCBody == other.ICBCBody ||
                    this.ICBCBody != null &&
                    this.ICBCBody.Equals(other.ICBCBody)
                ) && 
                (
                    this.ICBCRebuiltStatus == other.ICBCRebuiltStatus ||
                    this.ICBCRebuiltStatus != null &&
                    this.ICBCRebuiltStatus.Equals(other.ICBCRebuiltStatus)
                ) && 
                (
                    this.ICBCCVIPExpiry == other.ICBCCVIPExpiry ||
                    this.ICBCCVIPExpiry != null &&
                    this.ICBCCVIPExpiry.Equals(other.ICBCCVIPExpiry)
                ) && 
                (
                    this.ICBCNetWt == other.ICBCNetWt ||
                    this.ICBCNetWt != null &&
                    this.ICBCNetWt.Equals(other.ICBCNetWt)
                ) && 
                (
                    this.ICBCModel == other.ICBCModel ||
                    this.ICBCModel != null &&
                    this.ICBCModel.Equals(other.ICBCModel)
                ) && 
                (
                    this.ICBCFuel == other.ICBCFuel ||
                    this.ICBCFuel != null &&
                    this.ICBCFuel.Equals(other.ICBCFuel)
                ) && 
                (
                    this.ICBCSeatingCapacity == other.ICBCSeatingCapacity ||
                    this.ICBCSeatingCapacity != null &&
                    this.ICBCSeatingCapacity.Equals(other.ICBCSeatingCapacity)
                ) && 
                (
                    this.ICBCColour == other.ICBCColour ||
                    this.ICBCColour != null &&
                    this.ICBCColour.Equals(other.ICBCColour)
                ) && 
                (
                    this.ICBCNotesAndOrders == other.ICBCNotesAndOrders ||
                    this.ICBCNotesAndOrders != null &&
                    this.ICBCNotesAndOrders.Equals(other.ICBCNotesAndOrders)
                ) && 
                (
                    this.ICBCOrderedOn == other.ICBCOrderedOn ||
                    this.ICBCOrderedOn != null &&
                    this.ICBCOrderedOn.Equals(other.ICBCOrderedOn)
                ) && 
                (
                    this.ICBCRegOwnerName == other.ICBCRegOwnerName ||
                    this.ICBCRegOwnerName != null &&
                    this.ICBCRegOwnerName.Equals(other.ICBCRegOwnerName)
                ) && 
                (
                    this.ICBCRegOwnerAddr1 == other.ICBCRegOwnerAddr1 ||
                    this.ICBCRegOwnerAddr1 != null &&
                    this.ICBCRegOwnerAddr1.Equals(other.ICBCRegOwnerAddr1)
                ) && 
                (
                    this.ICBCRegOwnerAddr2 == other.ICBCRegOwnerAddr2 ||
                    this.ICBCRegOwnerAddr2 != null &&
                    this.ICBCRegOwnerAddr2.Equals(other.ICBCRegOwnerAddr2)
                ) && 
                (
                    this.ICBCRegOwnerCity == other.ICBCRegOwnerCity ||
                    this.ICBCRegOwnerCity != null &&
                    this.ICBCRegOwnerCity.Equals(other.ICBCRegOwnerCity)
                ) && 
                (
                    this.ICBCRegOwnerProv == other.ICBCRegOwnerProv ||
                    this.ICBCRegOwnerProv != null &&
                    this.ICBCRegOwnerProv.Equals(other.ICBCRegOwnerProv)
                ) && 
                (
                    this.ICBCRegOwnerPostalCode == other.ICBCRegOwnerPostalCode ||
                    this.ICBCRegOwnerPostalCode != null &&
                    this.ICBCRegOwnerPostalCode.Equals(other.ICBCRegOwnerPostalCode)
                ) && 
                (
                    this.ICBCRegOwnerStatus == other.ICBCRegOwnerStatus ||
                    this.ICBCRegOwnerStatus != null &&
                    this.ICBCRegOwnerStatus.Equals(other.ICBCRegOwnerStatus)
                ) && 
                (
                    this.ICBCRegOwnerRODL == other.ICBCRegOwnerRODL ||
                    this.ICBCRegOwnerRODL != null &&
                    this.ICBCRegOwnerRODL.Equals(other.ICBCRegOwnerRODL)
                ) && 
                (
                    this.ICBCRegOwnerPool == other.ICBCRegOwnerPool ||
                    this.ICBCRegOwnerPool != null &&
                    this.ICBCRegOwnerPool.Equals(other.ICBCRegOwnerPool)
                ) && 
                (
                    this.NSCClientNum == other.NSCClientNum ||
                    this.NSCClientNum != null &&
                    this.NSCClientNum.Equals(other.NSCClientNum)
                ) && 
                (
                    this.NSCCarrierName == other.NSCCarrierName ||
                    this.NSCCarrierName != null &&
                    this.NSCCarrierName.Equals(other.NSCCarrierName)
                ) && 
                (
                    this.NSCCarrierConditions == other.NSCCarrierConditions ||
                    this.NSCCarrierConditions != null &&
                    this.NSCCarrierConditions.Equals(other.NSCCarrierConditions)
                ) && 
                (
                    this.NSCCarrierSafetyRating == other.NSCCarrierSafetyRating ||
                    this.NSCCarrierSafetyRating != null &&
                    this.NSCCarrierSafetyRating.Equals(other.NSCCarrierSafetyRating)
                ) && 
                (
                    this.NSCPolicyNumber == other.NSCPolicyNumber ||
                    this.NSCPolicyNumber != null &&
                    this.NSCPolicyNumber.Equals(other.NSCPolicyNumber)
                ) && 
                (
                    this.NSCPolicyEffectiveDate == other.NSCPolicyEffectiveDate ||
                    this.NSCPolicyEffectiveDate != null &&
                    this.NSCPolicyEffectiveDate.Equals(other.NSCPolicyEffectiveDate)
                ) && 
                (
                    this.NSCPolicyStatusDate == other.NSCPolicyStatusDate ||
                    this.NSCPolicyStatusDate != null &&
                    this.NSCPolicyStatusDate.Equals(other.NSCPolicyStatusDate)
                ) && 
                (
                    this.NSCPolicyExpiryDate == other.NSCPolicyExpiryDate ||
                    this.NSCPolicyExpiryDate != null &&
                    this.NSCPolicyExpiryDate.Equals(other.NSCPolicyExpiryDate)
                ) && 
                (
                    this.NSCPolicyStatus == other.NSCPolicyStatus ||
                    this.NSCPolicyStatus != null &&
                    this.NSCPolicyStatus.Equals(other.NSCPolicyStatus)
                ) && 
                (
                    this.NSCPlateDecal == other.NSCPlateDecal ||
                    this.NSCPlateDecal != null &&
                    this.NSCPlateDecal.Equals(other.NSCPlateDecal)
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
                
                if (this.ICBCRegi != null)
                {
                    hash = hash * 59 + this.ICBCRegi.GetHashCode();
                }
                if (this.ICBCModelYear != null)
                {
                    hash = hash * 59 + this.ICBCModelYear.GetHashCode();
                }
                if (this.ICBCVehicleType != null)
                {
                    hash = hash * 59 + this.ICBCVehicleType.GetHashCode();
                }
                if (this.ICBCRateClass != null)
                {
                    hash = hash * 59 + this.ICBCRateClass.GetHashCode();
                }
                if (this.ICBCCVIPDecal != null)
                {
                    hash = hash * 59 + this.ICBCCVIPDecal.GetHashCode();
                }
                if (this.ICBCFleetUnitNo != null)
                {
                    hash = hash * 59 + this.ICBCFleetUnitNo.GetHashCode();
                }
                if (this.ICBCGrossVehicleWeight != null)
                {
                    hash = hash * 59 + this.ICBCGrossVehicleWeight.GetHashCode();
                }
                if (this.ICBCMake != null)
                {
                    hash = hash * 59 + this.ICBCMake.GetHashCode();
                }
                if (this.ICBCBody != null)
                {
                    hash = hash * 59 + this.ICBCBody.GetHashCode();
                }
                if (this.ICBCRebuiltStatus != null)
                {
                    hash = hash * 59 + this.ICBCRebuiltStatus.GetHashCode();
                }
                if (this.ICBCCVIPExpiry != null)
                {
                    hash = hash * 59 + this.ICBCCVIPExpiry.GetHashCode();
                }
                if (this.ICBCNetWt != null)
                {
                    hash = hash * 59 + this.ICBCNetWt.GetHashCode();
                }
                if (this.ICBCModel != null)
                {
                    hash = hash * 59 + this.ICBCModel.GetHashCode();
                }
                if (this.ICBCFuel != null)
                {
                    hash = hash * 59 + this.ICBCFuel.GetHashCode();
                }
                if (this.ICBCSeatingCapacity != null)
                {
                    hash = hash * 59 + this.ICBCSeatingCapacity.GetHashCode();
                }
                if (this.ICBCColour != null)
                {
                    hash = hash * 59 + this.ICBCColour.GetHashCode();
                }
                if (this.ICBCNotesAndOrders != null)
                {
                    hash = hash * 59 + this.ICBCNotesAndOrders.GetHashCode();
                }
                if (this.ICBCOrderedOn != null)
                {
                    hash = hash * 59 + this.ICBCOrderedOn.GetHashCode();
                }
                if (this.ICBCRegOwnerName != null)
                {
                    hash = hash * 59 + this.ICBCRegOwnerName.GetHashCode();
                }
                if (this.ICBCRegOwnerAddr1 != null)
                {
                    hash = hash * 59 + this.ICBCRegOwnerAddr1.GetHashCode();
                }
                if (this.ICBCRegOwnerAddr2 != null)
                {
                    hash = hash * 59 + this.ICBCRegOwnerAddr2.GetHashCode();
                }
                if (this.ICBCRegOwnerCity != null)
                {
                    hash = hash * 59 + this.ICBCRegOwnerCity.GetHashCode();
                }
                if (this.ICBCRegOwnerProv != null)
                {
                    hash = hash * 59 + this.ICBCRegOwnerProv.GetHashCode();
                }
                if (this.ICBCRegOwnerPostalCode != null)
                {
                    hash = hash * 59 + this.ICBCRegOwnerPostalCode.GetHashCode();
                }
                if (this.ICBCRegOwnerStatus != null)
                {
                    hash = hash * 59 + this.ICBCRegOwnerStatus.GetHashCode();
                }
                if (this.ICBCRegOwnerRODL != null)
                {
                    hash = hash * 59 + this.ICBCRegOwnerRODL.GetHashCode();
                }
                if (this.ICBCRegOwnerPool != null)
                {
                    hash = hash * 59 + this.ICBCRegOwnerPool.GetHashCode();
                }
                if (this.NSCClientNum != null)
                {
                    hash = hash * 59 + this.NSCClientNum.GetHashCode();
                }
                if (this.NSCCarrierName != null)
                {
                    hash = hash * 59 + this.NSCCarrierName.GetHashCode();
                }
                if (this.NSCCarrierConditions != null)
                {
                    hash = hash * 59 + this.NSCCarrierConditions.GetHashCode();
                }
                if (this.NSCCarrierSafetyRating != null)
                {
                    hash = hash * 59 + this.NSCCarrierSafetyRating.GetHashCode();
                }
                if (this.NSCPolicyNumber != null)
                {
                    hash = hash * 59 + this.NSCPolicyNumber.GetHashCode();
                }
                if (this.NSCPolicyEffectiveDate != null)
                {
                    hash = hash * 59 + this.NSCPolicyEffectiveDate.GetHashCode();
                }
                if (this.NSCPolicyStatusDate != null)
                {
                    hash = hash * 59 + this.NSCPolicyStatusDate.GetHashCode();
                }
                if (this.NSCPolicyExpiryDate != null)
                {
                    hash = hash * 59 + this.NSCPolicyExpiryDate.GetHashCode();
                }
                if (this.NSCPolicyStatus != null)
                {
                    hash = hash * 59 + this.NSCPolicyStatus.GetHashCode();
                }
                if (this.NSCPlateDecal != null)
                {
                    hash = hash * 59 + this.NSCPlateDecal.GetHashCode();
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
