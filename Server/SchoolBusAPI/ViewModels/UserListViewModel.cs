using SchoolBusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SchoolBusAPI.ViewModels
{
    [DataContract]
    public class UserListViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Active
        /// </summary>
        [DataMember(Name = "active")]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or Sets GivenName
        /// </summary>
        [DataMember(Name = "givenName")]
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or Sets Surname
        /// </summary>
        [DataMember(Name = "surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets SmUserId
        /// </summary>
        [DataMember(Name = "smUserId")]
        public string SmUserId { get; set; }

        /// <summary>
        /// The District to which this User is affliated.
        /// </summary>
        /// <value>The District to which this User is affliated.</value>
        [DataMember(Name = "district")]
        [MetaDataExtension(Description = "The District to which this User is affliated.")]
        public District District { get; set; }

    }
}
