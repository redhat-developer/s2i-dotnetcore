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

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// 
    /// </summary>



    public partial class NotificationEvent : IEquatable<NotificationEvent>
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
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="EventTime">EventTime.</param>
        /// <param name="EventTypeCode">EventTypeCode.</param>
        /// <param name="EventSubTypeCode">EventSubTypeCode.</param>
        /// <param name="Notes">Notes.</param>
        /// <param name="NotificationGenerated">NotificationGenerated.</param>
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
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }

        

        /// <summary>
        /// Gets or Sets EventTime
        /// </summary>
        public DateTime? EventTime { get; set; }

        

        /// <summary>
        /// Gets or Sets EventTypeCode
        /// </summary>
        public string EventTypeCode { get; set; }

        

        /// <summary>
        /// Gets or Sets EventSubTypeCode
        /// </summary>
        public string EventSubTypeCode { get; set; }

        

        /// <summary>
        /// Gets or Sets Notes
        /// </summary>
        public string Notes { get; set; }

        

        /// <summary>
        /// Gets or Sets NotificationGenerated
        /// </summary>
        public bool? NotificationGenerated { get; set; }

        

        /// <summary>
        /// Gets or Sets SchoolBus
        /// </summary>
        public SchoolBus SchoolBus { get; set; }

                
        [ForeignKey("SchoolBus")]
        public int SchoolBusRefId { get; set; }
        

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
                   
                hash = hash * 59 + this.Id.GetHashCode();
                
                
                if (this.EventTime != null)
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

        public static bool operator ==(NotificationEvent left, NotificationEvent right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NotificationEvent left, NotificationEvent right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
