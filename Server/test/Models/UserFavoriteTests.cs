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
    ///  Class for testing the model UserFavorite
    /// </summary>
    
    public class UserFavoriteModelTests
    {
        // TODO uncomment below to declare an instance variable for UserFavorite
        private UserFavorite instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public UserFavoriteModelTests()
        {
            instance = new UserFavorite(0);
        }

    
        /// <summary>
        /// Test an instance of UserFavorite
        /// </summary>
        [Fact]
        public void UserFavoriteInstanceTest()
        {
            Assert.IsType<UserFavorite>(instance);  
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
        /// Test the property 'JsonData'
        /// </summary>
        [Fact]
        public void JsonDataTest()
        {
            // TODO unit test for the property 'JsonData'
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

