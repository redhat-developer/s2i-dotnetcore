/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
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
	public class DistrictApiUnitTest 
    { 
		
		private readonly DistrictController _DistrictApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public DistrictApiUnitTest()
		{			
                    DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
                    Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(null, options);
			
                    /*
			
                    Here you will need to mock up the context.
			
            ItemType fakeItem = new ItemType(...);

            Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

            dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

                    */

                    DistrictService _service = new DistrictService(dbAppContext.Object);
			
                    _DistrictApi = new DistrictController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for DistrictsBulkPost
        /// </summary>
		public void TestDistrictsBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _DistrictApiController.DistrictsBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for DistrictsGet
        /// </summary>
		public void TestDistrictsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _DistrictApiController.DistrictsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for DistrictsIdDeletePost
        /// </summary>
		public void TestDistrictsIdDeletePost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _DistrictApiController.DistrictsIdDeletePost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for DistrictsIdGet
        /// </summary>
		public void TestDistrictsIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _DistrictApiController.DistrictsIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for DistrictsIdPut
        /// </summary>
		public void TestDistrictsIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _DistrictApiController.DistrictsIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for DistrictsIdServiceareasGet
        /// </summary>
		public void TestDistrictsIdServiceareasGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _DistrictApiController.DistrictsIdServiceareasGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for DistrictsPost
        /// </summary>
		public void TestDistrictsPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _DistrictApiController.DistrictsPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for ServiceareasBulkPost
        /// </summary>
		public void TestServiceareasBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _DistrictApiController.ServiceareasBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
