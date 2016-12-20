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
                    Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>();
			
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
        /// Unit test for NotficationeventsBulkPost
        /// </summary>
		public void TestNotficationeventsBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationEventApiController.NotficationeventsBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for NotficationeventsGet
        /// </summary>
		public void TestNotficationeventsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationEventApiController.NotficationeventsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for NotficationeventsIdDelete
        /// </summary>
		public void TestNotficationeventsIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationEventApiController.NotficationeventsIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for NotficationeventsIdGet
        /// </summary>
		public void TestNotficationeventsIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationEventApiController.NotficationeventsIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for NotficationeventsIdPut
        /// </summary>
		public void TestNotficationeventsIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationEventApiController.NotficationeventsIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for NotficationeventsPost
        /// </summary>
		public void TestNotficationeventsPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _NotificationEventApiController.NotficationeventsPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
