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

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// Notifications associated about changes (mostly from CCW data) to information related to a specific school bus - e.g. change of owner at ICBC, change in NSC client rating, etc.
    /// </summary>
        [MetaDataExtension (Description = "Notifications associated about changes (mostly from CCW data) to information related to a specific school bus - e.g. change of owner at ICBC, change in NSC client rating, etc.")]

    public partial class NotificationEvent : AuditableEntity, IEquatable<NotificationEvent>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public NotificationEvent()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationEvent" /> class.
        /// </summary>
        /// <param name="Id">A system-generated unique identifier for a NotificationEvent (required).</param>
        /// <param name="EventTime">The date&amp;#x2F;time of the creation of the event that triggered the creation of the notification..</param>
        /// <param name="EventTypeCode">A categorization of the event for which the notification was created. The categories will be defined over time in code based on the requirements of the business. An example might be &amp;quot;ICBCOwnerNameChange&amp;quot; for when a change in the CCWData ICBC Owner Name field is changed..</param>
        /// <param name="EventSubTypeCode">A further categorization of the event for which the notification was created..</param>
        /// <param name="Notes">An assembled text string about the event that triggered the notification. Includes both static text and data about the notification. User Interface code will be used (based on the eventTypeCode - category) to assemble a dynamic string of information about the event - potentially including links to other relevant data - such as link to the School Bus detail screen..</param>
        /// <param name="NotificationGenerated">TO BE REMOVED.</param>
        /// <param name="SchoolBus">SchoolBus.</param>
        public NotificationEvent(int Id, DateTime? EventTime = null, string EventTypeCode = null, string EventSubTypeCode = null, string Notes = null, bool? NotificationGenerated = null, SchoolBus SchoolBus = null)
        {   
            this.Id = Id;
            this.EventTime = EventTime;
            this.EventTypeCode = EventTypeCode;
            this.EventSubTypeCode = EventSubTypeCode;
            this.Notes = Notes;
            this.NotificationGenerated = NotificationGenerated;
            this.SchoolBus = SchoolBus;
        }

        /// <summary>
        /// A system-generated unique identifier for a NotificationEvent
        /// </summary>
        /// <value>A system-generated unique identifier for a NotificationEvent</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for a NotificationEvent")]
        public int Id { get; set; }
        
        /// <summary>
        /// The date&#x2F;time of the creation of the event that triggered the creation of the notification.
        /// </summary>
        /// <value>The date&#x2F;time of the creation of the event that triggered the creation of the notification.</value>
        [MetaDataExtension (Description = "The date&#x2F;time of the creation of the event that triggered the creation of the notification.")]
        public DateTime? EventTime { get; set; }
        
        /// <summary>
        /// A categorization of the event for which the notification was created. The categories will be defined over time in code based on the requirements of the business. An example might be &quot;ICBCOwnerNameChange&quot; for when a change in the CCWData ICBC Owner Name field is changed.
        /// </summary>
        /// <value>A categorization of the event for which the notification was created. The categories will be defined over time in code based on the requirements of the business. An example might be &quot;ICBCOwnerNameChange&quot; for when a change in the CCWData ICBC Owner Name field is changed.</value>
        [MetaDataExtension (Description = "A categorization of the event for which the notification was created. The categories will be defined over time in code based on the requirements of the business. An example might be &quot;ICBCOwnerNameChange&quot; for when a change in the CCWData ICBC Owner Name field is changed.")]
        [MaxLength(255)]
        
        public string EventTypeCode { get; set; }
        
        /// <summary>
        /// A further categorization of the event for which the notification was created.
        /// </summary>
        /// <value>A further categorization of the event for which the notification was created.</value>
        [MetaDataExtension (Description = "A further categorization of the event for which the notification was created.")]
        [MaxLength(255)]
        
        public string EventSubTypeCode { get; set; }
        
        /// <summary>
        /// An assembled text string about the event that triggered the notification. Includes both static text and data about the notification. User Interface code will be used (based on the eventTypeCode - category) to assemble a dynamic string of information about the event - potentially including links to other relevant data - such as link to the School Bus detail screen.
        /// </summary>
        /// <value>An assembled text string about the event that triggered the notification. Includes both static text and data about the notification. User Interface code will be used (based on the eventTypeCode - category) to assemble a dynamic string of information about the event - potentially including links to other relevant data - such as link to the School Bus detail screen.</value>
        [MetaDataExtension (Description = "An assembled text string about the event that triggered the notification. Includes both static text and data about the notification. User Interface code will be used (based on the eventTypeCode - category) to assemble a dynamic string of information about the event - potentially including links to other relevant data - such as link to the School Bus detail screen.")]
        [MaxLength(2048)]
        
        public string Notes { get; set; }
        
        /// <summary>
        /// TO BE REMOVED
        /// </summary>
        /// <value>TO BE REMOVED</value>
        [MetaDataExtension (Description = "TO BE REMOVED")]
        public bool? NotificationGenerated { get; set; }
        
        /// <summary>
        /// Gets or Sets SchoolBus
        /// </summary>
        public SchoolBus SchoolBus { get; set; }
        
        /// <summary>
        /// Foreign key for SchoolBus 
        /// </summary>   
        [ForeignKey("SchoolBus")]
		[JsonIgnore]
        public int? SchoolBusId { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NotificationEvent {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  EventTime: ").Append(EventTime).Append("\n");
            sb.Append("  EventTypeCode: ").Append(EventTypeCode).Append("\n");
            sb.Append("  EventSubTypeCode: ").Append(EventSubTypeCode).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  NotificationGenerated: ").Append(NotificationGenerated).Append("\n");
            sb.Append("  SchoolBus: ").Append(SchoolBus).Append("\n");
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
            return Equals((NotificationEvent)obj);
        }

        /// <summary>
        /// Returns true if NotificationEvent instances are equal
        /// </summary>
        /// <param name="other">Instance of NotificationEvent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NotificationEvent other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.EventTime == other.EventTime ||
                    this.EventTime != null &&
                    this.EventTime.Equals(other.EventTime)
                ) &&                 
                (
                    this.EventTypeCode == other.EventTypeCode ||
                    this.EventTypeCode != null &&
                    this.EventTypeCode.Equals(other.EventTypeCode)
                ) &&                 
                (
                    this.EventSubTypeCode == other.EventSubTypeCode ||
                    this.EventSubTypeCode != null &&
                    this.EventSubTypeCode.Equals(other.EventSubTypeCode)
                ) &&                 
                (
                    this.Notes == other.Notes ||
                    this.Notes != null &&
                    this.Notes.Equals(other.Notes)
                ) &&                 
                (
                    this.NotificationGenerated == other.NotificationGenerated ||
                    this.NotificationGenerated != null &&
                    this.NotificationGenerated.Equals(other.NotificationGenerated)
                ) &&                 
                (
                    this.SchoolBus == other.SchoolBus ||
                    this.SchoolBus != null &&
                    this.SchoolBus.Equals(other.SchoolBus)
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
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.EventTime != null)
                {
                    hash = hash * 59 + this.EventTime.GetHashCode();
                }                
                                if (this.EventTypeCode != null)
                {
                    hash = hash * 59 + this.EventTypeCode.GetHashCode();
                }                
                                if (this.EventSubTypeCode != null)
                {
                    hash = hash * 59 + this.EventSubTypeCode.GetHashCode();
                }                
                                if (this.Notes != null)
                {
                    hash = hash * 59 + this.Notes.GetHashCode();
                }                
                                if (this.NotificationGenerated != null)
                {
                    hash = hash * 59 + this.NotificationGenerated.GetHashCode();
                }                
                                   
                if (this.SchoolBus != null)
                {
                    hash = hash * 59 + this.SchoolBus.GetHashCode();
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
        public static bool operator ==(NotificationEvent left, NotificationEvent right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(NotificationEvent left, NotificationEvent right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
