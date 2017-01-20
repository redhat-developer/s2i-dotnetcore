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
	public class SchoolBusApiUnitTest 
    { 
		
		private readonly SchoolBusController _SchoolBusApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            SchoolBusService _service = new SchoolBusService(dbAppContext.Object);
			
                    _SchoolBusApi = new SchoolBusController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for AddBus
        /// </summary>
		public void TestAddBus()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.AddBus();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for AddSchoolBusBulk
        /// </summary>
		public void TestAddSchoolBusBulk()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.AddSchoolBusBulk();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for FindBusById
        /// </summary>
		public void TestFindBusById()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.FindBusById();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for GetAllBuses
        /// </summary>
		public void TestGetAllBuses()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.GetAllBuses();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusesIdAttachmentsGet
        /// </summary>
		public void TestSchoolbusesIdAttachmentsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.SchoolbusesIdAttachmentsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusesIdCcwdataGet
        /// </summary>
		public void TestSchoolbusesIdCcwdataGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.SchoolbusesIdCcwdataGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusesIdDelete
        /// </summary>
		public void TestSchoolbusesIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.SchoolbusesIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusesIdHistoryGet
        /// </summary>
		public void TestSchoolbusesIdHistoryGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.SchoolbusesIdHistoryGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusesIdNotesGet
        /// </summary>
		public void TestSchoolbusesIdNotesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.SchoolbusesIdNotesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusesIdPut
        /// </summary>
		public void TestSchoolbusesIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.SchoolbusesIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
