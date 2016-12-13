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
        private SchoolBusAttachment instance;
        private SchoolBus instance_bus;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public SchoolBusAttachmentModelTests()
        {
            instance_bus = new SchoolBus(0);
            instance = new SchoolBusAttachment(0, instance_bus);
        }

    
        /// <summary>
        /// Test an instance of SchoolBusAttachment
        /// </summary>
        [Fact]
        public void SchoolBusAttachmentInstanceTest()
        {
            Assert.IsType<SchoolBusAttachment>(instance);  
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

