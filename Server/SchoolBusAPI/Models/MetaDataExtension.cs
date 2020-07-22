using System;

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// Utility class used for the column comment (description) feature
    /// </summary>
    public class MetaDataExtension : Attribute
    {

        /// <summary>
        /// The PostgreSQL Comment.  Used for columns with entity framework. 
        /// </summary>
        public virtual string Description { get; set; }

    }
}
