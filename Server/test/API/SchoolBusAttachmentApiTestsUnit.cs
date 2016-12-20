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
	public class SchoolBusAttachmentApiUnitTest 
    { 
		
		private readonly SchoolBusAttachmentApiController _SchoolBusAttachmentApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusAttachmentApiUnitTest()
		{			
                    Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>();
			
                    /*
			
                    Here you will need to mock up the context.
			
            ItemType fakeItem = new ItemType(...);

            Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

            dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

                    */

                    SchoolBusAttachmentApiService _service = new SchoolBusAttachmentApiService(dbAppContext.Object);
			
                    _SchoolBusAttachmentApi = new SchoolBusAttachmentApiController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusattachmentsBulkPost
        /// </summary>
		public void TestSchoolbusattachmentsBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusAttachmentApiController.SchoolbusattachmentsBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusattachmentsGet
        /// </summary>
		public void TestSchoolbusattachmentsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusAttachmentApiController.SchoolbusattachmentsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusattachmentsIdDelete
        /// </summary>
		public void TestSchoolbusattachmentsIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusAttachmentApiController.SchoolbusattachmentsIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusattachmentsIdGet
        /// </summary>
		public void TestSchoolbusattachmentsIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusAttachmentApiController.SchoolbusattachmentsIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusattachmentsIdPut
        /// </summary>
		public void TestSchoolbusattachmentsIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusAttachmentApiController.SchoolbusattachmentsIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusattachmentsPost
        /// </summary>
		public void TestSchoolbusattachmentsPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusAttachmentApiController.SchoolbusattachmentsPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbushistoriesIdGet
        /// </summary>
		public void TestSchoolbushistoriesIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusAttachmentApiController.SchoolbushistoriesIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
