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
    ///  Class for testing the model OwnerContact
    /// </summary>
    
    public class OwnerContactModelTests
    {
        // TODO uncomment below to declare an instance variable for OwnerContact
        private OwnerContact instance;
        private Owner instance_owner;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public OwnerContactModelTests()
        {
            instance_owner = new Owner(0);
            instance = new OwnerContact(0,instance_owner);
        }

    
        /// <summary>
        /// Test an instance of OwnerContact
        /// </summary>
        [Fact]
        public void OwnerContactInstanceTest()
        {
            Assert.IsType<OwnerContact>(instance);  
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
        /// Test the property 'Owner'
        /// </summary>
        [Fact]
        public void OwnerTest()
        {
            // TODO unit test for the property 'Owner'
			Assert.True(true);
        }

	}
	
}

