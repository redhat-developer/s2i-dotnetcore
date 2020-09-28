using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusAPI.ViewModels
{
    public class ChangeViewModel
    {
        public string ColName { get; set; }
        public string ColDescription { get; set; }
        public string ValueFrom { get; set; }
        public string ValueTo { get; set; }
    }
}
