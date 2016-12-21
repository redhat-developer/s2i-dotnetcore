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
	public class NotificationApiUnitTest 
    { 
		
		private readonly NotificationApiController _NotificationApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public NotificationApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            NotificationApiService _service = new NotificationApiService(dbAppContext.Object);
			
                    _NotificationApi = new NotificationApiController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for NotficationsBulkPost
        /// </summary>
		public void TestNotficationsBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationApiController.NotficationsBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for NotficationsGet
        /// </summary>
		public void TestNotficationsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationApiController.NotficationsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for NotficationsIdDelete
        /// </summary>
		public void TestNotficationsIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationApiController.NotficationsIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for NotficationsIdGet
        /// </summary>
		public void TestNotficationsIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationApiController.NotficationsIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for NotficationsIdPut
        /// </summary>
		public void TestNotficationsIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationApiController.NotficationsIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for NotficationsPost
        /// </summary>
		public void TestNotficationsPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationApiController.NotficationsPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
