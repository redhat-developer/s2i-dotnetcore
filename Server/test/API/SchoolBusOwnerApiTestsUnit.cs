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
	public class SchoolBusOwnerApiUnitTest 
    { 
		
		private readonly SchoolBusOwnerApiController _SchoolBusOwnerApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolBusOwnerApiUnitTest()
		{			
                    Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>();
			
                    /*
			
                    Here you will need to mock up the context.
			
            ItemType fakeItem = new ItemType(...);

            Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

            dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

                    */

                    SchoolBusOwnerApiService _service = new SchoolBusOwnerApiService(dbAppContext.Object);
			
                    _SchoolBusOwnerApi = new SchoolBusOwnerApiController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for FavouritecontexttypesGet
        /// </summary>
		public void TestFavouritecontexttypesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerApiController.FavouritecontexttypesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownersBulkPost
        /// </summary>
		public void TestSchoolbusownersBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerApiController.SchoolbusownersBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownersGet
        /// </summary>
		public void TestSchoolbusownersGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerApiController.SchoolbusownersGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownersIdAttachmentsGet
        /// </summary>
		public void TestSchoolbusownersIdAttachmentsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerApiController.SchoolbusownersIdAttachmentsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownersIdContactaddressesGet
        /// </summary>
		public void TestSchoolbusownersIdContactaddressesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerApiController.SchoolbusownersIdContactaddressesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownersIdContactphonesGet
        /// </summary>
		public void TestSchoolbusownersIdContactphonesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerApiController.SchoolbusownersIdContactphonesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownersIdDelete
        /// </summary>
		public void TestSchoolbusownersIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerApiController.SchoolbusownersIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownersIdGet
        /// </summary>
		public void TestSchoolbusownersIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerApiController.SchoolbusownersIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownersIdNotesGet
        /// </summary>
		public void TestSchoolbusownersIdNotesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerApiController.SchoolbusownersIdNotesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownersIdPut
        /// </summary>
		public void TestSchoolbusownersIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerApiController.SchoolbusownersIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusownersPost
        /// </summary>
		public void TestSchoolbusownersPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolBusOwnerApiController.SchoolbusownersPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
