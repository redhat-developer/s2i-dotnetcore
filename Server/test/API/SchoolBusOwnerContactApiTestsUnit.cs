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
	public class SchoolBusOwnerContactApiUnitTest 
    { 
		
		private readonly SchoolBusOwnerContactApiController _SchoolBusOwnerContactApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusOwnerContactApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            SchoolBusOwnerContactApiService _service = new SchoolBusOwnerContactApiService(dbAppContext.Object);
			
                    _SchoolBusOwnerContactApi = new SchoolBusOwnerContactApiController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownercontactsBulkPost
        /// </summary>
		public void TestSchoolbusownercontactsBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerContactApiController.SchoolbusownercontactsBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownercontactsIdDelete
        /// </summary>
		public void TestSchoolbusownercontactsIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerContactApiController.SchoolbusownercontactsIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownercontactsIdGet
        /// </summary>
		public void TestSchoolbusownercontactsIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerContactApiController.SchoolbusownercontactsIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownercontactsIdPut
        /// </summary>
		public void TestSchoolbusownercontactsIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerContactApiController.SchoolbusownercontactsIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
