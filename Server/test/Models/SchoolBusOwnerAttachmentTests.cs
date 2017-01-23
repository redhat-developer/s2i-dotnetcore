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
    ///  Class for testing the model Attachment
    /// </summary>
    
    public class AttachmentModelTests
    {
        // TODO uncomment below to declare an instance variable for Attachment
        private Attachment instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public AttachmentModelTests()
        {
            instance = new Attachment();
        }

    
        /// <summary>
        /// Test an instance of Attachment
        /// </summary>
        [Fact]
        public void AttachmentInstanceTest()
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

