using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusAPI.Models
{
    public partial class SchoolBus
    {
        /// <summary>
        /// Add a history record to the SchoolBus
        /// </summary>
        /// <param name="text">text for the history entry</param>
        /// <param name="smUserId">Site Minder User ID for the history entry</param>
        public void AddHistory(string text, string smUserId)
        {
            if (this.History == null)
            {
                this.History = new List<History>();
            }
            History history = new Models.History()
            {                
                LastUpdateTimestamp = DateTime.UtcNow,                
                LastUpdateUserid = smUserId,
                HistoryText = text                
            };
            this.History.Add(history);
        }
    }
}
