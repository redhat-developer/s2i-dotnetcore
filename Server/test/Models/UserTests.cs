/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
 *
 * OpenAPI spec version: v1
 * 
 * 
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using SchoolBusAPI;
using SchoolBusAPI.Models;
using System.Reflection;

namespace SchoolBusAPI.Test
{
    /// <summary>
    ///  Class for testing the model User
    /// </summary>
    
    public class UserModelTests
    {
        // TODO uncomment below to declare an instance variable for User
        private User instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public UserModelTests()
        {
            instance = new User();
        }

    
        /// <summary>
        /// Test an instance of User
        /// </summary>
        [Fact]
        public void UserInstanceTest()
        {
            Assert.IsType<User>(instance);  
        }

        /// <summary>
        /// Test the property 'Id'
        /// </summary>
        [Fact]
        public void IdTest()
        {
            // TODO unit test for the property 'Id'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'GivenName'
        /// </summary>
        [Fact]
        public void GivenNameTest()
        {
            // TODO unit test for the property 'GivenName'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Surname'
        /// </summary>
        [Fact]
        public void SurnameTest()
        {
            // TODO unit test for the property 'Surname'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Initials'
        /// </summary>
        [Fact]
        public void InitialsTest()
        {
            // TODO unit test for the property 'Initials'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Email'
        /// </summary>
        [Fact]
        public void EmailTest()
        {
            // TODO unit test for the property 'Email'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Active'
        /// </summary>
        [Fact]
        public void ActiveTest()
        {
            // TODO unit test for the property 'Active'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'SmUserId'
        /// </summary>
        [Fact]
        public void SmUserIdTest()
        {
            // TODO unit test for the property 'SmUserId'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Guid'
        /// </summary>
        [Fact]
        public void GuidTest()
        {
            // TODO unit test for the property 'Guid'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'SmAuthorizationDirectory'
        /// </summary>
        [Fact]
        public void SmAuthorizationDirectoryTest()
        {
            // TODO unit test for the property 'SmAuthorizationDirectory'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'UserRoles'
        /// </summary>
        [Fact]
        public void UserRolesTest()
        {
            // TODO unit test for the property 'UserRoles'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'GroupMemberships'
        /// </summary>
        [Fact]
        public void GroupMembershipsTest()
        {
            // TODO unit test for the property 'GroupMemberships'
			Assert.True(true);
        }

	}
	
}

