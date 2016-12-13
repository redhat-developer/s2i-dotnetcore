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
    ///  Class for testing the model OwnerNotes
    /// </summary>
    
    public class OwnerNotesModelTests
    {
        // TODO uncomment below to declare an instance variable for OwnerNotes
        private OwnerNotes instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public OwnerNotesModelTests()
        {
            instance = new OwnerNotes(0);
        }

    
        /// <summary>
        /// Test an instance of OwnerNotes
        /// </summary>
        [Fact]
        public void OwnerNotesInstanceTest()
        {
            Assert.IsType<OwnerNotes>(instance);  
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

