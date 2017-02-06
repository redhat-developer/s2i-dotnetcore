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
    /// Data pulled in from external sources (ICBC, NSC, etc) about School Buses and retained but not updated in the School Bus app. All data elements are simply copied from the comparable fields in the WSDLs of the Web Service Calls. The true source of the field definitions are in those other systems.
    /// </summary>
        [MetaDataExtension (Description = "Data pulled in from external sources (ICBC, NSC, etc) about School Buses and retained but not updated in the School Bus app. All data elements are simply copied from the comparable fields in the WSDLs of the Web Service Calls. The true source of the field definitions are in those other systems.")]

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
        /// <param name="Id">A system-generated unique identifier for CCWData (required).</param>
        /// <param name="ICBCRegistrationNumber">The Registration Number (Regi) is the link between the CCW vehicle information and a specific School Bus.</param>
        /// <param name="ICBCModelYear">Vehicle Year.</param>
        /// <param name="ICBCVehicleType">ICBC defined field - designates Commercial, Private, Other Categories.</param>
        /// <param name="ICBCRateClass">Defines usage such as pleasure only, business, delivery, etc...</param>
        /// <param name="ICBCCVIPDecal">Six monthly commercial vehicle inspection decal number.</param>
        /// <param name="ICBCFleetUnitNo">The owner-defined number of the bus within their bus fleet..</param>
        /// <param name="ICBCGrossVehicleWeight">Vehicle gross weight in kgs.</param>
        /// <param name="ICBCMake">Vehicle make.</param>
        /// <param name="ICBCBody">Vehicle body code.</param>
        /// <param name="ICBCRebuiltStatus">ICBC coded field about whether or not the vehicle has been rebuilt and if so the nature of the rebuilding..</param>
        /// <param name="ICBCCVIPExpiry">Expiry date of the last 6 month commercial vehicle inspection..</param>
        /// <param name="ICBCNetWt">Vehicle net weight in kgs.</param>
        /// <param name="ICBCModel">Vehicle model codes used by ICBC - for example bus, scbus, dump, logtr.</param>
        /// <param name="ICBCFuel">Fuel type gasoline, propane, diesel etc...</param>
        /// <param name="ICBCSeatingCapacity">Vehicle seating capacity including driver.</param>
        /// <param name="ICBCColour">Vehicle color ex BLU, WHI, etc...</param>
        /// <param name="ICBCNotesAndOrders">Notes and orders from ICBC about the vehicle..</param>
        /// <param name="ICBCOrderedOn">TO BE DETERMINED.</param>
        /// <param name="ICBCRegOwnerName">The name of the registered owner of the vehicle - per ICBC..</param>
        /// <param name="ICBCRegOwnerAddr1">Owners address line 1.</param>
        /// <param name="ICBCRegOwnerAddr2">Owners address line 2.</param>
        /// <param name="ICBCRegOwnerCity">Owners address city.</param>
        /// <param name="ICBCRegOwnerProv">Owners address Province.</param>
        /// <param name="ICBCRegOwnerPostalCode">Owners address Postal Code.</param>
        /// <param name="ICBCRegOwnerStatus">The status (as defined by ICBC) of the registered owner of the vehicle..</param>
        /// <param name="ICBCRegOwnerRODL">Registered Owners Driver Licence number.</param>
        /// <param name="ICBCRegOwnerPODL">Previous Owners Driver Licence number.</param>
        /// <param name="NSCClientNum">National Safety Code Carrier Number on ICBC client system.</param>
        /// <param name="NSCCarrierName">National Safety Code Carrier Name on ICBC client system.</param>
        /// <param name="NSCCarrierConditions">Conditions imposed on the carrier (bus owner) within NSC.</param>
        /// <param name="NSCCarrierSafetyRating">Carrier safety rating ex - satisfatory, SAT-unaudited etc...</param>
        /// <param name="NSCPolicyNumber">From NSC - The number of the carrier (NSC Clients) necessary insurance required to operate the vehicle..</param>
        /// <param name="NSCPolicyEffectiveDate">From NSC - The effective data of the policy..</param>
        /// <param name="NSCPolicyStatusDate">From NSC - The date the status of the policy was established..</param>
        /// <param name="NSCPolicyExpiryDate">From NSC - The data of expiration of the policy..</param>
        /// <param name="NSCPolicyStatus">From NSC - The latest status of the policy..</param>
        /// <param name="NSCPlateDecal">From NSC - The plate decal as defined by NSC on the vehicle.</param>
        public CCWData(int Id, string ICBCRegistrationNumber = null, int? ICBCModelYear = null, string ICBCVehicleType = null, string ICBCRateClass = null, string ICBCCVIPDecal = null, int? ICBCFleetUnitNo = null, int? ICBCGrossVehicleWeight = null, string ICBCMake = null, string ICBCBody = null, string ICBCRebuiltStatus = null, DateTime? ICBCCVIPExpiry = null, int? ICBCNetWt = null, string ICBCModel = null, string ICBCFuel = null, int? ICBCSeatingCapacity = null, string ICBCColour = null, string ICBCNotesAndOrders = null, DateTime? ICBCOrderedOn = null, string ICBCRegOwnerName = null, string ICBCRegOwnerAddr1 = null, string ICBCRegOwnerAddr2 = null, string ICBCRegOwnerCity = null, string ICBCRegOwnerProv = null, string ICBCRegOwnerPostalCode = null, string ICBCRegOwnerStatus = null, string ICBCRegOwnerRODL = null, string ICBCRegOwnerPODL = null, string NSCClientNum = null, string NSCCarrierName = null, string NSCCarrierConditions = null, string NSCCarrierSafetyRating = null, string NSCPolicyNumber = null, DateTime? NSCPolicyEffectiveDate = null, DateTime? NSCPolicyStatusDate = null, DateTime? NSCPolicyExpiryDate = null, string NSCPolicyStatus = null, string NSCPlateDecal = null)
        {   
            this.Id = Id;
            this.ICBCRegistrationNumber = ICBCRegistrationNumber;
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
            this.ICBCRegOwnerPODL = ICBCRegOwnerPODL;
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
        /// A system-generated unique identifier for CCWData
        /// </summary>
        /// <value>A system-generated unique identifier for CCWData</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for CCWData")]
        public int Id { get; set; }
        
        /// <summary>
        /// The Registration Number (Regi) is the link between the CCW vehicle information and a specific School Bus
        /// </summary>
        /// <value>The Registration Number (Regi) is the link between the CCW vehicle information and a specific School Bus</value>
        [MetaDataExtension (Description = "The Registration Number (Regi) is the link between the CCW vehicle information and a specific School Bus")]
        [MaxLength(255)]
        
        public string ICBCRegistrationNumber { get; set; }
        
        /// <summary>
        /// Vehicle Year
        /// </summary>
        /// <value>Vehicle Year</value>
        [MetaDataExtension (Description = "Vehicle Year")]
        public int? ICBCModelYear { get; set; }
        
        /// <summary>
        /// ICBC defined field - designates Commercial, Private, Other Categories
        /// </summary>
        /// <value>ICBC defined field - designates Commercial, Private, Other Categories</value>
        [MetaDataExtension (Description = "ICBC defined field - designates Commercial, Private, Other Categories")]
        [MaxLength(255)]
        
        public string ICBCVehicleType { get; set; }
        
        /// <summary>
        /// Defines usage such as pleasure only, business, delivery, etc..
        /// </summary>
        /// <value>Defines usage such as pleasure only, business, delivery, etc..</value>
        [MetaDataExtension (Description = "Defines usage such as pleasure only, business, delivery, etc..")]
        [MaxLength(255)]
        
        public string ICBCRateClass { get; set; }
        
        /// <summary>
        /// Six monthly commercial vehicle inspection decal number
        /// </summary>
        /// <value>Six monthly commercial vehicle inspection decal number</value>
        [MetaDataExtension (Description = "Six monthly commercial vehicle inspection decal number")]
        [MaxLength(255)]
        
        public string ICBCCVIPDecal { get; set; }
        
        /// <summary>
        /// The owner-defined number of the bus within their bus fleet.
        /// </summary>
        /// <value>The owner-defined number of the bus within their bus fleet.</value>
        [MetaDataExtension (Description = "The owner-defined number of the bus within their bus fleet.")]
        public int? ICBCFleetUnitNo { get; set; }
        
        /// <summary>
        /// Vehicle gross weight in kgs
        /// </summary>
        /// <value>Vehicle gross weight in kgs</value>
        [MetaDataExtension (Description = "Vehicle gross weight in kgs")]
        public int? ICBCGrossVehicleWeight { get; set; }
        
        /// <summary>
        /// Vehicle make
        /// </summary>
        /// <value>Vehicle make</value>
        [MetaDataExtension (Description = "Vehicle make")]
        [MaxLength(255)]
        
        public string ICBCMake { get; set; }
        
        /// <summary>
        /// Vehicle body code
        /// </summary>
        /// <value>Vehicle body code</value>
        [MetaDataExtension (Description = "Vehicle body code")]
        [MaxLength(255)]
        
        public string ICBCBody { get; set; }
        
        /// <summary>
        /// ICBC coded field about whether or not the vehicle has been rebuilt and if so the nature of the rebuilding.
        /// </summary>
        /// <value>ICBC coded field about whether or not the vehicle has been rebuilt and if so the nature of the rebuilding.</value>
        [MetaDataExtension (Description = "ICBC coded field about whether or not the vehicle has been rebuilt and if so the nature of the rebuilding.")]
        [MaxLength(255)]
        
        public string ICBCRebuiltStatus { get; set; }
        
        /// <summary>
        /// Expiry date of the last 6 month commercial vehicle inspection.
        /// </summary>
        /// <value>Expiry date of the last 6 month commercial vehicle inspection.</value>
        [MetaDataExtension (Description = "Expiry date of the last 6 month commercial vehicle inspection.")]
        public DateTime? ICBCCVIPExpiry { get; set; }
        
        /// <summary>
        /// Vehicle net weight in kgs
        /// </summary>
        /// <value>Vehicle net weight in kgs</value>
        [MetaDataExtension (Description = "Vehicle net weight in kgs")]
        public int? ICBCNetWt { get; set; }
        
        /// <summary>
        /// Vehicle model codes used by ICBC - for example bus, scbus, dump, logtr
        /// </summary>
        /// <value>Vehicle model codes used by ICBC - for example bus, scbus, dump, logtr</value>
        [MetaDataExtension (Description = "Vehicle model codes used by ICBC - for example bus, scbus, dump, logtr")]
        [MaxLength(255)]
        
        public string ICBCModel { get; set; }
        
        /// <summary>
        /// Fuel type gasoline, propane, diesel etc..
        /// </summary>
        /// <value>Fuel type gasoline, propane, diesel etc..</value>
        [MetaDataExtension (Description = "Fuel type gasoline, propane, diesel etc..")]
        [MaxLength(255)]
        
        public string ICBCFuel { get; set; }
        
        /// <summary>
        /// Vehicle seating capacity including driver
        /// </summary>
        /// <value>Vehicle seating capacity including driver</value>
        [MetaDataExtension (Description = "Vehicle seating capacity including driver")]
        public int? ICBCSeatingCapacity { get; set; }
        
        /// <summary>
        /// Vehicle color ex BLU, WHI, etc..
        /// </summary>
        /// <value>Vehicle color ex BLU, WHI, etc..</value>
        [MetaDataExtension (Description = "Vehicle color ex BLU, WHI, etc..")]
        [MaxLength(255)]
        
        public string ICBCColour { get; set; }
        
        /// <summary>
        /// Notes and orders from ICBC about the vehicle.
        /// </summary>
        /// <value>Notes and orders from ICBC about the vehicle.</value>
        [MetaDataExtension (Description = "Notes and orders from ICBC about the vehicle.")]
        [MaxLength(255)]
        
        public string ICBCNotesAndOrders { get; set; }
        
        /// <summary>
        /// TO BE DETERMINED
        /// </summary>
        /// <value>TO BE DETERMINED</value>
        [MetaDataExtension (Description = "TO BE DETERMINED")]
        public DateTime? ICBCOrderedOn { get; set; }
        
        /// <summary>
        /// The name of the registered owner of the vehicle - per ICBC.
        /// </summary>
        /// <value>The name of the registered owner of the vehicle - per ICBC.</value>
        [MetaDataExtension (Description = "The name of the registered owner of the vehicle - per ICBC.")]
        [MaxLength(255)]
        
        public string ICBCRegOwnerName { get; set; }
        
        /// <summary>
        /// Owners address line 1
        /// </summary>
        /// <value>Owners address line 1</value>
        [MetaDataExtension (Description = "Owners address line 1")]
        [MaxLength(255)]
        
        public string ICBCRegOwnerAddr1 { get; set; }
        
        /// <summary>
        /// Owners address line 2
        /// </summary>
        /// <value>Owners address line 2</value>
        [MetaDataExtension (Description = "Owners address line 2")]
        [MaxLength(255)]
        
        public string ICBCRegOwnerAddr2 { get; set; }
        
        /// <summary>
        /// Owners address city
        /// </summary>
        /// <value>Owners address city</value>
        [MetaDataExtension (Description = "Owners address city")]
        [MaxLength(255)]
        
        public string ICBCRegOwnerCity { get; set; }
        
        /// <summary>
        /// Owners address Province
        /// </summary>
        /// <value>Owners address Province</value>
        [MetaDataExtension (Description = "Owners address Province")]
        [MaxLength(255)]
        
        public string ICBCRegOwnerProv { get; set; }
        
        /// <summary>
        /// Owners address Postal Code
        /// </summary>
        /// <value>Owners address Postal Code</value>
        [MetaDataExtension (Description = "Owners address Postal Code")]
        [MaxLength(255)]
        
        public string ICBCRegOwnerPostalCode { get; set; }
        
        /// <summary>
        /// The status (as defined by ICBC) of the registered owner of the vehicle.
        /// </summary>
        /// <value>The status (as defined by ICBC) of the registered owner of the vehicle.</value>
        [MetaDataExtension (Description = "The status (as defined by ICBC) of the registered owner of the vehicle.")]
        [MaxLength(255)]
        
        public string ICBCRegOwnerStatus { get; set; }
        
        /// <summary>
        /// Registered Owners Driver Licence number
        /// </summary>
        /// <value>Registered Owners Driver Licence number</value>
        [MetaDataExtension (Description = "Registered Owners Driver Licence number")]
        [MaxLength(255)]
        
        public string ICBCRegOwnerRODL { get; set; }
        
        /// <summary>
        /// Previous Owners Driver Licence number
        /// </summary>
        /// <value>Previous Owners Driver Licence number</value>
        [MetaDataExtension (Description = "Previous Owners Driver Licence number")]
        [MaxLength(255)]
        
        public string ICBCRegOwnerPODL { get; set; }
        
        /// <summary>
        /// National Safety Code Carrier Number on ICBC client system
        /// </summary>
        /// <value>National Safety Code Carrier Number on ICBC client system</value>
        [MetaDataExtension (Description = "National Safety Code Carrier Number on ICBC client system")]
        [MaxLength(255)]
        
        public string NSCClientNum { get; set; }
        
        /// <summary>
        /// National Safety Code Carrier Name on ICBC client system
        /// </summary>
        /// <value>National Safety Code Carrier Name on ICBC client system</value>
        [MetaDataExtension (Description = "National Safety Code Carrier Name on ICBC client system")]
        [MaxLength(255)]
        
        public string NSCCarrierName { get; set; }
        
        /// <summary>
        /// Conditions imposed on the carrier (bus owner) within NSC
        /// </summary>
        /// <value>Conditions imposed on the carrier (bus owner) within NSC</value>
        [MetaDataExtension (Description = "Conditions imposed on the carrier (bus owner) within NSC")]
        [MaxLength(255)]
        
        public string NSCCarrierConditions { get; set; }
        
        /// <summary>
        /// Carrier safety rating ex - satisfatory, SAT-unaudited etc..
        /// </summary>
        /// <value>Carrier safety rating ex - satisfatory, SAT-unaudited etc..</value>
        [MetaDataExtension (Description = "Carrier safety rating ex - satisfatory, SAT-unaudited etc..")]
        [MaxLength(255)]
        
        public string NSCCarrierSafetyRating { get; set; }
        
        /// <summary>
        /// From NSC - The number of the carrier (NSC Clients) necessary insurance required to operate the vehicle.
        /// </summary>
        /// <value>From NSC - The number of the carrier (NSC Clients) necessary insurance required to operate the vehicle.</value>
        [MetaDataExtension (Description = "From NSC - The number of the carrier (NSC Clients) necessary insurance required to operate the vehicle.")]
        [MaxLength(255)]
        
        public string NSCPolicyNumber { get; set; }
        
        /// <summary>
        /// From NSC - The effective data of the policy.
        /// </summary>
        /// <value>From NSC - The effective data of the policy.</value>
        [MetaDataExtension (Description = "From NSC - The effective data of the policy.")]
        public DateTime? NSCPolicyEffectiveDate { get; set; }
        
        /// <summary>
        /// From NSC - The date the status of the policy was established.
        /// </summary>
        /// <value>From NSC - The date the status of the policy was established.</value>
        [MetaDataExtension (Description = "From NSC - The date the status of the policy was established.")]
        public DateTime? NSCPolicyStatusDate { get; set; }
        
        /// <summary>
        /// From NSC - The data of expiration of the policy.
        /// </summary>
        /// <value>From NSC - The data of expiration of the policy.</value>
        [MetaDataExtension (Description = "From NSC - The data of expiration of the policy.")]
        public DateTime? NSCPolicyExpiryDate { get; set; }
        
        /// <summary>
        /// From NSC - The latest status of the policy.
        /// </summary>
        /// <value>From NSC - The latest status of the policy.</value>
        [MetaDataExtension (Description = "From NSC - The latest status of the policy.")]
        [MaxLength(255)]
        
        public string NSCPolicyStatus { get; set; }
        
        /// <summary>
        /// From NSC - The plate decal as defined by NSC on the vehicle
        /// </summary>
        /// <value>From NSC - The plate decal as defined by NSC on the vehicle</value>
        [MetaDataExtension (Description = "From NSC - The plate decal as defined by NSC on the vehicle")]
        [MaxLength(255)]
        
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
            sb.Append("  ICBCRegistrationNumber: ").Append(ICBCRegistrationNumber).Append("\n");
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
            sb.Append("  ICBCRegOwnerPODL: ").Append(ICBCRegOwnerPODL).Append("\n");
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
                    this.ICBCRegistrationNumber == other.ICBCRegistrationNumber ||
                    this.ICBCRegistrationNumber != null &&
                    this.ICBCRegistrationNumber.Equals(other.ICBCRegistrationNumber)
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
                    this.ICBCRegOwnerPODL == other.ICBCRegOwnerPODL ||
                    this.ICBCRegOwnerPODL != null &&
                    this.ICBCRegOwnerPODL.Equals(other.ICBCRegOwnerPODL)
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
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.ICBCRegistrationNumber != null)
                {
                    hash = hash * 59 + this.ICBCRegistrationNumber.GetHashCode();
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
                                if (this.ICBCRegOwnerPODL != null)
                {
                    hash = hash * 59 + this.ICBCRegOwnerPODL.GetHashCode();
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
        
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(CCWData left, CCWData right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(CCWData left, CCWData right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
