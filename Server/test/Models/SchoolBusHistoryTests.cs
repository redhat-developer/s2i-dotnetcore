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
    ///  Class for testing the model SchoolBusHistory
    /// </summary>
    
    public class SchoolBusHistoryModelTests
    {
        // TODO uncomment below to declare an instance variable for SchoolBusHistory
        private History instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public SchoolBusHistoryModelTests()
        {
            instance = new History();
        }

    
        /// <summary>
        /// Test an instance of SchoolBusHistory
        /// </summary>
        [Fact]
        public void SchoolBusHistoryInstanceTest()
        {
            Assert.IsType<History>(instance);  
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

