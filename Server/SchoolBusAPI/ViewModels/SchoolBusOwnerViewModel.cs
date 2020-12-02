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
using System.Collections.Generic;
using System.Runtime.Serialization;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class SchoolBusOwnerViewModel
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name="id")]
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the School Bus owner as defined by the user&#x2F;Inspector. Not tied to the ICBC or NSC names,  but whatever is most useful for the Inspectors.
        /// </summary>
        /// <value>The name of the School Bus owner as defined by the user&#x2F;Inspector. Not tied to the ICBC or NSC names,  but whatever is most useful for the Inspectors.</value>
        [DataMember(Name="name")]
        [MetaDataExtension (Description = "The name of the School Bus owner as defined by the user&amp;#x2F;Inspector. Not tied to the ICBC or NSC names,  but whatever is most useful for the Inspectors.")]
        public string Name { get; set; }

        /// <summary>
        /// Status of the School Bus owner - enumerated value Active,  Archived
        /// </summary>
        /// <value>Status of the School Bus owner - enumerated value Active,  Archived</value>
        [DataMember(Name="status")]
        [MetaDataExtension (Description = "Status of the School Bus owner - enumerated value Active,  Archived")]
        public string Status { get; set; }

        /// <summary>
        /// The date-time of the creation of the record from the audit fields. Since this might be surfaced in the API,  adding it to the definition.
        /// </summary>
        /// <value>The date-time of the creation of the record from the audit fields. Since this might be surfaced in the API,  adding it to the definition.</value>
        [DataMember(Name="dateCreated")]
        [MetaDataExtension (Description = "The date-time of the creation of the record from the audit fields. Since this might be surfaced in the API,  adding it to the definition.")]
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Link to the designated Primary Contact for the Inspector to the School Bus Owner organization.
        /// </summary>
        /// <value>Link to the designated Primary Contact for the Inspector to the School Bus Owner organization.</value>
        [DataMember(Name="primaryContact")]
        [MetaDataExtension (Description = "Link to the designated Primary Contact for the Inspector to the School Bus Owner organization.")]
        public Contact PrimaryContact { get; set; }

        /// <summary>
        /// The District to which this School Bus is affliated.
        /// </summary>
        /// <value>The District to which this School Bus is affliated.</value>
        [DataMember(Name="District")]
        [MetaDataExtension (Description = "The District to which this School Bus is affliated.")]
        public District District { get; set; }

        /// <summary>
        /// The set of contacts related to the School Bus Owner.
        /// </summary>
        /// <value>The set of contacts related to the School Bus Owner.</value>
        [DataMember(Name="contacts")]
        [MetaDataExtension (Description = "The set of contacts related to the School Bus Owner.")]
        public List<Contact> Contacts { get; set; }

        /// <summary>
        /// The set of notes about the school bus owner entered by users.
        /// </summary>
        /// <value>The set of notes about the school bus owner entered by users.</value>
        [DataMember(Name="notes")]
        [MetaDataExtension (Description = "The set of notes about the school bus owner entered by users.")]
        public List<Note> Notes { get; set; }

        /// <summary>
        /// The set of attachments about the school bus owner uploaded by the users.
        /// </summary>
        /// <value>The set of attachments about the school bus owner uploaded by the users.</value>
        [DataMember(Name="attachments")]
        [MetaDataExtension (Description = "The set of attachments about the school bus owner uploaded by the users.")]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// The history of updates made to the School Bus Owner data.
        /// </summary>
        /// <value>The history of updates made to the School Bus Owner data.</value>
        [DataMember(Name="history")]
        [MetaDataExtension (Description = "The history of updates made to the School Bus Owner data.")]
        public List<History> History { get; set; }

        /// <summary>
        /// The next inspection date associated with this owner
        /// </summary>
        /// <value>The next inspection date associated with this owner</value>
        [DataMember(Name="nextInspectionDate")]
        [MetaDataExtension (Description = "The next inspection date associated with this owner")]
        public DateTime? NextInspectionDate { get; set; }

        /// <summary>
        /// The number of buses for which this owner is associated with
        /// </summary>
        /// <value>The number of buses for which this owner is associated with</value>
        [DataMember(Name="numberOfBuses")]
        [MetaDataExtension (Description = "The number of buses for which this owner is associated with")]
        public int? NumberOfBuses { get; set; }

        /// <summary>
        /// Type Code for the Next InspectionType.  Null if there are no next inspections.
        /// </summary>
        /// <value>Type Code for the Next InspectionType.  Null if there are no next inspections.</value>
        [DataMember(Name="nextInspectionTypeCode")]
        [MetaDataExtension (Description = "Type Code for the Next InspectionType.  Null if there are no next inspections.")]
        public string NextInspectionTypeCode { get; set; }
    }
}
