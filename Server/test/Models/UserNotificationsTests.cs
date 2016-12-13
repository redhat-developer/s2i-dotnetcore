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
    ///  Class for testing the model UserNotifications
    /// </summary>
    
    public class UserNotificationsModelTests
    {
        // TODO uncomment below to declare an instance variable for UserNotifications
        private UserNotifications instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public UserNotificationsModelTests()
        {
            instance = new UserNotifications(0);
        }

    
        /// <summary>
        /// Test an instance of UserNotifications
        /// </summary>
        [Fact]
        public void UserNotificationsInstanceTest()
        {
            Assert.IsType<UserNotifications>(instance);  
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
        /// Test the property 'BusNotification'
        /// </summary>
        [Fact]
        public void BusNotificationTest()
        {
            // TODO unit test for the property 'BusNotification'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'User'
        /// </summary>
        [Fact]
        public void UserTest()
        {
            // TODO unit test for the property 'User'
			Assert.True(true);
        }

	}
	
}

