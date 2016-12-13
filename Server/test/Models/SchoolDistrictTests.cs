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
    ///  Class for testing the model SchoolDistrict
    /// </summary>
    
    public class SchoolDistrictModelTests
    {
        // TODO uncomment below to declare an instance variable for SchoolDistrict
        private SchoolDistrict instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public SchoolDistrictModelTests()
        {
            instance = new SchoolDistrict(0);
        }

    
        /// <summary>
        /// Test an instance of SchoolDistrict
        /// </summary>
        [Fact]
        public void SchoolDistrictInstanceTest()
        {
            Assert.IsType<SchoolDistrict>(instance);  
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
        /// Test the property 'LocalArea'
        /// </summary>
        [Fact]
        public void LocalAreaTest()
        {
            // TODO unit test for the property 'LocalArea'
			Assert.True(true);
        }

	}
	
}

