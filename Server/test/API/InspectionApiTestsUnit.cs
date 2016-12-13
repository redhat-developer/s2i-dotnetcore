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
			
            _InspectionApi = new InspectionApiController (dbAppContext.Object);
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
        /// Unit test for InspectionsGet_0
        /// </summary>
		public void TestInspectionsGet_0()
		{
			// Add test code here
			// it may look like: 
			//  var result = _InspectionApiController.InspectionsGet_0();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for InspectionsInspectionIdGet
        /// </summary>
		public void TestInspectionsInspectionIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _InspectionApiController.InspectionsInspectionIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
