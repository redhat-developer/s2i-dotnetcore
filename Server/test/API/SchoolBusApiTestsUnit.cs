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

namespace SchoolBusAPI.Test
{
	public class SchoolBusApiUnitTest 
    { 
		
		private readonly SchoolBusApiController _SchoolBusApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusApiUnitTest()
		{			
			Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>();
			
			/*
			
			Here you will need to mock up the context.
			
            ItemType fakeItem = new ItemType(...);

            Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

            dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

			*/
			
            _SchoolBusApi = new SchoolBusApiController (dbAppContext.Object);
		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for OwnerOwnerIdAttachmentsGet
        /// </summary>
		public void TestOwnerOwnerIdAttachmentsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.OwnerOwnerIdAttachmentsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusSchoolbusIdAttachmentsGet
        /// </summary>
		public void TestSchoolbusSchoolbusIdAttachmentsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.SchoolbusSchoolbusIdAttachmentsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusSchoolbusIdHistoryGet
        /// </summary>
		public void TestSchoolbusSchoolbusIdHistoryGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.SchoolbusSchoolbusIdHistoryGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusesSchoolbusIdGet
        /// </summary>
		public void TestSchoolbusesSchoolbusIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.SchoolbusesSchoolbusIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusesSchoolbusIdNotesGet
        /// </summary>
		public void TestSchoolbusesSchoolbusIdNotesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusApiController.SchoolbusesSchoolbusIdNotesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
