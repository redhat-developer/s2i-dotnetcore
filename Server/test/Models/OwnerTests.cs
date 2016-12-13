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
    ///  Class for testing the model Owner
    /// </summary>
    
    public class OwnerModelTests
    {
        // TODO uncomment below to declare an instance variable for Owner
        private Owner instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public OwnerModelTests()
        {
            instance = new Owner(0);
        }

    
        /// <summary>
        /// Test an instance of Owner
        /// </summary>
        [Fact]
        public void OwnerInstanceTest()
        {
            Assert.IsType<Owner>(instance);  
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
        /// Test the property 'FleetNum'
        /// </summary>
        [Fact]
        public void FleetNumTest()
        {
            // TODO unit test for the property 'FleetNum'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'MCCode'
        /// </summary>
        [Fact]
        public void MCCodeTest()
        {
            // TODO unit test for the property 'MCCode'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'FleetSize'
        /// </summary>
        [Fact]
        public void FleetSizeTest()
        {
            // TODO unit test for the property 'FleetSize'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'HasBuses'
        /// </summary>
        [Fact]
        public void HasBusesTest()
        {
            // TODO unit test for the property 'HasBuses'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Diff'
        /// </summary>
        [Fact]
        public void DiffTest()
        {
            // TODO unit test for the property 'Diff'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'LeaseSize'
        /// </summary>
        [Fact]
        public void LeaseSizeTest()
        {
            // TODO unit test for the property 'LeaseSize'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'HasDups'
        /// </summary>
        [Fact]
        public void HasDupsTest()
        {
            // TODO unit test for the property 'HasDups'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'SchoolDistrict'
        /// </summary>
        [Fact]
        public void SchoolDistrictTest()
        {
            // TODO unit test for the property 'SchoolDistrict'
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

