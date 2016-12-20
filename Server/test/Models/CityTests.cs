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
    ///  Class for testing the model City
    /// </summary>
    
    public class CityModelTests
    {
        // TODO uncomment below to declare an instance variable for City
        private City instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public CityModelTests()
        {
            instance = new City();
        }

    
        /// <summary>
        /// Test an instance of City
        /// </summary>
        [Fact]
        public void CityInstanceTest()
        {
            Assert.IsType<City>(instance);  
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
        /// Test the property 'Region'
        /// </summary>
        [Fact]
        public void RegionTest()
        {
            // TODO unit test for the property 'Region'
			Assert.True(true);
        }

	}
	
}

