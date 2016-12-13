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
	public class LocalAreaApiUnitTest 
    { 
		
		private readonly LocalAreaApiController _LocalAreaApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public LocalAreaApiUnitTest()
		{			
			Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>();
			
			/*
			
			Here you will need to mock up the context.
			
            ItemType fakeItem = new ItemType(...);

            Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

            dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

			*/
			
            _LocalAreaApi = new LocalAreaApiController (dbAppContext.Object);
		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for RegionsRegionIdLocalareasGet
        /// </summary>
		public void TestRegionsRegionIdLocalareasGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _LocalAreaApiController.RegionsRegionIdLocalareasGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
