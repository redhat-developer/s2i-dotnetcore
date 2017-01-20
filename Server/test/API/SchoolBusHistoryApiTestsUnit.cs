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
	public class SchoolBusHistoryApiUnitTest 
    { 
		
		private readonly SchoolBusHistoryController _SchoolBusHistoryApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusHistoryApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            SchoolBusHistoryService _service = new SchoolBusHistoryService(dbAppContext.Object);
			
                    _SchoolBusHistoryApi = new SchoolBusHistoryController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbushistoriesBulkPost
        /// </summary>
		public void TestSchoolbushistoriesBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusHistoryApiController.SchoolbushistoriesBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbushistoriesGet
        /// </summary>
		public void TestSchoolbushistoriesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusHistoryApiController.SchoolbushistoriesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbushistoriesIdDelete
        /// </summary>
		public void TestSchoolbushistoriesIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusHistoryApiController.SchoolbushistoriesIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbushistoriesIdPut
        /// </summary>
		public void TestSchoolbushistoriesIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusHistoryApiController.SchoolbushistoriesIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbushistoriesPost
        /// </summary>
		public void TestSchoolbushistoriesPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusHistoryApiController.SchoolbushistoriesPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
