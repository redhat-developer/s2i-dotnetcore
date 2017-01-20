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



    public partial class SchoolBusOwnerContactAddress : IEquatable<SchoolBusOwnerContactAddress>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public SchoolBusOwnerContactAddress()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchoolBusOwnerContactAddress" /> class.
        /// </summary>
        /// <param name="Id">Primary Key (required).</param>
        /// <param name="Type">The type of the address. UI controlled as to whether it is free form or selected from an enumerated list..</param>
        /// <param name="Addr1">Address 1 line of the address..</param>
        /// <param name="Addr2">Address 2 line of the address..</param>
        /// <param name="City">The City of the address..</param>
        /// <param name="Province">The Province of the address..</param>
        /// <param name="PostalCode">The postal code of the address..</param>
        public SchoolBusOwnerContactAddress(int Id, string Type = null, string Addr1 = null, string Addr2 = null, string City = null, string Province = null, string PostalCode = null)
        {
            
            this.Id = Id;
            this.Type = Type;
            this.Addr1 = Addr1;
            this.Addr2 = Addr2;
            this.City = City;
            this.Province = Province;
            this.PostalCode = PostalCode;
            
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        /// <value>Primary Key</value>
        [MetaDataExtension (Description = "Primary Key")]
        public int Id { get; set; }

        

        /// <summary>
        /// The type of the address. UI controlled as to whether it is free form or selected from an enumerated list.
        /// </summary>
        /// <value>The type of the address. UI controlled as to whether it is free form or selected from an enumerated list.</value>
        [MetaDataExtension (Description = "The type of the address. UI controlled as to whether it is free form or selected from an enumerated list.")]
        public string Type { get; set; }

        

        /// <summary>
        /// Address 1 line of the address.
        /// </summary>
        /// <value>Address 1 line of the address.</value>
        [MetaDataExtension (Description = "Address 1 line of the address.")]
        public string Addr1 { get; set; }

        

        /// <summary>
        /// Address 2 line of the address.
        /// </summary>
        /// <value>Address 2 line of the address.</value>
        [MetaDataExtension (Description = "Address 2 line of the address.")]
        public string Addr2 { get; set; }

        

        /// <summary>
        /// The City of the address.
        /// </summary>
        /// <value>The City of the address.</value>
        [MetaDataExtension (Description = "The City of the address.")]
        public string City { get; set; }

        

        /// <summary>
        /// The Province of the address.
        /// </summary>
        /// <value>The Province of the address.</value>
        [MetaDataExtension (Description = "The Province of the address.")]
        public string Province { get; set; }

        

        /// <summary>
        /// The postal code of the address.
        /// </summary>
        /// <value>The postal code of the address.</value>
        [MetaDataExtension (Description = "The postal code of the address.")]
        public string PostalCode { get; set; }

        

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchoolBusOwnerContactAddress {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Addr1: ").Append(Addr1).Append("\n");
            sb.Append("  Addr2: ").Append(Addr2).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  Province: ").Append(Province).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
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
            return Equals((SchoolBusOwnerContactAddress)obj);
        }

        /// <summary>
        /// Returns true if SchoolBusOwnerContactAddress instances are equal
        /// </summary>
        /// <param name="other">Instance of SchoolBusOwnerContactAddress to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchoolBusOwnerContactAddress other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) &&                 
                (
                    this.Addr1 == other.Addr1 ||
                    this.Addr1 != null &&
                    this.Addr1.Equals(other.Addr1)
                ) &&                 
                (
                    this.Addr2 == other.Addr2 ||
                    this.Addr2 != null &&
                    this.Addr2.Equals(other.Addr2)
                ) &&                 
                (
                    this.City == other.City ||
                    this.City != null &&
                    this.City.Equals(other.City)
                ) &&                 
                (
                    this.Province == other.Province ||
                    this.Province != null &&
                    this.Province.Equals(other.Province)
                ) &&                 
                (
                    this.PostalCode == other.PostalCode ||
                    this.PostalCode != null &&
                    this.PostalCode.Equals(other.PostalCode)
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
                
                
                if (this.Type != null)
                {
                    hash = hash * 59 + this.Type.GetHashCode();
                }                
                
                if (this.Addr1 != null)
                {
                    hash = hash * 59 + this.Addr1.GetHashCode();
                }                
                
                if (this.Addr2 != null)
                {
                    hash = hash * 59 + this.Addr2.GetHashCode();
                }                
                
                if (this.City != null)
                {
                    hash = hash * 59 + this.City.GetHashCode();
                }                
                
                if (this.Province != null)
                {
                    hash = hash * 59 + this.Province.GetHashCode();
                }                
                
                if (this.PostalCode != null)
                {
                    hash = hash * 59 + this.PostalCode.GetHashCode();
                }                
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(SchoolBusOwnerContactAddress left, SchoolBusOwnerContactAddress right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SchoolBusOwnerContactAddress left, SchoolBusOwnerContactAddress right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
