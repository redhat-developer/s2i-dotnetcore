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
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using SchoolBusAPI.Models;

namespace SchoolBusAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class HistoryViewModel
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public HistoryViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryViewModel" /> class.
        /// </summary>
        /// <param name="Id">A system-generated unique identifier for a History (required).</param>
        /// <param name="HistoryText">The text of the history entry tracked against the related entity..</param>
        /// <param name="LastUpdateUserid">Audit information - SM User Id for the User who most recently updated the record..</param>
        /// <param name="LastUpdateTimestamp">Audit information - Timestamp for record modification.</param>
        /// <param name="AffectedEntityId">The primary key of the affected record.</param>
        public HistoryViewModel(int Id, string HistoryText = null, string LastUpdateUserid = null, DateTime? LastUpdateTimestamp = null, int? AffectedEntityId = null)
        {   
            this.Id = Id;
            this.HistoryText = HistoryText;
            this.LastUpdateUserid = LastUpdateUserid;
            this.LastUpdateTimestamp = LastUpdateTimestamp;
            this.AffectedEntityId = AffectedEntityId;
        }

        /// <summary>
        /// A system-generated unique identifier for a History
        /// </summary>
        /// <value>A system-generated unique identifier for a History</value>
        [DataMember(Name="id")]
        [MetaDataExtension (Description = "A system-generated unique identifier for a History")]
        public int Id { get; set; }

        /// <summary>
        /// The text of the history entry tracked against the related entity.
        /// </summary>
        /// <value>The text of the history entry tracked against the related entity.</value>
        [DataMember(Name="historyText")]
        [MetaDataExtension (Description = "The text of the history entry tracked against the related entity.")]
        public string HistoryText { get; set; }

        /// <summary>
        /// Audit information - SM User Id for the User who most recently updated the record.
        /// </summary>
        /// <value>Audit information - SM User Id for the User who most recently updated the record.</value>
        [DataMember(Name="lastUpdateUserid")]
        [MetaDataExtension (Description = "Audit information - SM User Id for the User who most recently updated the record.")]
        public string LastUpdateUserid { get; set; }

        [DataMember(Name = "userName")]
        public string UserName { get; set; }

        /// <summary>
        /// Audit information - Timestamp for record modification
        /// </summary>
        /// <value>Audit information - Timestamp for record modification</value>
        [DataMember(Name="lastUpdateTimestamp")]
        [MetaDataExtension (Description = "Audit information - Timestamp for record modification")]
        public DateTime? LastUpdateTimestamp { get; set; }

        /// <summary>
        /// The primary key of the affected record
        /// </summary>
        /// <value>The primary key of the affected record</value>
        [DataMember(Name="affectedEntityId")]
        [MetaDataExtension (Description = "The primary key of the affected record")]
        public int? AffectedEntityId { get; set; }

    }
}
