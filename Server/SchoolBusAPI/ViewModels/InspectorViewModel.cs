namespace SchoolBusAPI.ViewModels
{
    public class InspectorViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public int? DistrictId { get; set; }
    }
}
