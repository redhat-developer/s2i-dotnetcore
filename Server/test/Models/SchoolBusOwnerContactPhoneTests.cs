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
    ///  Class for testing the model SchoolBusOwnerContactPhone
    /// </summary>
    
    public class SchoolBusOwnerContactPhoneModelTests
    {
        // TODO uncomment below to declare an instance variable for SchoolBusOwnerContactPhone
        private SchoolBusOwnerContactPhone instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public SchoolBusOwnerContactPhoneModelTests()
        {
            instance = new SchoolBusOwnerContactPhone();
        }

    
        /// <summary>
        /// Test an instance of SchoolBusOwnerContactPhone
        /// </summary>
        [Fact]
        public void SchoolBusOwnerContactPhoneInstanceTest()
        {
            Assert.IsType<SchoolBusOwnerContactPhone>(instance);  
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

