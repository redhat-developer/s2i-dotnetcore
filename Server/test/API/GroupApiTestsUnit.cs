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
	public class GroupApiUnitTest 
    { 
		
		private readonly GroupController _GroupApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public GroupApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            GroupService _service = new GroupService(dbAppContext.Object);
			
                    _GroupApi = new GroupController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for GroupsGet
        /// </summary>
		public void TestGroupsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _GroupApiController.GroupsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
