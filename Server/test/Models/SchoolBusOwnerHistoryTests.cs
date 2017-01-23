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
    ///  Class for testing the model History
    /// </summary>
    
    public class HistoryModelTests
    {
        // TODO uncomment below to declare an instance variable for History
        private History instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public HistoryModelTests()
        {
            instance = new History();
        }

    
        /// <summary>
        /// Test an instance of History
        /// </summary>
        [Fact]
        public void HistoryInstanceTest()
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
        /// Test the property 'SchoolBusOwner'
        /// </summary>
        [Fact]
        public void SchoolBusOwnerTest()
        {
            // TODO unit test for the property 'SchoolBusOwner'
			Assert.True(true);
        }

	}
	
}

