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
	public class NotificationEventApiUnitTest 
    { 
		
		private readonly NotificationEventApiController _NotificationEventApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public NotificationEventApiUnitTest()
		{

            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);
			
                    /*
			
                    Here you will need to mock up the context.
			
            ItemType fakeItem = new ItemType(...);

            Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

            dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

                    */

                    NotificationEventApiService _service = new NotificationEventApiService(dbAppContext.Object);
			
                    _NotificationEventApi = new NotificationEventApiController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for notificationeventsBulkPost
        /// </summary>
		public void TestnotificationeventsBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationEventApiController.notificationeventsBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for notificationeventsGet
        /// </summary>
		public void TestnotificationeventsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationEventApiController.notificationeventsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for notificationeventsIdDelete
        /// </summary>
		public void TestnotificationeventsIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationEventApiController.notificationeventsIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for notificationeventsIdGet
        /// </summary>
		public void TestnotificationeventsIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationEventApiController.notificationeventsIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for notificationeventsIdPut
        /// </summary>
		public void TestnotificationeventsIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationEventApiController.notificationeventsIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for notificationeventsPost
        /// </summary>
		public void TestnotificationeventsPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationEventApiController.notificationeventsPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
