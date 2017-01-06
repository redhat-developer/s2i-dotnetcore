/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
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
    ///  Class for testing the model ServiceArea
    /// </summary>
    
    public class ServiceAreaModelTests
    {
        // TODO uncomment below to declare an instance variable for ServiceArea
        private ServiceArea instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public ServiceAreaModelTests()
        {
            instance = new ServiceArea();
        }

    
        /// <summary>
        /// Test an instance of ServiceArea
        /// </summary>
        [Fact]
        public void ServiceAreaInstanceTest()
        {
            Assert.IsType<ServiceArea>(instance);  
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
        /// Test the property 'MinistryServiceAreaID'
        /// </summary>
        [Fact]
        public void MinistryServiceAreaIDTest()
        {
            // TODO unit test for the property 'MinistryServiceAreaID'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Name'
        /// </summary>
        [Fact]
        public void NameTest()
        {
            // TODO unit test for the property 'Name'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'District'
        /// </summary>
        [Fact]
        public void DistrictTest()
        {
            // TODO unit test for the property 'District'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'StartDate'
        /// </summary>
        [Fact]
        public void StartDateTest()
        {
            // TODO unit test for the property 'StartDate'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'EndDate'
        /// </summary>
        [Fact]
        public void EndDateTest()
        {
            // TODO unit test for the property 'EndDate'
			Assert.True(true);
        }

	}
	
}

