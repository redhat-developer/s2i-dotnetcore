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
    ///  Class for testing the model OwnerContactPhone
    /// </summary>
    
    public class OwnerContactPhoneModelTests
    {
        // TODO uncomment below to declare an instance variable for OwnerContactPhone
        private OwnerContactPhone instance;
        private OwnerContact instance_owner_contact;
        private Owner instance_owner;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public OwnerContactPhoneModelTests()
        {
            instance_owner = new Owner(0);
            instance_owner_contact = new OwnerContact(0, instance_owner);
            instance = new OwnerContactPhone(0, instance_owner_contact);
        }
    
        /// <summary>
        /// Test an instance of OwnerContactPhone
        /// </summary>
        [Fact]
        public void OwnerContactPhoneInstanceTest()
        {
            Assert.IsType<OwnerContactPhone>(instance);  
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
        /// Test the property 'OwnerContact'
        /// </summary>
        [Fact]
        public void OwnerContactTest()
        {
            // TODO unit test for the property 'OwnerContact'
			Assert.True(true);
        }

	}
	
}

