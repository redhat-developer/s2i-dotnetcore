using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolBusAPI.Models
{
    public class CCWNotification : AuditableEntity
    {
        [MetaDataExtension(Description = "A system-generated unique identifier for a CCW Notification")]
        public int Id { get; set; }

        /// <summary>
        /// An assembled text string about the event that triggered the notification. Includes both static text and data about the notification. User Interface code will be used (based on the eventTypeCode - category) to assemble a dynamic string of information about the event - potentially including links to other relevant data - such as link to the School Bus detail screen.
        /// </summary>
        /// <value>An assembled text string about the event that triggered the notification. Includes both static text and data about the notification. User Interface code will be used (based on the eventTypeCode - category) to assemble a dynamic string of information about the event - potentially including links to other relevant data - such as link to the School Bus detail screen.</value>
        [MetaDataExtension(Description = "An assembled text string about the event that triggered the notification. Includes both static text and data about the notification. User Interface code will be used (based on the eventTypeCode - category) to assemble a dynamic string of information about the event - potentially including links to other relevant data - such as link to the School Bus detail screen.")]
        [MaxLength(2048)]

        public string Notes { get; set; }

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
