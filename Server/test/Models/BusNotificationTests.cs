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
    ///  Class for testing the model BusNotification
    /// </summary>
    
    public class BusNotificationModelTests
    {
        // TODO uncomment below to declare an instance variable for BusNotification
        private BusNotification instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public BusNotificationModelTests()
        {
            instance = new BusNotification(0);
        }

    
        /// <summary>
        /// Test an instance of BusNotification
        /// </summary>
        [Fact]
        public void BusNotificationInstanceTest()
        {
            Assert.IsType<BusNotification>(instance);  
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

