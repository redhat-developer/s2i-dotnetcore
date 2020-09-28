using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusAPI.Models
{
    public class CCWNotificationDetail : AuditableEntity
    {
        [MetaDataExtension(Description = "A system-generated unique identifier for a CCW Notification Detail")]
        public int Id { get; set; }
        [MetaDataExtension(Description = "Mdified column name")]
        public string ColName { get; set; }
        [MetaDataExtension(Description = "User friendly name of the modified column")]
        public string ColDescription { get; set; }
        [MetaDataExtension(Description = "Original value of the modified column")]
        [MaxLength(512)]
        public string ValueFrom { get; set; }
        [MetaDataExtension(Description = "Changed value of the modified column")]
        [MaxLength(512)]
        public string ValueTo { get; set; }
    }
}
