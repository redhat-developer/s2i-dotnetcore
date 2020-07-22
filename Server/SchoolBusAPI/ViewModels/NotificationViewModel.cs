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
    public partial class NotificationViewModel : IEquatable<NotificationViewModel>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public NotificationViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationViewModel" /> class.
        /// </summary>
        /// <param name="Id">Id.</param>
        /// <param name="EventId">EventId.</param>
        /// <param name="Event2Id">Event2Id.</param>
        /// <param name="HasBeenViewed">HasBeenViewed.</param>
        /// <param name="IsWatchNotification">IsWatchNotification.</param>
        /// <param name="IsExpired">IsExpired.</param>
        /// <param name="IsAllDay">IsAllDay.</param>
        /// <param name="PriorityCode">PriorityCode.</param>
        /// <param name="UserId">UserId.</param>
        public NotificationViewModel(int? Id = null, int? EventId = null, int? Event2Id = null, bool? HasBeenViewed = null, bool? IsWatchNotification = null, bool? IsExpired = null, bool? IsAllDay = null, string PriorityCode = null, int? UserId = null)
        {               this.Id = Id;
            this.EventId = EventId;
            this.Event2Id = Event2Id;
            this.HasBeenViewed = HasBeenViewed;
            this.IsWatchNotification = IsWatchNotification;
            this.IsExpired = IsExpired;
            this.IsAllDay = IsAllDay;
            this.PriorityCode = PriorityCode;
            this.UserId = UserId;
        }

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

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NotificationViewModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  EventId: ").Append(EventId).Append("\n");
            sb.Append("  Event2Id: ").Append(Event2Id).Append("\n");
            sb.Append("  HasBeenViewed: ").Append(HasBeenViewed).Append("\n");
            sb.Append("  IsWatchNotification: ").Append(IsWatchNotification).Append("\n");
            sb.Append("  IsExpired: ").Append(IsExpired).Append("\n");
            sb.Append("  IsAllDay: ").Append(IsAllDay).Append("\n");
            sb.Append("  PriorityCode: ").Append(PriorityCode).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
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
            return Equals((NotificationViewModel)obj);
        }

        /// <summary>
        /// Returns true if NotificationViewModel instances are equal
        /// </summary>
        /// <param name="other">Instance of NotificationViewModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NotificationViewModel other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.EventId == other.EventId ||
                    this.EventId != null &&
                    this.EventId.Equals(other.EventId)
                ) &&                 
                (
                    this.Event2Id == other.Event2Id ||
                    this.Event2Id != null &&
                    this.Event2Id.Equals(other.Event2Id)
                ) &&                 
                (
                    this.HasBeenViewed == other.HasBeenViewed ||
                    this.HasBeenViewed != null &&
                    this.HasBeenViewed.Equals(other.HasBeenViewed)
                ) &&                 
                (
                    this.IsWatchNotification == other.IsWatchNotification ||
                    this.IsWatchNotification != null &&
                    this.IsWatchNotification.Equals(other.IsWatchNotification)
                ) &&                 
                (
                    this.IsExpired == other.IsExpired ||
                    this.IsExpired != null &&
                    this.IsExpired.Equals(other.IsExpired)
                ) &&                 
                (
                    this.IsAllDay == other.IsAllDay ||
                    this.IsAllDay != null &&
                    this.IsAllDay.Equals(other.IsAllDay)
                ) &&                 
                (
                    this.PriorityCode == other.PriorityCode ||
                    this.PriorityCode != null &&
                    this.PriorityCode.Equals(other.PriorityCode)
                ) &&                 
                (
                    this.UserId == other.UserId ||
                    this.UserId != null &&
                    this.UserId.Equals(other.UserId)
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
                if (this.Id != null)
                {
                    hash = hash * 59 + this.Id.GetHashCode();
                }                
                                if (this.EventId != null)
                {
                    hash = hash * 59 + this.EventId.GetHashCode();
                }                
                                if (this.Event2Id != null)
                {
                    hash = hash * 59 + this.Event2Id.GetHashCode();
                }                
                                if (this.HasBeenViewed != null)
                {
                    hash = hash * 59 + this.HasBeenViewed.GetHashCode();
                }                
                                if (this.IsWatchNotification != null)
                {
                    hash = hash * 59 + this.IsWatchNotification.GetHashCode();
                }                
                                if (this.IsExpired != null)
                {
                    hash = hash * 59 + this.IsExpired.GetHashCode();
                }                
                                if (this.IsAllDay != null)
                {
                    hash = hash * 59 + this.IsAllDay.GetHashCode();
                }                
                                if (this.PriorityCode != null)
                {
                    hash = hash * 59 + this.PriorityCode.GetHashCode();
                }                
                                if (this.UserId != null)
                {
                    hash = hash * 59 + this.UserId.GetHashCode();
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
        public static bool operator ==(NotificationViewModel left, NotificationViewModel right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(NotificationViewModel left, NotificationViewModel right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
