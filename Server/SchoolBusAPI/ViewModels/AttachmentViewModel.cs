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
    public partial class AttachmentViewModel
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name="id")]
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// Filename as passed by the user uploading the file
        /// </summary>
        /// <value>Filename as passed by the user uploading the file</value>
        [DataMember(Name="fileName")]
        [MetaDataExtension (Description = "Filename as passed by the user uploading the file")]
        public string FileName { get; set; }

        /// <summary>
        /// A note about the attachment,  optionally maintained by the user.
        /// </summary>
        /// <value>A note about the attachment,  optionally maintained by the user.</value>
        [DataMember(Name="description")]
        [MetaDataExtension (Description = "A note about the attachment,  optionally maintained by the user.")]
        public string Description { get; set; }

        /// <summary>
        /// Type of attachment
        /// </summary>
        /// <value>Type of attachment</value>
        [DataMember(Name="type")]
        [MetaDataExtension (Description = "Type of attachment")]
        public string Type { get; set; }
    }
}
