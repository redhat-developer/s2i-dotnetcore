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
using SchoolBusAPI.Models;

namespace SchoolBusAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class NotificationViewModel
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets EventId
        /// </summary>
        [DataMember(Name="eventId")]
        public int? EventId { get; set; }

        /// <summary>
        /// Gets or Sets Event2Id
        /// </summary>
        [DataMember(Name="event2Id")]
        public int? Event2Id { get; set; }

        /// <summary>
        /// Gets or Sets HasBeenViewed
        /// </summary>
        [DataMember(Name="hasBeenViewed")]
        public bool? HasBeenViewed { get; set; }

        /// <summary>
        /// Gets or Sets IsWatchNotification
        /// </summary>
        [DataMember(Name="isWatchNotification")]
        public bool? IsWatchNotification { get; set; }

        /// <summary>
        /// Gets or Sets IsExpired
        /// </summary>
        [DataMember(Name="isExpired")]
        public bool? IsExpired { get; set; }

        /// <summary>
        /// Gets or Sets IsAllDay
        /// </summary>
        [DataMember(Name="isAllDay")]
        public bool? IsAllDay { get; set; }

        /// <summary>
        /// Gets or Sets PriorityCode
        /// </summary>
        [DataMember(Name="priorityCode")]
        public string PriorityCode { get; set; }

        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [DataMember(Name="userId")]
        public int? UserId { get; set; }
    }
}
