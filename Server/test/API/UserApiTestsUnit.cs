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
	public class UserApiUnitTest 
    { 
		
		private readonly UserController _UserApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public UserApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            UserService _service = new UserService(dbAppContext.Object);
			
                    _UserApi = new UserController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for UsersBulkPost
        /// </summary>
		public void TestUsersBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersCurrentGet
        /// </summary>
		public void TestUsersCurrentGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersCurrentGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersGet
        /// </summary>
		public void TestUsersGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersIdDelete
        /// </summary>
		public void TestUsersIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersIdFavouritesGet
        /// </summary>
		public void TestUsersIdFavouritesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersIdFavouritesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersIdGet
        /// </summary>
		public void TestUsersIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersIdGroupsGet
        /// </summary>
		public void TestUsersIdGroupsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersIdGroupsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersIdGroupsPut
        /// </summary>
		public void TestUsersIdGroupsPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersIdGroupsPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersIdNotificationGet
        /// </summary>
		public void TestUsersIdNotificationGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersIdNotificationGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersIdPermissionsGet
        /// </summary>
		public void TestUsersIdPermissionsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersIdPermissionsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersIdPut
        /// </summary>
		public void TestUsersIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersIdRolesGet
        /// </summary>
		public void TestUsersIdRolesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersIdRolesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersIdRolesPost
        /// </summary>
		public void TestUsersIdRolesPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersIdRolesPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersIdRolesPut
        /// </summary>
		public void TestUsersIdRolesPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersIdRolesPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for UsersPost
        /// </summary>
		public void TestUsersPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _UserApiController.UsersPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
