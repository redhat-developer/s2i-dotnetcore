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
    ///  Class for testing the model Notification
    /// </summary>
    
    public class NotificationModelTests
    {
        // TODO uncomment below to declare an instance variable for Notification
        private Notification instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public NotificationModelTests()
        {
            instance = new Notification();
        }

    
        /// <summary>
        /// Test an instance of Notification
        /// </summary>
        [Fact]
        public void NotificationInstanceTest()
        {
            Assert.IsType<Notification>(instance);  
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
        /// Test the property 'Event'
        /// </summary>
        [Fact]
        public void EventTest()
        {
            // TODO unit test for the property 'Event'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Event2'
        /// </summary>
        [Fact]
        public void Event2Test()
        {
            // TODO unit test for the property 'Event2'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'HasBeenViewed'
        /// </summary>
        [Fact]
        public void HasBeenViewedTest()
        {
            // TODO unit test for the property 'HasBeenViewed'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'IsWatchNotification'
        /// </summary>
        [Fact]
        public void IsWatchNotificationTest()
        {
            // TODO unit test for the property 'IsWatchNotification'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'IsExpired'
        /// </summary>
        [Fact]
        public void IsExpiredTest()
        {
            // TODO unit test for the property 'IsExpired'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'IsAllDay'
        /// </summary>
        [Fact]
        public void IsAllDayTest()
        {
            // TODO unit test for the property 'IsAllDay'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'PriorityCode'
        /// </summary>
        [Fact]
        public void PriorityCodeTest()
        {
            // TODO unit test for the property 'PriorityCode'
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

