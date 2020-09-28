using System;

namespace SchoolBusAPI.ViewModels
{
    public class CCWNotificationViewModel
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public bool? HasBeenViewed { get; set; }
        public string SchoolBusRegNum { get; set; }
        public int SchoolBusId { get; set; }
        public string SchoolBusOwnerName { get; set; }
        public int SchoolBusOwnerId { get; set; }
        public DateTime DateDetected { get; set; }
    }
}
