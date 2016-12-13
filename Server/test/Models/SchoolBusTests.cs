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
            instance = new SchoolBus(0);
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
        /// Test the property 'Owner'
        /// </summary>
        [Fact]
        public void OwnerTest()
        {
            // TODO unit test for the property 'Owner'
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
        /// Test the property 'LesseeNumber'
        /// </summary>
        [Fact]
        public void LesseeNumberTest()
        {
            // TODO unit test for the property 'LesseeNumber'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'LicenseExpiryDate'
        /// </summary>
        [Fact]
        public void LicenseExpiryDateTest()
        {
            // TODO unit test for the property 'LicenseExpiryDate'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'PermitExpiryDate'
        /// </summary>
        [Fact]
        public void PermitExpiryDateTest()
        {
            // TODO unit test for the property 'PermitExpiryDate'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'NextInspectionDate'
        /// </summary>
        [Fact]
        public void NextInspectionDateTest()
        {
            // TODO unit test for the property 'NextInspectionDate'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'ManYear'
        /// </summary>
        [Fact]
        public void ManYearTest()
        {
            // TODO unit test for the property 'ManYear'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'SBCap'
        /// </summary>
        [Fact]
        public void SBCapTest()
        {
            // TODO unit test for the property 'SBCap'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'MCCap'
        /// </summary>
        [Fact]
        public void MCCapTest()
        {
            // TODO unit test for the property 'MCCap'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'WCCap'
        /// </summary>
        [Fact]
        public void WCCapTest()
        {
            // TODO unit test for the property 'WCCap'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'LastUpdate'
        /// </summary>
        [Fact]
        public void LastUpdateTest()
        {
            // TODO unit test for the property 'LastUpdate'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Plate'
        /// </summary>
        [Fact]
        public void PlateTest()
        {
            // TODO unit test for the property 'Plate'
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

