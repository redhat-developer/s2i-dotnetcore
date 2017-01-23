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
    ///  Class for testing the model ContactPhone
    /// </summary>
    
    public class ContactPhoneModelTests
    {
        // TODO uncomment below to declare an instance variable for ContactPhone
        private ContactPhone instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public ContactPhoneModelTests()
        {
            instance = new ContactPhone();
        }

    
        /// <summary>
        /// Test an instance of ContactPhone
        /// </summary>
        [Fact]
        public void ContactPhoneInstanceTest()
        {
            Assert.IsType<ContactPhone>(instance);  
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
        /// Test the property 'Contact'
        /// </summary>
        [Fact]
        public void ContactTest()
        {
            // TODO unit test for the property 'Contact'
			Assert.True(true);
        }

	}
	
}

