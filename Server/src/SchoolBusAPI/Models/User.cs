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
    public partial class User :  IEquatable<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="Email">Email address.</param>
        /// <param name="SmUserid">Security Manager User ID.</param>
        /// <param name="GivenName">Last Name.</param>
        public User(int Id, string Email = null, string SmUserid = null, string GivenName = null)
        {
            
            this.Id = Id;            
            this.Email = Email;
            this.SmUserid = SmUserid;
            this.GivenName = GivenName;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name="id")]
        [MetaDataExtension (Description = "Primary Key")]        
        public int Id { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        /// <value>Email address</value>
        [DataMember(Name="Email")]
        [MetaDataExtension (Description = "Email address")]        
        public string Email { get; set; }

        /// <summary>
        /// Security Manager User ID
        /// </summary>
        /// <value>Security Manager User ID</value>
        [DataMember(Name="SmUserid")]
        [MetaDataExtension (Description = "Security Manager User ID")]        
        public string SmUserid { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        /// <value>Last Name</value>
        [DataMember(Name="GivenName")]
        [MetaDataExtension (Description = "Last Name")]        
        public string GivenName { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  SmUserid: ").Append(SmUserid).Append("\n");
            sb.Append("  GivenName: ").Append(GivenName).Append("\n");
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
            return Equals((User)obj);
        }

        /// <summary>
        /// Returns true if User instances are equal
        /// </summary>
        /// <param name="other">Instance of User to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(User other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return 
                (
                    this.Id == other.Id &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Email == other.Email ||
                    this.Email != null &&
                    this.Email.Equals(other.Email)
                ) && 
                (
                    this.SmUserid == other.SmUserid ||
                    this.SmUserid != null &&
                    this.SmUserid.Equals(other.SmUserid)
                ) && 
                (
                    this.GivenName == other.GivenName ||
                    this.GivenName != null &&
                    this.GivenName.Equals(other.GivenName)
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
                    if (this.Email != null)
                    { 
                        hash = hash * 59 + this.Email.GetHashCode();
                    }
                    if (this.SmUserid != null)
                    { 
                        hash = hash * 59 + this.SmUserid.GetHashCode();
                    }
                    if (this.GivenName != null)
                    { 
                        hash = hash * 59 + this.GivenName.GetHashCode();
                    }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(User left, User right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(User left, User right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
