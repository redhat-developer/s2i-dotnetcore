using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusAPI.Models
{
    /// <summary>
    /// error object
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Construtor of error object
        /// </summary>
        /// <param name="errorTitle">error title</param>
        /// <param name="errorCode">error code</param>
        /// <param name="errorMessage">error message</param>
        public Error(string errorTitle, int errorCode, string errorMessage)
        {
            this.errorTitle = errorTitle;
            this.errorCode = errorCode;
            this.errorMessage = errorMessage;
        }
        /// <summary>
        /// get set error title
        /// </summary>
        public string errorTitle { get; set; }
        /// <summary>
        /// get set error code
        /// </summary>
        public int errorCode { get; set; }
        /// <summary>
        /// get set error message
        /// </summary>
        public string errorMessage { get; set; }
        
    }
}
