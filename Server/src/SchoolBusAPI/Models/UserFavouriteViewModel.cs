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
    public partial class UserFavouriteViewModel : IEquatable<UserFavouriteViewModel>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public UserFavouriteViewModel()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserFavouriteViewModel" /> class.
        /// </summary>
        /// <param name="Id">Id.</param>
        /// <param name="Name">Context Name.</param>
        /// <param name="Value">Saved search.</param>
        /// <param name="IsDefault">IsDefault.</param>
        /// <param name="FavouriteContextTypeId">FavouriteContextTypeId.</param>
        public UserFavouriteViewModel(int? Id = null, string Name = null, string Value = null, bool? IsDefault = null, int? FavouriteContextTypeId = null)
        {
            this.Id = Id;
            this.Name = Name;
            this.Value = Value;
            this.IsDefault = IsDefault;
            this.FavouriteContextTypeId = FavouriteContextTypeId;
            
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Context Name
        /// </summary>
        /// <value>Context Name</value>
        [MetaDataExtension (Description = "Context Name")]
        public string Name { get; set; }

        /// <summary>
        /// Saved search
        /// </summary>
        /// <value>Saved search</value>
        [MetaDataExtension (Description = "Saved search")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets IsDefault
        /// </summary>
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Gets or Sets FavouriteContextTypeId
        /// </summary>
        public int? FavouriteContextTypeId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserFavouriteViewModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  IsDefault: ").Append(IsDefault).Append("\n");
            sb.Append("  FavouriteContextTypeId: ").Append(FavouriteContextTypeId).Append("\n");
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
            return Equals((UserFavouriteViewModel)obj);
        }

        /// <summary>
        /// Returns true if UserFavouriteViewModel instances are equal
        /// </summary>
        /// <param name="other">Instance of UserFavouriteViewModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserFavouriteViewModel other)
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
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Value == other.Value ||
                    this.Value != null &&
                    this.Value.Equals(other.Value)
                ) && 
                (
                    this.IsDefault == other.IsDefault ||
                    this.IsDefault != null &&
                    this.IsDefault.Equals(other.IsDefault)
                ) && 
                (
                    this.FavouriteContextTypeId == other.FavouriteContextTypeId ||
                    this.FavouriteContextTypeId != null &&
                    this.FavouriteContextTypeId.Equals(other.FavouriteContextTypeId)
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
                if (this.Name != null)
                {
                    hash = hash * 59 + this.Name.GetHashCode();
                }
                if (this.Value != null)
                {
                    hash = hash * 59 + this.Value.GetHashCode();
                }
                if (this.IsDefault != null)
                {
                    hash = hash * 59 + this.IsDefault.GetHashCode();
                }
                if (this.FavouriteContextTypeId != null)
                {
                    hash = hash * 59 + this.FavouriteContextTypeId.GetHashCode();
                }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(UserFavouriteViewModel left, UserFavouriteViewModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserFavouriteViewModel left, UserFavouriteViewModel right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
