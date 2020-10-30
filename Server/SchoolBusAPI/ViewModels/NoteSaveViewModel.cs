using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusAPI.ViewModels
{
    public class NoteSaveViewModel
    {
        public NoteSaveViewModel()
        {
            IsNoLongerRelevant = false;
        }

        public int Id { get; set; }
        public int? SchoolBusId { get; set; }
        public int? SchoolBusOwnerId { get; set; }
        public string NoteText { get; set; }
        public bool? IsNoLongerRelevant { get; set; }
    }
}
