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
    ///  Class for testing the model SchoolBusNote
    /// </summary>
    
    public class SchoolBusNoteModelTests
    {
        // TODO uncomment below to declare an instance variable for SchoolBusNote
        private SchoolBusNote instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public SchoolBusNoteModelTests()
        {
            instance = new SchoolBusNote(0);
        }

    
        /// <summary>
        /// Test an instance of SchoolBusNote
        /// </summary>
        [Fact]
        public void SchoolBusNoteInstanceTest()
        {
            Assert.IsType<SchoolBusNote>(instance);  
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

