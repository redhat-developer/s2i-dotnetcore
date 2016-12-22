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
	public class SchoolBusOwnerNoteApiUnitTest 
    { 
		
		private readonly SchoolBusOwnerNoteApiController _SchoolBusOwnerNoteApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusOwnerNoteApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            SchoolBusOwnerNoteApiService _service = new SchoolBusOwnerNoteApiService(dbAppContext.Object);
			
                    _SchoolBusOwnerNoteApi = new SchoolBusOwnerNoteApiController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownernotesBulkPost
        /// </summary>
		public void TestSchoolbusownernotesBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerNoteApiController.SchoolbusownernotesBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownernotesGet
        /// </summary>
		public void TestSchoolbusownernotesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerNoteApiController.SchoolbusownernotesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownernotesIdDelete
        /// </summary>
		public void TestSchoolbusownernotesIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerNoteApiController.SchoolbusownernotesIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownernotesIdGet
        /// </summary>
		public void TestSchoolbusownernotesIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerNoteApiController.SchoolbusownernotesIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownernotesIdPut
        /// </summary>
		public void TestSchoolbusownernotesIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerNoteApiController.SchoolbusownernotesIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownernotesPost
        /// </summary>
		public void TestSchoolbusownernotesPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerNoteApiController.SchoolbusownernotesPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
