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
	public class SchoolBusOwnerHistoryApiUnitTest 
    { 
		
		private readonly SchoolBusOwnerHistoryController _SchoolBusOwnerHistoryApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusOwnerHistoryApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            SchoolBusOwnerHistoryService _service = new SchoolBusOwnerHistoryService(dbAppContext.Object);
			
                    _SchoolBusOwnerHistoryApi = new SchoolBusOwnerHistoryController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownerhistoryBulkPost
        /// </summary>
		public void TestSchoolbusownerhistoryBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerHistoryApiController.SchoolbusownerhistoryBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownerhistoryGet
        /// </summary>
		public void TestSchoolbusownerhistoryGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerHistoryApiController.SchoolbusownerhistoryGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownerhistoryIdDelete
        /// </summary>
		public void TestSchoolbusownerhistoryIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerHistoryApiController.SchoolbusownerhistoryIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownerhistoryIdGet
        /// </summary>
		public void TestSchoolbusownerhistoryIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerHistoryApiController.SchoolbusownerhistoryIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownerhistoryIdPut
        /// </summary>
		public void TestSchoolbusownerhistoryIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerHistoryApiController.SchoolbusownerhistoryIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownerhistoryPost
        /// </summary>
		public void TestSchoolbusownerhistoryPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerHistoryApiController.SchoolbusownerhistoryPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
