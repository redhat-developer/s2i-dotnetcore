using System;

namespace SchoolBusAPI.ViewModels
{
    public class DistrictViewModel
    {
        public int Id { get; set; }
        public int MinistryDistrictID { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
