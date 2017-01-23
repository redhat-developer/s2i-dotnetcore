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
    ///  Class for testing the model SchoolBusAttachment
    /// </summary>
    
    public class SchoolBusAttachmentModelTests
    {
        // TODO uncomment below to declare an instance variable for SchoolBusAttachment
        private Attachment instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public SchoolBusAttachmentModelTests()
        {
            instance = new Attachment();
        }

    
        /// <summary>
        /// Test an instance of SchoolBusAttachment
        /// </summary>
        [Fact]
        public void SchoolBusAttachmentInstanceTest()
        {
            Assert.IsType<Attachment>(instance);  
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
        /// Test the property 'InternalFileName'
        /// </summary>
        [Fact]
        public void InternalFileNameTest()
        {
            // TODO unit test for the property 'InternalFileName'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'ExternalFileName'
        /// </summary>
        [Fact]
        public void ExternalFileNameTest()
        {
            // TODO unit test for the property 'ExternalFileName'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'SchoolBus'
        /// </summary>
        [Fact]
        public void SchoolBusTest()
        {
            // TODO unit test for the property 'SchoolBus'
			Assert.True(true);
        }

	}
	
}

