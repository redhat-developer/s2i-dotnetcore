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
    ///  Class for testing the model ContactAddress
    /// </summary>
    
    public class ContactAddressModelTests
    {
        // TODO uncomment below to declare an instance variable for ContactAddress
        private ContactAddress instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public ContactAddressModelTests()
        {
            instance = new ContactAddress();
        }

    
        /// <summary>
        /// Test an instance of ContactAddress
        /// </summary>
        [Fact]
        public void ContactAddressInstanceTest()
        {
            Assert.IsType<ContactAddress>(instance);  
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

