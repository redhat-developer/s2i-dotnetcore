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

namespace SchoolBusAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class RolePermissionViewModel : IEquatable<RolePermissionViewModel>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public RolePermissionViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RolePermissionViewModel" /> class.
        /// </summary>
        /// <param name="RoleId">RoleId (required).</param>
        /// <param name="PermissionId">PermissionId (required).</param>
        /// <param name="Id">Id.</param>
        public RolePermissionViewModel(int RoleId, int PermissionId, int? Id = null)
        {   
            this.RoleId = RoleId;
            this.PermissionId = PermissionId;

            this.Id = Id;
        }

        /// <summary>
        /// Gets or Sets RoleId
        /// </summary>
        [DataMember(Name="roleId")]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or Sets PermissionId
        /// </summary>
        [DataMember(Name="permissionId")]
        public int PermissionId { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id")]
        public int? Id { get; set; }

        [DataMember(Name="permission")]
        public PermissionViewModel Permission { get; set; }

        /// <summary>
        /// Gets or Sets ExpiryDate
        /// </summary>
        [DataMember(Name = "expiryDate")]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return ToJson();
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
            return Equals((RolePermissionViewModel)obj);
        }

        /// <summary>
        /// Returns true if RolePermissionViewModel instances are equal
        /// </summary>
        /// <param name="other">Instance of RolePermissionViewModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RolePermissionViewModel other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.RoleId == other.RoleId ||
                    this.RoleId.Equals(other.RoleId)
                ) &&                 
                (
                    this.PermissionId == other.PermissionId ||
                    this.PermissionId.Equals(other.PermissionId)
                ) &&                 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
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
                                   
                hash = hash * 59 + this.RoleId.GetHashCode();                                   
                hash = hash * 59 + this.PermissionId.GetHashCode();                if (this.Id != null)
                {
                    hash = hash * 59 + this.Id.GetHashCode();
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
        public static bool operator ==(RolePermissionViewModel left, RolePermissionViewModel right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(RolePermissionViewModel left, RolePermissionViewModel right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
