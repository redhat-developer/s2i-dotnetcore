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

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// User specific settings for a specific location in the UI. The location and saved settings are internally defined by the UI.
    /// </summary>
    public partial class UserFavourite : IEquatable<UserFavourite>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public UserFavourite()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserFavourite" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="Name">The user-defined name for the recorded settings. Allows the user to save different groups of settings and access each one easily when needed..</param>
        /// <param name="Value">The settings saved by the user. In general, a UI defined chunk of json that stores the settings in place when the user created the favourite..</param>
        /// <param name="IsDefault">True if this Favourite is the default for this Context Type. On first access to a context in a session the default favourite for the context it is invoked. If there is no default favourite, a system-wide default is invoked. On return to the context within a session, the last parameters used are reapplied..</param>
        /// <param name="FavouriteContextType">FavouriteContextType.</param>
        public UserFavourite(int Id, string Name = null, string Value = null, bool? IsDefault = null, FavouriteContextType FavouriteContextType = null)
        {
            
            this.Id = Id;
            this.Name = Name;
            this.Value = Value;
            this.IsDefault = IsDefault;
            this.FavouriteContextType = FavouriteContextType;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }

        /// <summary>
        /// The user-defined name for the recorded settings. Allows the user to save different groups of settings and access each one easily when needed.
        /// </summary>
        /// <value>The user-defined name for the recorded settings. Allows the user to save different groups of settings and access each one easily when needed.</value>
        [MetaDataExtension (Description = "The user-defined name for the recorded settings. Allows the user to save different groups of settings and access each one easily when needed.")]
        public string Name { get; set; }

        /// <summary>
        /// The settings saved by the user. In general, a UI defined chunk of json that stores the settings in place when the user created the favourite.
        /// </summary>
        /// <value>The settings saved by the user. In general, a UI defined chunk of json that stores the settings in place when the user created the favourite.</value>
        [MetaDataExtension (Description = "The settings saved by the user. In general, a UI defined chunk of json that stores the settings in place when the user created the favourite.")]
        public string Value { get; set; }

        /// <summary>
        /// True if this Favourite is the default for this Context Type. On first access to a context in a session the default favourite for the context it is invoked. If there is no default favourite, a system-wide default is invoked. On return to the context within a session, the last parameters used are reapplied.
        /// </summary>
        /// <value>True if this Favourite is the default for this Context Type. On first access to a context in a session the default favourite for the context it is invoked. If there is no default favourite, a system-wide default is invoked. On return to the context within a session, the last parameters used are reapplied.</value>
        [MetaDataExtension (Description = "True if this Favourite is the default for this Context Type. On first access to a context in a session the default favourite for the context it is invoked. If there is no default favourite, a system-wide default is invoked. On return to the context within a session, the last parameters used are reapplied.")]
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Gets or Sets FavouriteContextType
        /// </summary>
        public FavouriteContextType FavouriteContextType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserFavourite {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  IsDefault: ").Append(IsDefault).Append("\n");
            sb.Append("  FavouriteContextType: ").Append(FavouriteContextType).Append("\n");
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
            return Equals((UserFavourite)obj);
        }

        /// <summary>
        /// Returns true if UserFavourite instances are equal
        /// </summary>
        /// <param name="other">Instance of UserFavourite to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserFavourite other)
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
                    this.FavouriteContextType == other.FavouriteContextType ||
                    this.FavouriteContextType != null &&
                    this.FavouriteContextType.Equals(other.FavouriteContextType)
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
                if (this.FavouriteContextType != null)
                {
                    hash = hash * 59 + this.FavouriteContextType.GetHashCode();
                }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(UserFavourite left, UserFavourite right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserFavourite left, UserFavourite right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
