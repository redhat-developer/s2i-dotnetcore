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
	public class SchoolBusNoteApiUnitTest 
    { 
		
		private readonly SchoolBusNoteApiController _SchoolBusNoteApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusNoteApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            SchoolBusNoteApiService _service = new SchoolBusNoteApiService(dbAppContext.Object);
			
                    _SchoolBusNoteApi = new SchoolBusNoteApiController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusnotesBulkPost
        /// </summary>
		public void TestSchoolbusnotesBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusNoteApiController.SchoolbusnotesBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusnotesGet
        /// </summary>
		public void TestSchoolbusnotesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusNoteApiController.SchoolbusnotesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusnotesIdDelete
        /// </summary>
		public void TestSchoolbusnotesIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusNoteApiController.SchoolbusnotesIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusnotesIdGet
        /// </summary>
		public void TestSchoolbusnotesIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusNoteApiController.SchoolbusnotesIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusnotesIdPut
        /// </summary>
		public void TestSchoolbusnotesIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusNoteApiController.SchoolbusnotesIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusnotesPost
        /// </summary>
		public void TestSchoolbusnotesPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusNoteApiController.SchoolbusnotesPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
