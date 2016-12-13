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
    ///  Class for testing the model LocalArea
    /// </summary>
    
    public class LocalAreaModelTests
    {
        // TODO uncomment below to declare an instance variable for LocalArea
        private LocalArea instance;
        private Region instance_region;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public LocalAreaModelTests()
        {
            instance_region = new Region(0);
            instance = new LocalArea(0,instance_region);
        }

    
        /// <summary>
        /// Test an instance of LocalArea
        /// </summary>
        [Fact]
        public void LocalAreaInstanceTest()
        {
            Assert.IsType<LocalArea>(instance);  
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

