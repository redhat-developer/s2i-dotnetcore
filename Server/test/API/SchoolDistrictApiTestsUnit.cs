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
	public class SchoolDistrictApiUnitTest 
    { 
		
		private readonly SchoolDistrictApiController _SchoolDistrictApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public SchoolDistrictApiUnitTest()
		{			
			Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>();
			
			/*
			
			Here you will need to mock up the context.
			
            ItemType fakeItem = new ItemType(...);

            Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

            dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

			*/
			
            _SchoolDistrictApi = new SchoolDistrictApiController (dbAppContext.Object);
		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for RegionsGet
        /// </summary>
		public void TestRegionsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolDistrictApiController.RegionsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for RegionsRegionIdSchooldistrictsGet
        /// </summary>
		public void TestRegionsRegionIdSchooldistrictsGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _SchoolDistrictApiController.RegionsRegionIdSchooldistrictsGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
