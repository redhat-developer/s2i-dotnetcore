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
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Moq;
using SchoolBusAPI;
using SchoolBusAPI.Models;
using SchoolBusAPI.Controllers;
using SchoolBusAPI.Services.Impl;

namespace SchoolBusAPI.Test
{
	public class CityApiUnitTest 
    { 
		
		private readonly CityController _CityApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public CityApiUnitTest()
		{			
                    DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
                    Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);
			
                    /*
			
                    Here you will need to mock up the context.
			
            ItemType fakeItem = new ItemType(...);

            Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

            dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

                    */

                    CityService _service = new CityService(dbAppContext.Object);
			
                    _CityApi = new CityController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for CitiesBulkPost
        /// </summary>
		public void TestCitiesBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _CityApiController.CitiesBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for CitiesGet
        /// </summary>
		public void TestCitiesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _CityApiController.CitiesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for CitiesIdDeletePost
        /// </summary>
		public void TestCitiesIdDeletePost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _CityApiController.CitiesIdDeletePost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for CitiesIdGet
        /// </summary>
		public void TestCitiesIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _CityApiController.CitiesIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for CitiesIdPut
        /// </summary>
		public void TestCitiesIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _CityApiController.CitiesIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for CitiesPost
        /// </summary>
		public void TestCitiesPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _CityApiController.CitiesPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
