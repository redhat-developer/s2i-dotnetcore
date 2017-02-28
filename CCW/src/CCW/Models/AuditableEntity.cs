/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using Newtonsoft.Json;
using SchoolBusCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCW.Models
{
    public class AuditableEntity
    {
        [MetaDataExtension(Description = "Audit information - SM User Id for the User who created the record.")]
        [MaxLength(50)]
        [JsonIgnore]
        public string CreateUserid { get; set; }
        
        [MetaDataExtension(Description = "Audit information - Timestamp for record creation")]
        [JsonIgnore]
        public DateTime CreateTimestamp { get; set; }

        [MetaDataExtension(Description = "Audit information - SM User Id for the User who most recently updated the record")]
        [MaxLength(50)]
        [JsonIgnore]
        public string LastUpdateUserid { get; set; }

        [MetaDataExtension(Description = "Audit information - Timestamp for record modification")]
        [JsonIgnore]
        public DateTime LastUpdateTimestamp { get; set; }
    }
}
