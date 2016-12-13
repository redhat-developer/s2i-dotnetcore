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
    ///  Class for testing the model OwnerAttachments
    /// </summary>
    
    public class OwnerAttachmentsModelTests
    {
        // TODO uncomment below to declare an instance variable for OwnerAttachments
        private OwnerAttachments instance;
        private Owner instance_owner;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public OwnerAttachmentsModelTests()
        {
            instance_owner = new Owner(0);
            instance = new OwnerAttachments(0,instance_owner);
        }

    
        /// <summary>
        /// Test an instance of OwnerAttachments
        /// </summary>
        [Fact]
        public void OwnerAttachmentsInstanceTest()
        {
            Assert.IsType<OwnerAttachments>(instance);  
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

