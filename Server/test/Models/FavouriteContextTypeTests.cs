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
    ///  Class for testing the model FavouriteContextType
    /// </summary>
    
    public class FavouriteContextTypeModelTests
    {
        // TODO uncomment below to declare an instance variable for FavouriteContextType
        private FavouriteContextType instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public FavouriteContextTypeModelTests()
        {
            instance = new FavouriteContextType();
        }

    
        /// <summary>
        /// Test an instance of FavouriteContextType
        /// </summary>
        [Fact]
        public void FavouriteContextTypeInstanceTest()
        {
            Assert.IsType<FavouriteContextType>(instance);  
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

