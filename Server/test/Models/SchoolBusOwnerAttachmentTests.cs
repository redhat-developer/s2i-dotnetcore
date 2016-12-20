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
    ///  Class for testing the model SchoolBusOwnerAttachment
    /// </summary>
    
    public class SchoolBusOwnerAttachmentModelTests
    {
        // TODO uncomment below to declare an instance variable for SchoolBusOwnerAttachment
        private SchoolBusOwnerAttachment instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public SchoolBusOwnerAttachmentModelTests()
        {
            instance = new SchoolBusOwnerAttachment();
        }

    
        /// <summary>
        /// Test an instance of SchoolBusOwnerAttachment
        /// </summary>
        [Fact]
        public void SchoolBusOwnerAttachmentInstanceTest()
        {
            Assert.IsType<SchoolBusOwnerAttachment>(instance);  
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
        /// Test the property 'SchoolBusOwner'
        /// </summary>
        [Fact]
        public void SchoolBusOwnerTest()
        {
            // TODO unit test for the property 'SchoolBusOwner'
			Assert.True(true);
        }

	}
	
}

