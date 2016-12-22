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
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class SchoolBusOwner :  IEquatable<SchoolBusOwner>
    {

        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public SchoolBusOwner()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolBusOwner" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="Name">Name.</param>
        /// <param name="IsActive">IsActive.</param>
        /// <param name="DateCreated">DateCreated.</param>
        /// <param name="PrimaryContact">PrimaryContact.</param>
        /// <param name="LocalArea">LocalArea.</param>
        /// <param name="City">City.</param>
        public SchoolBusOwner(int Id, string Name = null, bool? IsActive = null, DateTime? DateCreated = null, SchoolBusOwnerContact PrimaryContact = null, LocalArea LocalArea = null, City City = null)
        {
            
            this.Id = Id;            
            this.Name = Name;
            this.IsActive = IsActive;
            this.DateCreated = DateCreated;
            this.PrimaryContact = PrimaryContact;
            this.LocalArea = LocalArea;
            this.City = City;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [DataMember(Name="id")]
        [MetaDataExtension (Description = "Primary Key")]        
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="Name")]
                
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets IsActive
        /// </summary>
        [DataMember(Name="IsActive")]
                
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or Sets DateCreated
        /// </summary>
        [DataMember(Name="DateCreated")]
                
        public DateTime? DateCreated { get; set; }


        [DataMember(Name = "PrimaryContact")]
        public SchoolBusOwnerContact PrimaryContact { get; set; }


        [ForeignKey("PrimaryContact")]
        //Foreign key for PrimaryContact
        public int? PrimaryContactRefId { get; set; }

        /// <summary>
        /// Gets or Sets PrimaryContact
        /// </summary>
        //[DataMember(Name="PrimaryContact")]

        /// <summary>
        /// Gets or Sets LocalArea
        /// </summary>
        [DataMember(Name="LocalArea")]
                
        public LocalArea LocalArea { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        [DataMember(Name="City")]
                
        public City City { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchoolBusOwner {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  IsActive: ").Append(IsActive).Append("\n");
            sb.Append("  DateCreated: ").Append(DateCreated).Append("\n");
            sb.Append("  PrimaryContact: ").Append(PrimaryContact).Append("\n");
            sb.Append("  LocalArea: ").Append(LocalArea).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
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
            return Equals((SchoolBusOwner)obj);
        }

        /// <summary>
        /// Returns true if SchoolBusOwner instances are equal
        /// </summary>
        /// <param name="other">Instance of SchoolBusOwner to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchoolBusOwner other)
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
                    this.IsActive == other.IsActive ||
                    this.IsActive != null &&
                    this.IsActive.Equals(other.IsActive)
                ) && 
                (
                    this.DateCreated == other.DateCreated ||
                    this.DateCreated != null &&
                    this.DateCreated.Equals(other.DateCreated)
                ) && 
                (
                    this.PrimaryContact == other.PrimaryContact ||
                    this.PrimaryContact != null &&
                    this.PrimaryContact.Equals(other.PrimaryContact)
                ) && 
                (
                    this.LocalArea == other.LocalArea ||
                    this.LocalArea != null &&
                    this.LocalArea.Equals(other.LocalArea)
                ) && 
                (
                    this.City == other.City ||
                    this.City != null &&
                    this.City.Equals(other.City)
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
                    if (this.IsActive != null)
                    { 
                        hash = hash * 59 + this.IsActive.GetHashCode();
                    }
                    if (this.DateCreated != null)
                    { 
                        hash = hash * 59 + this.DateCreated.GetHashCode();
                    }
                    if (this.PrimaryContact != null)
                    { 
                        hash = hash * 59 + this.PrimaryContact.GetHashCode();
                    }
                    if (this.LocalArea != null)
                    { 
                        hash = hash * 59 + this.LocalArea.GetHashCode();
                    }
                    if (this.City != null)
                    { 
                        hash = hash * 59 + this.City.GetHashCode();
                    }
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(SchoolBusOwner left, SchoolBusOwner right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SchoolBusOwner left, SchoolBusOwner right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
