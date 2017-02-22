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
	public class AttachmentApiUnitTest 
    { 
		
		private readonly AttachmentController _AttachmentApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public AttachmentApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(null, options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            AttachmentService _service = new AttachmentService(dbAppContext.Object);
			
                    _AttachmentApi = new AttachmentController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for AttachmentsBulkPost
        /// </summary>
		public void TestAttachmentsBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _AttachmentApiController.AttachmentsBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for AttachmentsGet
        /// </summary>
		public void TestAttachmentsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _AttachmentApiController.AttachmentsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for AttachmentsIdDelete
        /// </summary>
		public void TestAttachmentsIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _AttachmentApiController.AttachmentsIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for AttachmentsIdGet
        /// </summary>
		public void TestAttachmentsIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _AttachmentApiController.AttachmentsIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for AttachmentsIdPut
        /// </summary>
		public void TestAttachmentsIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _AttachmentApiController.AttachmentsIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for AttachmentsPost
        /// </summary>
		public void TestAttachmentsPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _AttachmentApiController.AttachmentsPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
