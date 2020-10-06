namespace SchoolBusAPI.ViewModels
{
    public class InspectionCountsViewModel
    {
        public int Overdue { get; set; }
        public int Within30days { get; set; }
        public int ScheduledInspections { get; set; }
        public int ReInspections { get; set; }

        public InspectionCountsViewModel(int overdue, int within30days, int scheduledInspections, int reInspections)
        {
            Overdue = overdue;
            Within30days = within30days;
            ScheduledInspections = scheduledInspections;
            ReInspections = reInspections;
        }
    }
}
