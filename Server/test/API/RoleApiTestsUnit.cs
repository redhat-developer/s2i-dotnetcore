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
	public class RoleApiUnitTest 
    { 
		
		private readonly RoleController _RoleApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public RoleApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(null, options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            RoleService _service = new RoleService(dbAppContext.Object);
			
                    _RoleApi = new RoleController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for RolesGet
        /// </summary>
		public void TestRolesGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _RoleApiController.RolesGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for RolesIdDelete
        /// </summary>
		public void TestRolesIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _RoleApiController.RolesIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for RolesIdGet
        /// </summary>
		public void TestRolesIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _RoleApiController.RolesIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for RolesIdPermissionsGet
        /// </summary>
		public void TestRolesIdPermissionsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _RoleApiController.RolesIdPermissionsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for RolesIdPermissionsPut
        /// </summary>
		public void TestRolesIdPermissionsPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _RoleApiController.RolesIdPermissionsPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for RolesIdPut
        /// </summary>
		public void TestRolesIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _RoleApiController.RolesIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for RolesIdUsersGet
        /// </summary>
		public void TestRolesIdUsersGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _RoleApiController.RolesIdUsersGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for RolesIdUsersPut
        /// </summary>
		public void TestRolesIdUsersPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _RoleApiController.RolesIdUsersPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for RolesPost
        /// </summary>
		public void TestRolesPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _RoleApiController.RolesPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
