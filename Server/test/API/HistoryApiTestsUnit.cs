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
	public class HistoryApiUnitTest 
    { 
		
		private readonly HistoryController _HistoryApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public HistoryApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            HistoryService _service = new HistoryService(dbAppContext.Object);
			
                    _HistoryApi = new HistoryController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for HistoryBulkPost
        /// </summary>
		public void TestHistoryBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _HistoryApiController.HistoryBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for HistoryGet
        /// </summary>
		public void TestHistoryGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _HistoryApiController.HistoryGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for HistoryIdDelete
        /// </summary>
		public void TestHistoryIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _HistoryApiController.HistoryIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for HistoryIdGet
        /// </summary>
		public void TestHistoryIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _HistoryApiController.HistoryIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for HistoryIdPut
        /// </summary>
		public void TestHistoryIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _HistoryApiController.HistoryIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for HistoryPost
        /// </summary>
		public void TestHistoryPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _HistoryApiController.HistoryPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
