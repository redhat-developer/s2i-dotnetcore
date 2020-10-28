using System;

namespace SchoolBusAPI.ViewModels
{
    public class NoteViewModel
    {
        public NoteViewModel()
        {
            IsNoLongerRelevant = false;
        }

        public int Id { get; set; }
        public int? SchoolBusId { get; set; }
        public int? SchoolBusOwnerId { get; set; }
        public string NoteText { get; set; }
        public bool? IsNoLongerRelevant { get; set; }
        public string CreateUserid { get; set; }
        public DateTime CreateTimestamp { get; set; }
        //public string LastUpdateUserid { get; set; }
        //public DateTime LastUpdateTimestamp { get; set; }
    }
}
