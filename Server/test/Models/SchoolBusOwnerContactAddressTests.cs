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
    ///  Class for testing the model SchoolBusOwnerContactAddress
    /// </summary>
    
    public class SchoolBusOwnerContactAddressModelTests
    {
        // TODO uncomment below to declare an instance variable for SchoolBusOwnerContactAddress
        private SchoolBusOwnerContactAddress instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public SchoolBusOwnerContactAddressModelTests()
        {
            instance = new SchoolBusOwnerContactAddress();
        }

    
        /// <summary>
        /// Test an instance of SchoolBusOwnerContactAddress
        /// </summary>
        [Fact]
        public void SchoolBusOwnerContactAddressInstanceTest()
        {
            Assert.IsType<SchoolBusOwnerContactAddress>(instance);  
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
        /// Test the property 'SchoolBusOwnerContact'
        /// </summary>
        [Fact]
        public void SchoolBusOwnerContactTest()
        {
            // TODO unit test for the property 'SchoolBusOwnerContact'
			Assert.True(true);
        }

	}
	
}

