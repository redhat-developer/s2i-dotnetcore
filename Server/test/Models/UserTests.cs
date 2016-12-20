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
        /// Test the property 'Email'
        /// </summary>
        [Fact]
        public void EmailTest()
        {
            // TODO unit test for the property 'Email'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'SmUserid'
        /// </summary>
        [Fact]
        public void SmUseridTest()
        {
            // TODO unit test for the property 'SmUserid'
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

	}
	
}

