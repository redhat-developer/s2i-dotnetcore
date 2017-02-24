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
    /// The set of permissions defined in the application. Each permission is given a name and triggers some behavior defined in the application. For example, a permission might allow users to see data or to have access to functionality restricted to users without that permission. Permissions are created as needed to the application and are added to the permissions table by data migrations executed at the time the software that uses the permission is deployed.
    /// </summary>
        [MetaDataExtension (Description = "The set of permissions defined in the application. Each permission is given a name and triggers some behavior defined in the application. For example, a permission might allow users to see data or to have access to functionality restricted to users without that permission. Permissions are created as needed to the application and are added to the permissions table by data migrations executed at the time the software that uses the permission is deployed.")]

    public partial class Permission : AuditableEntity, IEquatable<Permission>
    {
        /// <summary>
        /// Default constructor, required by entity framework
        /// </summary>
        public Permission()
        {
            this.Id = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Permission" /> class.
        /// </summary>
        /// <param name="Id">A system-generated unique identifier for a Permission (required).</param>
        /// <param name="Code">The name of the permission referenced in the software of the application. (required).</param>
        /// <param name="Name">The &amp;#39;user friendly&amp;#39; name of the permission exposed to the user selecting the permissions to be included in a Role. (required).</param>
        /// <param name="Description">A description of the purpose of the permission and exposed to the user selecting the permissions to be included in a Role. (required).</param>
        public Permission(int Id, string Code, string Name, string Description)
        {   
            this.Id = Id;
            this.Code = Code;
            this.Name = Name;
            this.Description = Description;



        }

        /// <summary>
        /// A system-generated unique identifier for a Permission
        /// </summary>
        /// <value>A system-generated unique identifier for a Permission</value>
        [MetaDataExtension (Description = "A system-generated unique identifier for a Permission")]
        public int Id { get; set; }
        
        /// <summary>
        /// The name of the permission referenced in the software of the application.
        /// </summary>
        /// <value>The name of the permission referenced in the software of the application.</value>
        [MetaDataExtension (Description = "The name of the permission referenced in the software of the application.")]
        [MaxLength(255)]
        
        public string Code { get; set; }
        
        /// <summary>
        /// The &#39;user friendly&#39; name of the permission exposed to the user selecting the permissions to be included in a Role.
        /// </summary>
        /// <value>The &#39;user friendly&#39; name of the permission exposed to the user selecting the permissions to be included in a Role.</value>
        [MetaDataExtension (Description = "The &#39;user friendly&#39; name of the permission exposed to the user selecting the permissions to be included in a Role.")]
        [MaxLength(255)]
        
        public string Name { get; set; }
        
        /// <summary>
        /// A description of the purpose of the permission and exposed to the user selecting the permissions to be included in a Role.
        /// </summary>
        /// <value>A description of the purpose of the permission and exposed to the user selecting the permissions to be included in a Role.</value>
        [MetaDataExtension (Description = "A description of the purpose of the permission and exposed to the user selecting the permissions to be included in a Role.")]
        [MaxLength(255)]
        
        public string Description { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Permission {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return Equals((Permission)obj);
        }

        /// <summary>
        /// Returns true if Permission instances are equal
        /// </summary>
        /// <param name="other">Instance of Permission to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Permission other)
        {

            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }

            return                 
                (
                    this.Id == other.Id ||
                    this.Id.Equals(other.Id)
                ) &&                 
                (
                    this.Code == other.Code ||
                    this.Code != null &&
                    this.Code.Equals(other.Code)
                ) &&                 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) &&                 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
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
                                   
                hash = hash * 59 + this.Id.GetHashCode();                if (this.Code != null)
                {
                    hash = hash * 59 + this.Code.GetHashCode();
                }                
                                if (this.Name != null)
                {
                    hash = hash * 59 + this.Name.GetHashCode();
                }                
                                if (this.Description != null)
                {
                    hash = hash * 59 + this.Description.GetHashCode();
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
        public static bool operator ==(Permission left, Permission right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Not Equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Permission left, Permission right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}
