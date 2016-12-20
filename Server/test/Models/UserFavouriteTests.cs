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
    ///  Class for testing the model UserFavourite
    /// </summary>
    
    public class UserFavouriteModelTests
    {
        // TODO uncomment below to declare an instance variable for UserFavourite
        private UserFavourite instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public UserFavouriteModelTests()
        {
            instance = new UserFavourite();
        }

    
        /// <summary>
        /// Test an instance of UserFavourite
        /// </summary>
        [Fact]
        public void UserFavouriteInstanceTest()
        {
            Assert.IsType<UserFavourite>(instance);  
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
        /// Test the property 'Value'
        /// </summary>
        [Fact]
        public void ValueTest()
        {
            // TODO unit test for the property 'Value'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'IsDefault'
        /// </summary>
        [Fact]
        public void IsDefaultTest()
        {
            // TODO unit test for the property 'IsDefault'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'FavouriteContextType'
        /// </summary>
        [Fact]
        public void FavouriteContextTypeTest()
        {
            // TODO unit test for the property 'FavouriteContextType'
			Assert.True(true);
        }

	}
	
}

