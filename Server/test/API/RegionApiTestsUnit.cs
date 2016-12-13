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
	public class RegionApiUnitTest 
    { 
		
		private readonly RegionApiController _RegionApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public RegionApiUnitTest()
		{			
			Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>();
			
			/*
			
			Here you will need to mock up the context.
			
            ItemType fakeItem = new ItemType(...);

            Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

            dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

			*/
			
            _RegionApi = new RegionApiController (dbAppContext.Object);
		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for RegionsRegionIdGet
        /// </summary>
		public void TestRegionsRegionIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _RegionApiController.RegionsRegionIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for RegionsRegionIdLocalareasGet
        /// </summary>
		public void TestRegionsRegionIdLocalareasGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _RegionApiController.RegionsRegionIdLocalareasGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
