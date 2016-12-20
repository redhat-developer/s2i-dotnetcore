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
    ///  Class for testing the model SchoolBusOwner
    /// </summary>
    
    public class SchoolBusOwnerModelTests
    {
        // TODO uncomment below to declare an instance variable for SchoolBusOwner
        private SchoolBusOwner instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public SchoolBusOwnerModelTests()
        {
            instance = new SchoolBusOwner();
        }

    
        /// <summary>
        /// Test an instance of SchoolBusOwner
        /// </summary>
        [Fact]
        public void SchoolBusOwnerInstanceTest()
        {
            Assert.IsType<SchoolBusOwner>(instance);  
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
        /// Test the property 'Name'
        /// </summary>
        [Fact]
        public void NameTest()
        {
            // TODO unit test for the property 'Name'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'IsActive'
        /// </summary>
        [Fact]
        public void IsActiveTest()
        {
            // TODO unit test for the property 'IsActive'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'DateCreated'
        /// </summary>
        [Fact]
        public void DateCreatedTest()
        {
            // TODO unit test for the property 'DateCreated'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'PrimaryContact'
        /// </summary>
        [Fact]
        public void PrimaryContactTest()
        {
            // TODO unit test for the property 'PrimaryContact'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'LocalArea'
        /// </summary>
        [Fact]
        public void LocalAreaTest()
        {
            // TODO unit test for the property 'LocalArea'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'City'
        /// </summary>
        [Fact]
        public void CityTest()
        {
            // TODO unit test for the property 'City'
			Assert.True(true);
        }

	}
	
}

