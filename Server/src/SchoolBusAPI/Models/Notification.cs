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
    /// 
    /// </summary>

    public partial class Notification : IEquatable<Notification>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public Notification()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="Event">Event.</param>
        /// <param name="Event2">Event2.</param>
        /// <param name="HasBeenViewed">HasBeenViewed.</param>
        /// <param name="IsWatchNotification">IsWatchNotification.</param>
        /// <param name="IsExpired">IsExpired.</param>
        /// <param name="IsAllDay">IsAllDay.</param>
        /// <param name="PriorityCode">PriorityCode.</param>
        /// <param name="User">User.</param>
        public Notification(int Id, NotificationEvent Event = null, NotificationEvent Event2 = null, bool? HasBeenViewed = null, bool? IsWatchNotification = null, bool? IsExpired = null, bool? IsAllDay = null, string PriorityCode = null, User User = null)
        {   
            this.Id = Id;
            this.Event = Event;
            this.Event2 = Event2;
            this.HasBeenViewed = HasBeenViewed;
            this.IsWatchNotification = IsWatchNotification;
            this.IsExpired = IsExpired;
            this.IsAllDay = IsAllDay;
            this.PriorityCode = PriorityCode;
            this.User = User;
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or Sets Event
        /// </summary>
        public NotificationEvent Event { get; set; }
        
        /// <summary>
        /// Foreign key for Event 
        /// </summary>       
        [ForeignKey("Event")]
        public int? EventRefId { get; set; }
        
        /// <summary>
        /// Gets or Sets Event2
        /// </summary>
        public NotificationEvent Event2 { get; set; }
        
        /// <summary>
        /// Foreign key for Event2 
        /// </summary>       
        [ForeignKey("Event2")]
        public int? Event2RefId { get; set; }
        
        /// <summary>
        /// Gets or Sets HasBeenViewed
        /// </summary>
        public bool? HasBeenViewed { get; set; }
        
        /// <summary>
        /// Gets or Sets IsWatchNotification
        /// </summary>
        public bool? IsWatchNotification { get; set; }
        
        /// <summary>
        /// Gets or Sets IsExpired
        /// </summary>
        public bool? IsExpired { get; set; }
        
        /// <summary>
        /// Gets or Sets IsAllDay
        /// </summary>
        public bool? IsAllDay { get; set; }
        
        /// <summary>
        /// Gets or Sets PriorityCode
        /// </summary>
        [MaxLength(255)]
        
        public string PriorityCode { get; set; }
        
        /// <summary>
        /// Gets or Sets User
        /// </summary>
        public User User { get; set; }
        
        /// <summary>
        /// Foreign key for User 
        /// </summary>       
        [ForeignKey("User")]
        public int? UserRefId { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Notification {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Event: ").Append(Event).Append("\n");
            sb.Append("  Event2: ").Append(Event2).Append("\n");
            sb.Append("  HasBeenViewed: ").Append(HasBeenViewed).Append("\n");
            sb.Append("  IsWatchNotification: ").Append(IsWatchNotification).Append("\n");
            sb.Append("  IsExpired: ").Append(IsExpired).Append("\n");
            sb.Append("  IsAllDay: ").Append(IsAllDay).Append("\n");
            sb.Append("  PriorityCode: ").Append(PriorityCode).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
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
            return Equals((Notification)obj);
        }

        /// <summary>
        /// Returns true if Notification instances are equal
        /// </summary>
        /// <param name="other">Instance of Notification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Notification other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.Event == other.Event ||
                    this.Event != null &&
                    this.Event.Equals(other.Event)
                ) &&                 
                (
                    this.Event2 == other.Event2 ||
                    this.Event2 != null &&
                    this.Event2.Equals(other.Event2)
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
                    this.User == other.User ||
                    this.User != null &&
                    this.User.Equals(other.User)
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
                if (this.Event != null)
                {
                    hash = hash * 59 + this.Event.GetHashCode();
                }                   
                if (this.Event2 != null)
                {
                    hash = hash * 59 + this.Event2.GetHashCode();
                }                if (this.HasBeenViewed != null)
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
                                   
                if (this.User != null)
                {
                    hash = hash * 59 + this.User.GetHashCode();
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
        public static bool operator ==(Notification left, Notification right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Notification left, Notification right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
