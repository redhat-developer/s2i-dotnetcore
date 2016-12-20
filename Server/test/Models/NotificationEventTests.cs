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
    ///  Class for testing the model NotificationEvent
    /// </summary>
    
    public class NotificationEventModelTests
    {
        // TODO uncomment below to declare an instance variable for NotificationEvent
        private NotificationEvent instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public NotificationEventModelTests()
        {
            instance = new NotificationEvent();
        }

    
        /// <summary>
        /// Test an instance of NotificationEvent
        /// </summary>
        [Fact]
        public void NotificationEventInstanceTest()
        {
            Assert.IsType<NotificationEvent>(instance);  
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
        /// Test the property 'EventTime'
        /// </summary>
        [Fact]
        public void EventTimeTest()
        {
            // TODO unit test for the property 'EventTime'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'EventTypeCode'
        /// </summary>
        [Fact]
        public void EventTypeCodeTest()
        {
            // TODO unit test for the property 'EventTypeCode'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'EventSubTypeCode'
        /// </summary>
        [Fact]
        public void EventSubTypeCodeTest()
        {
            // TODO unit test for the property 'EventSubTypeCode'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Notes'
        /// </summary>
        [Fact]
        public void NotesTest()
        {
            // TODO unit test for the property 'Notes'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'NotificationGenerated'
        /// </summary>
        [Fact]
        public void NotificationGeneratedTest()
        {
            // TODO unit test for the property 'NotificationGenerated'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'SchoolBus'
        /// </summary>
        [Fact]
        public void SchoolBusTest()
        {
            // TODO unit test for the property 'SchoolBus'
			Assert.True(true);
        }

	}
	
}

