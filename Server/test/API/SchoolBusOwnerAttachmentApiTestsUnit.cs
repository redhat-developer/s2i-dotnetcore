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
	public class SchoolBusOwnerAttachmentApiUnitTest 
    { 
		
		private readonly SchoolBusOwnerAttachmentApiController _SchoolBusOwnerAttachmentApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusOwnerAttachmentApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            SchoolBusOwnerAttachmentApiService _service = new SchoolBusOwnerAttachmentApiService(dbAppContext.Object);
			
                    _SchoolBusOwnerAttachmentApi = new SchoolBusOwnerAttachmentApiController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownerattachmentsBulkPost
        /// </summary>
		public void TestSchoolbusownerattachmentsBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerAttachmentApiController.SchoolbusownerattachmentsBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownerattachmentsGet
        /// </summary>
		public void TestSchoolbusownerattachmentsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerAttachmentApiController.SchoolbusownerattachmentsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownerattachmentsIdDelete
        /// </summary>
		public void TestSchoolbusownerattachmentsIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerAttachmentApiController.SchoolbusownerattachmentsIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownerattachmentsIdGet
        /// </summary>
		public void TestSchoolbusownerattachmentsIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerAttachmentApiController.SchoolbusownerattachmentsIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownerattachmentsIdPut
        /// </summary>
		public void TestSchoolbusownerattachmentsIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerAttachmentApiController.SchoolbusownerattachmentsIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownerattachmentsPost
        /// </summary>
		public void TestSchoolbusownerattachmentsPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerAttachmentApiController.SchoolbusownerattachmentsPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
