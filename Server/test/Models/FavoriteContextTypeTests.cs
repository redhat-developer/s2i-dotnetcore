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
    ///  Class for testing the model FavoriteContextType
    /// </summary>
    
    public class FavoriteContextTypeModelTests
    {
        // TODO uncomment below to declare an instance variable for FavoriteContextType
        private FavoriteContextType instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public FavoriteContextTypeModelTests()
        {
            instance = new FavoriteContextType(0);
        }

    
        /// <summary>
        /// Test an instance of FavoriteContextType
        /// </summary>
        [Fact]
        public void FavoriteContextTypeInstanceTest()
        {
            Assert.IsType<FavoriteContextType>(instance);  
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

	}
	
}

