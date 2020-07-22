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

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// Server generated audit log
    /// </summary>
        [MetaDataExtension (Description = "Server generated audit log")]

    public partial class Audit : AuditableEntity, IEquatable<Audit>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public Audit()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Audit" /> class.
        /// </summary>
        /// <param name="Id">A system-generated unique identifier for an Audit (required).</param>
        /// <param name="AppCreateTimestamp">The date and time of the application action that created the record..</param>
        /// <param name="AppCreateUserid">The user account name of the application user who performed the action that created the record (e.g. JSMITH). This value is not preceded by the directory name..</param>
        /// <param name="AppCreateUserGuid">The Globally Unique Identifier of the application user who performed the action that created the record. This value must be non-NULL if APP_CREATE_USER_DIRECTORY is &amp;#39;IDIR&amp;#39; or &amp;#39;BCEID&amp;#39;, but it must be NULL if APP_CREATE_USER_DIRECTORY is &amp;#39;ORACLE&amp;#39;. APP.</param>
        /// <param name="AppCreateUserDirectory">The directory in which APP_CREATE_USERID is defined. Valid values are &amp;#39;IDIR&amp;#39;, &amp;#39; BCEID&amp;#39; or &amp;#39;ORACLE&amp;#39;..</param>
        /// <param name="AppLastUpdateTimestamp">The date and time of the application action that created or last updated the record..</param>
        /// <param name="AppLastUpdateUserid">The Globally Unique Identifier of the application user who performed the action that created the record. This value must be non-NULL if APP_CREATE_USER_DIRECTORY is &amp;#39;IDIR&amp;#39; or &amp;#39;BCEID&amp;#39;, but it must be NULL if APP_CREATE_USER_DIRECTORY is &amp;#39;ORACLE&amp;#39;. APP.</param>
        /// <param name="AppLastUpdateUserGuid">The Globally Unique Identifier of the application user who performed the action that created or last updated the record. This value must be non-NULL if APP_CREATE_USER_DIRECTORY is &amp;#39;IDIR&amp;#39; or &amp;#39;BCEID&amp;#39;, but it must be NULL if APP_CREATE_USER_DIRECTORY is &amp;#39;ORACLE&amp;#39;..</param>
        /// <param name="AppLastUpdateUserDirectory">The directory in which APP_LAST_UPDATE_USERID is defined. Valid values are &amp;#39;IDIR&amp;#39;, &amp;#39; BCEID&amp;#39; or &amp;#39;ORACLE&amp;#39;..</param>
        /// <param name="EntityName">The name of the entity that has changed.</param>
        /// <param name="EntityId">The primary key in the entity that has changed.</param>
        /// <param name="PropertyName">The property that has changed.</param>
        /// <param name="OldValue">The old value.</param>
        /// <param name="NewValue">The new value.</param>
        /// <param name="IsDelete">If true the record was deleted.</param>
        public Audit(int Id, DateTime? AppCreateTimestamp = null, string AppCreateUserid = null, string AppCreateUserGuid = null, string AppCreateUserDirectory = null, DateTime? AppLastUpdateTimestamp = null, string AppLastUpdateUserid = null, string AppLastUpdateUserGuid = null, string AppLastUpdateUserDirectory = null, string EntityName = null, int? EntityId = null, string PropertyName = null, string OldValue = null, string NewValue = null, bool? IsDelete = null)
        {   
            this.Id = Id;
            this.AppCreateTimestamp = AppCreateTimestamp;
            this.AppCreateUserid = AppCreateUserid;
            this.AppCreateUserGuid = AppCreateUserGuid;
            this.AppCreateUserDirectory = AppCreateUserDirectory;
            this.AppLastUpdateTimestamp = AppLastUpdateTimestamp;
            this.AppLastUpdateUserid = AppLastUpdateUserid;
            this.AppLastUpdateUserGuid = AppLastUpdateUserGuid;
            this.AppLastUpdateUserDirectory = AppLastUpdateUserDirectory;
            this.EntityName = EntityName;
            this.EntityId = EntityId;
            this.PropertyName = PropertyName;
            this.OldValue = OldValue;
            this.NewValue = NewValue;
            this.IsDelete = IsDelete;
        }

        /// <summary>
        /// A system-generated unique identifier for an Audit
        /// </summary>
        /// <value>A system-generated unique identifier for an Audit</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for an Audit")]
        public int Id { get; set; }
        
        /// <summary>
        /// The date and time of the application action that created the record.
        /// </summary>
        /// <value>The date and time of the application action that created the record.</value>
        [MetaDataExtension (Description = "The date and time of the application action that created the record.")]
        public DateTime? AppCreateTimestamp { get; set; }
        
        /// <summary>
        /// The user account name of the application user who performed the action that created the record (e.g. JSMITH). This value is not preceded by the directory name.
        /// </summary>
        /// <value>The user account name of the application user who performed the action that created the record (e.g. JSMITH). This value is not preceded by the directory name.</value>
        [MetaDataExtension (Description = "The user account name of the application user who performed the action that created the record (e.g. JSMITH). This value is not preceded by the directory name.")]
        public string AppCreateUserid { get; set; }
        
        /// <summary>
        /// The Globally Unique Identifier of the application user who performed the action that created the record. This value must be non-NULL if APP_CREATE_USER_DIRECTORY is &#39;IDIR&#39; or &#39;BCEID&#39;, but it must be NULL if APP_CREATE_USER_DIRECTORY is &#39;ORACLE&#39;. APP
        /// </summary>
        /// <value>The Globally Unique Identifier of the application user who performed the action that created the record. This value must be non-NULL if APP_CREATE_USER_DIRECTORY is &#39;IDIR&#39; or &#39;BCEID&#39;, but it must be NULL if APP_CREATE_USER_DIRECTORY is &#39;ORACLE&#39;. APP</value>
        [MetaDataExtension (Description = "The Globally Unique Identifier of the application user who performed the action that created the record. This value must be non-NULL if APP_CREATE_USER_DIRECTORY is &#39;IDIR&#39; or &#39;BCEID&#39;, but it must be NULL if APP_CREATE_USER_DIRECTORY is &#39;ORACLE&#39;. APP")]
        public string AppCreateUserGuid { get; set; }
        
        /// <summary>
        /// The directory in which APP_CREATE_USERID is defined. Valid values are &#39;IDIR&#39;, &#39; BCEID&#39; or &#39;ORACLE&#39;.
        /// </summary>
        /// <value>The directory in which APP_CREATE_USERID is defined. Valid values are &#39;IDIR&#39;, &#39; BCEID&#39; or &#39;ORACLE&#39;.</value>
        [MetaDataExtension (Description = "The directory in which APP_CREATE_USERID is defined. Valid values are &#39;IDIR&#39;, &#39; BCEID&#39; or &#39;ORACLE&#39;.")]
        public string AppCreateUserDirectory { get; set; }
        
        /// <summary>
        /// The date and time of the application action that created or last updated the record.
        /// </summary>
        /// <value>The date and time of the application action that created or last updated the record.</value>
        [MetaDataExtension (Description = "The date and time of the application action that created or last updated the record.")]
        public DateTime? AppLastUpdateTimestamp { get; set; }
        
        /// <summary>
        /// The Globally Unique Identifier of the application user who performed the action that created the record. This value must be non-NULL if APP_CREATE_USER_DIRECTORY is &#39;IDIR&#39; or &#39;BCEID&#39;, but it must be NULL if APP_CREATE_USER_DIRECTORY is &#39;ORACLE&#39;. APP
        /// </summary>
        /// <value>The Globally Unique Identifier of the application user who performed the action that created the record. This value must be non-NULL if APP_CREATE_USER_DIRECTORY is &#39;IDIR&#39; or &#39;BCEID&#39;, but it must be NULL if APP_CREATE_USER_DIRECTORY is &#39;ORACLE&#39;. APP</value>
        [MetaDataExtension (Description = "The Globally Unique Identifier of the application user who performed the action that created the record. This value must be non-NULL if APP_CREATE_USER_DIRECTORY is &#39;IDIR&#39; or &#39;BCEID&#39;, but it must be NULL if APP_CREATE_USER_DIRECTORY is &#39;ORACLE&#39;. APP")]
        public string AppLastUpdateUserid { get; set; }
        
        /// <summary>
        /// The Globally Unique Identifier of the application user who performed the action that created or last updated the record. This value must be non-NULL if APP_CREATE_USER_DIRECTORY is &#39;IDIR&#39; or &#39;BCEID&#39;, but it must be NULL if APP_CREATE_USER_DIRECTORY is &#39;ORACLE&#39;.
        /// </summary>
        /// <value>The Globally Unique Identifier of the application user who performed the action that created or last updated the record. This value must be non-NULL if APP_CREATE_USER_DIRECTORY is &#39;IDIR&#39; or &#39;BCEID&#39;, but it must be NULL if APP_CREATE_USER_DIRECTORY is &#39;ORACLE&#39;.</value>
        [MetaDataExtension (Description = "The Globally Unique Identifier of the application user who performed the action that created or last updated the record. This value must be non-NULL if APP_CREATE_USER_DIRECTORY is &#39;IDIR&#39; or &#39;BCEID&#39;, but it must be NULL if APP_CREATE_USER_DIRECTORY is &#39;ORACLE&#39;.")]
        public string AppLastUpdateUserGuid { get; set; }
        
        /// <summary>
        /// The directory in which APP_LAST_UPDATE_USERID is defined. Valid values are &#39;IDIR&#39;, &#39; BCEID&#39; or &#39;ORACLE&#39;.
        /// </summary>
        /// <value>The directory in which APP_LAST_UPDATE_USERID is defined. Valid values are &#39;IDIR&#39;, &#39; BCEID&#39; or &#39;ORACLE&#39;.</value>
        [MetaDataExtension (Description = "The directory in which APP_LAST_UPDATE_USERID is defined. Valid values are &#39;IDIR&#39;, &#39; BCEID&#39; or &#39;ORACLE&#39;.")]
        public string AppLastUpdateUserDirectory { get; set; }
        
        /// <summary>
        /// The name of the entity that has changed
        /// </summary>
        /// <value>The name of the entity that has changed</value>
        [MetaDataExtension (Description = "The name of the entity that has changed")]
        public string EntityName { get; set; }
        
        /// <summary>
        /// The primary key in the entity that has changed
        /// </summary>
        /// <value>The primary key in the entity that has changed</value>
        [MetaDataExtension (Description = "The primary key in the entity that has changed")]
        public int? EntityId { get; set; }
        
        /// <summary>
        /// The property that has changed
        /// </summary>
        /// <value>The property that has changed</value>
        [MetaDataExtension (Description = "The property that has changed")]
        public string PropertyName { get; set; }
        
        /// <summary>
        /// The old value
        /// </summary>
        /// <value>The old value</value>
        [MetaDataExtension (Description = "The old value")]
        public string OldValue { get; set; }
        
        /// <summary>
        /// The new value
        /// </summary>
        /// <value>The new value</value>
        [MetaDataExtension (Description = "The new value")]
        public string NewValue { get; set; }
        
        /// <summary>
        /// If true the record was deleted
        /// </summary>
        /// <value>If true the record was deleted</value>
        [MetaDataExtension (Description = "If true the record was deleted")]
        public bool? IsDelete { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Audit {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  AppCreateTimestamp: ").Append(AppCreateTimestamp).Append("\n");
            sb.Append("  AppCreateUserid: ").Append(AppCreateUserid).Append("\n");
            sb.Append("  AppCreateUserGuid: ").Append(AppCreateUserGuid).Append("\n");
            sb.Append("  AppCreateUserDirectory: ").Append(AppCreateUserDirectory).Append("\n");
            sb.Append("  AppLastUpdateTimestamp: ").Append(AppLastUpdateTimestamp).Append("\n");
            sb.Append("  AppLastUpdateUserid: ").Append(AppLastUpdateUserid).Append("\n");
            sb.Append("  AppLastUpdateUserGuid: ").Append(AppLastUpdateUserGuid).Append("\n");
            sb.Append("  AppLastUpdateUserDirectory: ").Append(AppLastUpdateUserDirectory).Append("\n");
            sb.Append("  EntityName: ").Append(EntityName).Append("\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
            sb.Append("  PropertyName: ").Append(PropertyName).Append("\n");
            sb.Append("  OldValue: ").Append(OldValue).Append("\n");
            sb.Append("  NewValue: ").Append(NewValue).Append("\n");
            sb.Append("  IsDelete: ").Append(IsDelete).Append("\n");
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
            return Equals((Audit)obj);
        }

        /// <summary>
        /// Returns true if Audit instances are equal
        /// </summary>
        /// <param name="other">Instance of Audit to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Audit other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.AppCreateTimestamp == other.AppCreateTimestamp ||
                    this.AppCreateTimestamp != null &&
                    this.AppCreateTimestamp.Equals(other.AppCreateTimestamp)
                ) &&                 
                (
                    this.AppCreateUserid == other.AppCreateUserid ||
                    this.AppCreateUserid != null &&
                    this.AppCreateUserid.Equals(other.AppCreateUserid)
                ) &&                 
                (
                    this.AppCreateUserGuid == other.AppCreateUserGuid ||
                    this.AppCreateUserGuid != null &&
                    this.AppCreateUserGuid.Equals(other.AppCreateUserGuid)
                ) &&                 
                (
                    this.AppCreateUserDirectory == other.AppCreateUserDirectory ||
                    this.AppCreateUserDirectory != null &&
                    this.AppCreateUserDirectory.Equals(other.AppCreateUserDirectory)
                ) &&                 
                (
                    this.AppLastUpdateTimestamp == other.AppLastUpdateTimestamp ||
                    this.AppLastUpdateTimestamp != null &&
                    this.AppLastUpdateTimestamp.Equals(other.AppLastUpdateTimestamp)
                ) &&                 
                (
                    this.AppLastUpdateUserid == other.AppLastUpdateUserid ||
                    this.AppLastUpdateUserid != null &&
                    this.AppLastUpdateUserid.Equals(other.AppLastUpdateUserid)
                ) &&                 
                (
                    this.AppLastUpdateUserGuid == other.AppLastUpdateUserGuid ||
                    this.AppLastUpdateUserGuid != null &&
                    this.AppLastUpdateUserGuid.Equals(other.AppLastUpdateUserGuid)
                ) &&                 
                (
                    this.AppLastUpdateUserDirectory == other.AppLastUpdateUserDirectory ||
                    this.AppLastUpdateUserDirectory != null &&
                    this.AppLastUpdateUserDirectory.Equals(other.AppLastUpdateUserDirectory)
                ) &&                 
                (
                    this.EntityName == other.EntityName ||
                    this.EntityName != null &&
                    this.EntityName.Equals(other.EntityName)
                ) &&                 
                (
                    this.EntityId == other.EntityId ||
                    this.EntityId != null &&
                    this.EntityId.Equals(other.EntityId)
                ) &&                 
                (
                    this.PropertyName == other.PropertyName ||
                    this.PropertyName != null &&
                    this.PropertyName.Equals(other.PropertyName)
                ) &&                 
                (
                    this.OldValue == other.OldValue ||
                    this.OldValue != null &&
                    this.OldValue.Equals(other.OldValue)
                ) &&                 
                (
                    this.NewValue == other.NewValue ||
                    this.NewValue != null &&
                    this.NewValue.Equals(other.NewValue)
                ) &&                 
                (
                    this.IsDelete == other.IsDelete ||
                    this.IsDelete != null &&
                    this.IsDelete.Equals(other.IsDelete)
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
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.AppCreateTimestamp != null)
                {
                    hash = hash * 59 + this.AppCreateTimestamp.GetHashCode();
                }                
                                if (this.AppCreateUserid != null)
                {
                    hash = hash * 59 + this.AppCreateUserid.GetHashCode();
                }                
                                if (this.AppCreateUserGuid != null)
                {
                    hash = hash * 59 + this.AppCreateUserGuid.GetHashCode();
                }                
                                if (this.AppCreateUserDirectory != null)
                {
                    hash = hash * 59 + this.AppCreateUserDirectory.GetHashCode();
                }                
                                if (this.AppLastUpdateTimestamp != null)
                {
                    hash = hash * 59 + this.AppLastUpdateTimestamp.GetHashCode();
                }                
                                if (this.AppLastUpdateUserid != null)
                {
                    hash = hash * 59 + this.AppLastUpdateUserid.GetHashCode();
                }                
                                if (this.AppLastUpdateUserGuid != null)
                {
                    hash = hash * 59 + this.AppLastUpdateUserGuid.GetHashCode();
                }                
                                if (this.AppLastUpdateUserDirectory != null)
                {
                    hash = hash * 59 + this.AppLastUpdateUserDirectory.GetHashCode();
                }                
                                if (this.EntityName != null)
                {
                    hash = hash * 59 + this.EntityName.GetHashCode();
                }                
                                if (this.EntityId != null)
                {
                    hash = hash * 59 + this.EntityId.GetHashCode();
                }                
                                if (this.PropertyName != null)
                {
                    hash = hash * 59 + this.PropertyName.GetHashCode();
                }                
                                if (this.OldValue != null)
                {
                    hash = hash * 59 + this.OldValue.GetHashCode();
                }                
                                if (this.NewValue != null)
                {
                    hash = hash * 59 + this.NewValue.GetHashCode();
                }                
                                if (this.IsDelete != null)
                {
                    hash = hash * 59 + this.IsDelete.GetHashCode();
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
        public static bool operator ==(Audit left, Audit right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Audit left, Audit right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
