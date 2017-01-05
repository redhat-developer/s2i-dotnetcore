using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusAPI.Models
{
    public class MetaDataExtension : Attribute
    {
        private string _description;
        /// <summary>
        /// The PostgreSQL Comment.  Used for columns with entity framework. 
        /// </summary>
        public virtual string Description { get { return _description; } set { _description = value; } }
    
    }
}
