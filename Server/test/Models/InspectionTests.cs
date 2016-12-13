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
    ///  Class for testing the model Inspection
    /// </summary>
    
    public class InspectionModelTests
    {
        // TODO uncomment below to declare an instance variable for Inspection
        private Inspection instance;
        private SchoolBus instance_schoolBus;
        private User instance_user;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public InspectionModelTests()
        {
            instance_schoolBus = new SchoolBus(0);
            instance_user = new User(0);
            instance = new Inspection(0, instance_schoolBus, instance_user);
        }

    
        /// <summary>
        /// Test an instance of Inspection
        /// </summary>
        [Fact]
        public void InspectionInstanceTest()
        {
            Assert.IsType<Inspection>(instance);  
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
        /// <summary>
        /// Test the property 'Inspector'
        /// </summary>
        [Fact]
        public void InspectorTest()
        {
            // TODO unit test for the property 'Inspector'
			Assert.True(true);
        }

	}
	
}

