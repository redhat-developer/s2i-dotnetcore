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
    public partial class UserFavouriteViewModel
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id")]
        public int? Id { get; set; }

        /// <summary>
        /// Context Name
        /// </summary>
        /// <value>Context Name</value>
        [DataMember(Name="name")]
        [MetaDataExtension (Description = "Context Name")]
        public string Name { get; set; }

        /// <summary>
        /// Saved search
        /// </summary>
        /// <value>Saved search</value>
        [DataMember(Name="value")]
        [MetaDataExtension (Description = "Saved search")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets IsDefault
        /// </summary>
        [DataMember(Name="isDefault")]
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Type of favourite
        /// </summary>
        /// <value>Type of favourite</value>
        [DataMember(Name="type")]
        [MetaDataExtension (Description = "Type of favourite")]
        public string Type { get; set; }
    }
}
