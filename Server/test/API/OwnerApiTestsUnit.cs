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
	public class OwnerApiUnitTest 
    { 
		
		private readonly OwnerApiController _OwnerApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public OwnerApiUnitTest()
		{			
			Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>();

            /*
			
			Here you will need to mock up the context.
			
            ItemType fakeItem = new ItemType(...);

            Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

            dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

			*/
            OwnerApiService _service = new OwnerApiService(dbAppContext.Object);
            _OwnerApi = new OwnerApiController (_service);
		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for FavoritecontexttypesGet
        /// </summary>
		public void TestFavoritecontexttypesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerApiController.FavoritecontexttypesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for OwnerOwnerIdContactaddressesGet
        /// </summary>
		public void TestOwnerOwnerIdContactaddressesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerApiController.OwnerOwnerIdContactaddressesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for OwnerOwnerIdContactphonesGet
        /// </summary>
		public void TestOwnerOwnerIdContactphonesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerApiController.OwnerOwnerIdContactphonesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for OwnerOwnerIdGet
        /// </summary>
		public void TestOwnerOwnerIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerApiController.OwnerOwnerIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for OwnerOwnerIdNotesGet
        /// </summary>
		public void TestOwnerOwnerIdNotesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerApiController.OwnerOwnerIdNotesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for SchoolbusSchoolbusIdCcwdataGet
        /// </summary>
		public void TestSchoolbusSchoolbusIdCcwdataGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerApiController.SchoolbusSchoolbusIdCcwdataGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersUserIdFavoritesGet
        /// </summary>
		public void TestUsersUserIdFavoritesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerApiController.UsersUserIdFavoritesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
