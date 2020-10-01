using System;
using System.Collections.Generic;

namespace SchoolBusAPI.ViewModels
{
    public class CCWNotificationViewModel
    {
        public int Id { get; set; }
        public List<CCWNotificationDetailViewModel> CCWNotificationDetails { get; set; }
        public bool HasBeenViewed { get; set; }
        public string SchoolBusRegNum { get; set; }
        public int SchoolBusId { get; set; }
        public string SchoolBusOwnerName { get; set; }
        public int SchoolBusOwnerId { get; set; }
        public DateTime DateDetected { get; set; }
    }
}
