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
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SchoolBusAPI.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class UserRoleViewModel : IEquatable<UserRoleViewModel>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public UserRoleViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleViewModel" /> class.
        /// </summary>
        /// <param name="EffectiveDate">EffectiveDate (required).</param>
        /// <param name="RoleId">RoleId (required).</param>
        /// <param name="UserId">UserId (required).</param>
        /// <param name="Id">Id.</param>
        /// <param name="ExpiryDate">ExpiryDate.</param>
        public UserRoleViewModel(DateTime EffectiveDate, int RoleId, int UserId, int? Id = null, DateTime? ExpiryDate = null)
        {   
            this.EffectiveDate = EffectiveDate;
            this.RoleId = RoleId;
            this.UserId = UserId;


            this.Id = Id;
            this.ExpiryDate = ExpiryDate;
        }

        /// <summary>
        /// Gets or Sets EffectiveDate
        /// </summary>
        [DataMember(Name="effectiveDate")]
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// Gets or Sets RoleId
        /// </summary>
        [DataMember(Name="roleId")]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [DataMember(Name="userId")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets ExpiryDate
        /// </summary>
        [DataMember(Name="expiryDate")]
        public DateTime? ExpiryDate { get; set; }

        [DataMember(Name ="role")]
        public RoleViewModel Role { get; set; }

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
            return Equals((UserRoleViewModel)obj);
        }

        /// <summary>
        /// Returns true if UserRoleViewModel instances are equal
        /// </summary>
        /// <param name="other">Instance of UserRoleViewModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserRoleViewModel other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.EffectiveDate == other.EffectiveDate ||
                    this.EffectiveDate != null &&
                    this.EffectiveDate.Equals(other.EffectiveDate)
                ) &&                 
                (
                    this.RoleId == other.RoleId ||
                    this.RoleId.Equals(other.RoleId)
                ) &&                 
                (
                    this.UserId == other.UserId ||
                    this.UserId.Equals(other.UserId)
                ) &&                 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.ExpiryDate == other.ExpiryDate ||
                    this.ExpiryDate != null &&
                    this.ExpiryDate.Equals(other.ExpiryDate)
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
                   
                if (this.EffectiveDate != null)
                {
                    hash = hash * 59 + this.EffectiveDate.GetHashCode();
                }                                   
                hash = hash * 59 + this.RoleId.GetHashCode();                                   
                hash = hash * 59 + this.UserId.GetHashCode();                if (this.Id != null)
                {
                    hash = hash * 59 + this.Id.GetHashCode();
                }                
                                if (this.ExpiryDate != null)
                {
                    hash = hash * 59 + this.ExpiryDate.GetHashCode();
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
        public static bool operator ==(UserRoleViewModel left, UserRoleViewModel right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(UserRoleViewModel left, UserRoleViewModel right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
