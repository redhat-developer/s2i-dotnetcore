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
	public class InspectionApiUnitTest 
    { 
		
		private readonly InspectionApiController _InspectionApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public InspectionApiUnitTest()
		{			
                    Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>();
			
                    /*
			
                    Here you will need to mock up the context.
			
            ItemType fakeItem = new ItemType(...);

            Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

            dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

                    */

                    InspectionApiService _service = new InspectionApiService(dbAppContext.Object);
			
                    _InspectionApi = new InspectionApiController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for InspectionsBulkPost
        /// </summary>
		public void TestInspectionsBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _InspectionApiController.InspectionsBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for InspectionsGet
        /// </summary>
		public void TestInspectionsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _InspectionApiController.InspectionsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for InspectionsIdDelete
        /// </summary>
		public void TestInspectionsIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _InspectionApiController.InspectionsIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for InspectionsIdGet
        /// </summary>
		public void TestInspectionsIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _InspectionApiController.InspectionsIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for InspectionsIdPut
        /// </summary>
		public void TestInspectionsIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _InspectionApiController.InspectionsIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for InspectionsPost
        /// </summary>
		public void TestInspectionsPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _InspectionApiController.InspectionsPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusIdInspectionsGet
        /// </summary>
		public void TestSchoolbusIdInspectionsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _InspectionApiController.SchoolbusIdInspectionsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
