using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolBusAPI.Models
{
    public class CCWNotification : AuditableEntity
    {
        public CCWNotification()
        {
            CCWNotificationDetails = new List<CCWNotificationDetail>();
        }
        
        [MetaDataExtension(Description = "A system-generated unique identifier for a CCW Notification")]
        public int Id { get; set; }

        /// <summary>
        /// CCW change details - original and modified values
        /// </summary>
        /// <value>CCW change details - original and modified values</value>
        [MetaDataExtension(Description = "CCW change details - original and modified values.")]
        public List<CCWNotificationDetail> CCWNotificationDetails { get; set; }

        /// <summary>
        /// True if the user linked to the bus has read the notification
        /// </summary>
        /// <value>True if the user linked to the inspection has read the notification</value>
        [MetaDataExtension(Description = "True if the user linked to the bus has read the notification")]
        public bool? HasBeenViewed { get; set; }

        /// <summary>
        /// A foreign key reference to the system-generated unique identifier for a School Bus
        /// </summary>
        /// <value>A foreign key reference to the system-generated unique identifier for a School Bus</value>
        [MetaDataExtension(Description = "A foreign key reference to the system-generated unique identifier for a School Bus")]
        public SchoolBus SchoolBus { get; set; }

        /// <summary>
        /// Foreign key for SchoolBus 
        /// </summary>   
        [ForeignKey("SchoolBus")]
        [JsonIgnore]
        [MetaDataExtension(Description = "A foreign key reference to the system-generated unique identifier for a School Bus")]
        public int? SchoolBusId { get; set; }
    }
}
