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
    ///  Class for testing the model Region
    /// </summary>
    
    public class RegionModelTests
    {
        // TODO uncomment below to declare an instance variable for Region
        private Region instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public RegionModelTests()
        {
            instance = new Region();
        }

    
        /// <summary>
        /// Test an instance of Region
        /// </summary>
        [Fact]
        public void RegionInstanceTest()
        {
            Assert.IsType<Region>(instance);  
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

	}
	
}

