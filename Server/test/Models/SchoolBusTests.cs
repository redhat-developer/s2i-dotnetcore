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
    ///  Class for testing the model SchoolBus
    /// </summary>
    
    public class SchoolBusModelTests
    {
        // TODO uncomment below to declare an instance variable for SchoolBus
        private SchoolBus instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public SchoolBusModelTests()
        {
            instance = new SchoolBus();
        }

    
        /// <summary>
        /// Test an instance of SchoolBus
        /// </summary>
        [Fact]
        public void SchoolBusInstanceTest()
        {
            Assert.IsType<SchoolBus>(instance);  
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
        /// <summary>
        /// Test the property 'IsActive'
        /// </summary>
        [Fact]
        public void IsActiveTest()
        {
            // TODO unit test for the property 'IsActive'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'IsOutOfProvince'
        /// </summary>
        [Fact]
        public void IsOutOfProvinceTest()
        {
            // TODO unit test for the property 'IsOutOfProvince'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'NextInspection'
        /// </summary>
        [Fact]
        public void NextInspectionTest()
        {
            // TODO unit test for the property 'NextInspection'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'CRNO'
        /// </summary>
        [Fact]
        public void CRNOTest()
        {
            // TODO unit test for the property 'CRNO'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'NameOfIndependentSchool'
        /// </summary>
        [Fact]
        public void NameOfIndependentSchoolTest()
        {
            // TODO unit test for the property 'NameOfIndependentSchool'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'CCWData'
        /// </summary>
        [Fact]
        public void CCWDataTest()
        {
            // TODO unit test for the property 'CCWData'
			Assert.True(true);
        }

	}
	
}

