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
    public partial class UserFavorite :  IEquatable<UserFavorite>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserFavorite" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="JsonData">Saved search.</param>
        /// <param name="Name">Context Name.</param>
        public UserFavorite(int Id, string JsonData = null, string Name = null)
        {
            
            this.Id = Id;            
            this.JsonData = JsonData;
            this.Name = Name;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name="Id")]
        [MetaDataExtension (Description = "Primary Key")]        
        public int Id { get; set; }

        /// <summary>
        /// Saved search
        /// </summary>
        /// <value>Saved search</value>
        [DataMember(Name="JsonData")]
        [MetaDataExtension (Description = "Saved search")]        
        public string JsonData { get; set; }

        /// <summary>
        /// Context Name
        /// </summary>
        /// <value>Context Name</value>
        [DataMember(Name="Name")]
        [MetaDataExtension (Description = "Context Name")]        
        public string Name { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserFavorite {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  JsonData: ").Append(JsonData).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return Equals((UserFavorite)obj);
        }

        /// <summary>
        /// Returns true if UserFavorite instances are equal
        /// </summary>
        /// <param name="other">Instance of UserFavorite to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserFavorite other)
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
                    this.JsonData == other.JsonData ||
                    this.JsonData != null &&
                    this.JsonData.Equals(other.JsonData)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
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
                    if (this.JsonData != null)
                    { 
                        hash = hash * 59 + this.JsonData.GetHashCode();
                    }
                    if (this.Name != null)
                    { 
                        hash = hash * 59 + this.Name.GetHashCode();
                    }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(UserFavorite left, UserFavorite right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserFavorite left, UserFavorite right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
