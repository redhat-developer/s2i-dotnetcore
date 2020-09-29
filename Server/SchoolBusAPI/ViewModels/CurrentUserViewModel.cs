/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System.Collections.Generic;
using System.Runtime.Serialization;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CurrentUserViewModel
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets GivenName
        /// </summary>
        [DataMember(Name="givenName")]
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or Sets Surname
        /// </summary>
        [DataMember(Name="surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name="email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Active
        /// </summary>
        [DataMember(Name="active")]
        public bool? Active { get; set; }

        [DataMember(Name ="permissions")]
        public List<string> Permissions { get; set; }

        /// <summary>
        /// Gets or Sets SmUserId
        /// </summary>
        [DataMember(Name="smUserId")]
        public string SmUserId { get; set; }

        /// <summary>
        /// Gets or Sets SmAuthorizationDirectory
        /// </summary>
        [DataMember(Name="smAuthorizationDirectory")]
        public string SmAuthorizationDirectory { get; set; }

        /// <summary>
        /// The District to which this User is affliated.
        /// </summary>
        /// <value>The District to which this User is affliated.</value>
        [DataMember(Name="district")]
        [MetaDataExtension (Description = "The District to which this User is affliated.")]
        public District District { get; set; }

        /// <summary>
        /// Gets or Sets OverdueInspections
        /// </summary>
        [DataMember(Name="overdueInspections")]
        public int? OverdueInspections { get; set; }

        /// <summary>
        /// Gets or Sets ScheduledInspections
        /// </summary>
        [DataMember(Name="scheduledInspections")]
        public int? ScheduledInspections { get; set; }

        /// <summary>
        /// Gets or Sets DueNextMonthInspections
        /// </summary>
        [DataMember(Name="dueWithin30DaysInspections")]
        public int? DueWithin30DaysInspections { get; set; }

        /// <summary>
        /// Gets or Sets ReInspections
        /// </summary>
        [DataMember(Name="reInspections")]
        public int? ReInspections { get; set; }

        [DataMember(Name="isSysAdmin")]
        public bool IsSysAdmin { get; set; }

        [DataMember(Name="isManager")]
        public bool IsManager { get; set; }

        [DataMember(Name="isInspector")]
        public bool IsInspector { get; set; }

        [DataMember(Name="districtId")]
        public int? DistrictId { get; set; }
    }
}
