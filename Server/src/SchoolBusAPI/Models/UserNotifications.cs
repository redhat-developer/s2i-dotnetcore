/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
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

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class UserNotifications :  IEquatable<UserNotifications>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserNotifications" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="BusNotification">BusNotification.</param>
        /// <param name="User">User.</param>
        public UserNotifications(int Id, BusNotification BusNotification = null, User User = null)
        {
            
            this.Id = Id;            
            this.BusNotification = BusNotification;
            this.User = User;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name="id")]
        [MetaDataExtension (Description = "Primary Key")]        
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets BusNotification
        /// </summary>
        [DataMember(Name="BusNotification")]
                
        public BusNotification BusNotification { get; set; }

        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [DataMember(Name="User")]
                
        public User User { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserNotifications {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  BusNotification: ").Append(BusNotification).Append("\n");
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
            return Equals((UserNotifications)obj);
        }

        /// <summary>
        /// Returns true if UserNotifications instances are equal
        /// </summary>
        /// <param name="other">Instance of UserNotifications to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserNotifications other)
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
                    this.BusNotification == other.BusNotification ||
                    this.BusNotification != null &&
                    this.BusNotification.Equals(other.BusNotification)
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
                    if (this.Id != null)
                    { 
                        hash = hash * 59 + this.Id.GetHashCode();
                    }
                    if (this.BusNotification != null)
                    { 
                        hash = hash * 59 + this.BusNotification.GetHashCode();
                    }
                    if (this.User != null)
                    { 
                        hash = hash * 59 + this.User.GetHashCode();
                    }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(UserNotifications left, UserNotifications right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserNotifications left, UserNotifications right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
