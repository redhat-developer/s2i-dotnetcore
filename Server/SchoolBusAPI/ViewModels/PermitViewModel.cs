/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System.Runtime.Serialization;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class PermitViewModel
    {
        /// <summary>
        /// Gets or Sets PermitNumber
        /// </summary>
        [DataMember(Name="permitNumber")]
        public int? PermitNumber { get; set; }

        /// <summary>
        /// Gets or Sets PermitIssueDate
        /// </summary>
        [DataMember(Name="permitIssueDate")]
        public string PermitIssueDate { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusOwnerName
        /// </summary>
        [DataMember(Name="schoolBusOwnerName")]
        public string SchoolBusOwnerName { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusOwnerAddressLine1
        /// </summary>
        [DataMember(Name="schoolBusOwnerAddressLine1")]
        public string SchoolBusOwnerAddressLine1 { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusOwnerAddressLine2
        /// </summary>
        [DataMember(Name="schoolBusOwnerAddressLine2")]
        public string SchoolBusOwnerAddressLine2 { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusMobilityAidCapacity
        /// </summary>
        [DataMember(Name="schoolBusMobilityAidCapacity")]
        public string SchoolBusMobilityAidCapacity { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusOwnerCity
        /// </summary>
        [DataMember(Name="schoolBusOwnerCity")]
        public string SchoolBusOwnerCity { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusOwnerProvince
        /// </summary>
        [DataMember(Name="schoolBusOwnerProvince")]
        public string SchoolBusOwnerProvince { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusOwnerPostalCode
        /// </summary>
        [DataMember(Name="schoolBusOwnerPostalCode")]
        public string SchoolBusOwnerPostalCode { get; set; }

        /// <summary>
        /// Gets or Sets IcbcRegistrationNumber
        /// </summary>
        [DataMember(Name="icbcRegistrationNumber")]
        public string IcbcRegistrationNumber { get; set; }

        /// <summary>
        /// Gets or Sets VehicleIdentificationNumber
        /// </summary>
        [DataMember(Name="vehicleIdentificationNumber")]
        public string VehicleIdentificationNumber { get; set; }

        /// <summary>
        /// Gets or Sets IcbcModelYear
        /// </summary>
        [DataMember(Name="icbcModelYear")]
        public int? IcbcModelYear { get; set; }

        /// <summary>
        /// Gets or Sets IcbcMake
        /// </summary>
        [DataMember(Name="icbcMake")]
        public string IcbcMake { get; set; }

        /// <summary>
        /// Gets or Sets RestrictionsText
        /// </summary>
        [DataMember(Name="restrictionsText")]
        public string RestrictionsText { get; set; }

        /// <summary>
        /// Gets or Sets SchoolDistrictshortName
        /// </summary>
        [DataMember(Name="schoolDistrictshortName")]
        public string SchoolDistrictshortName { get; set; }

        /// <summary>
        /// Gets or Sets SchoolBusSeatingCapacity
        /// </summary>
        [DataMember(Name="schoolBusSeatingCapacity")]
        public int? SchoolBusSeatingCapacity { get; set; }

        /// <summary>
        /// The unit number of the Bus as defined by the School Bus owner - freeform text.
        /// </summary>
        /// <value>The unit number of the Bus as defined by the School Bus owner - freeform text.</value>
        [DataMember(Name="unitNumber")]
        [MetaDataExtension (Description = "The unit number of the Bus as defined by the School Bus owner - freeform text.")]
        public string UnitNumber { get; set; }

        /// <summary>
        /// The enumerated class of School Bus from drop down
        /// </summary>
        /// <value>The enumerated class of School Bus from drop down</value>
        [DataMember(Name="permitClassCode")]
        [MetaDataExtension (Description = "The enumerated class of School Bus from drop down")]
        public string PermitClassCode { get; set; }

        /// <summary>
        /// The enumerated body type of the School Bus from drop down
        /// </summary>
        /// <value>The enumerated body type of the School Bus from drop down</value>
        [DataMember(Name="bodyTypeCode")]
        [MetaDataExtension (Description = "The enumerated body type of the School Bus from drop down")]
        public string BodyTypeCode { get; set; }

    }
}
