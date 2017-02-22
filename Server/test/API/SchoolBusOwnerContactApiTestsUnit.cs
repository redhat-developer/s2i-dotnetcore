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
	public class ContactApiUnitTest 
    { 
		
		private readonly ContactController _ContactApi;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public ContactApiUnitTest()
		{
            DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
            Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(null, options);

            /*

            Here you will need to mock up the context.

    ItemType fakeItem = new ItemType(...);

    Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

    dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

            */

            ContactService _service = new ContactService(dbAppContext.Object);
			
                    _ContactApi = new ContactController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for ContactsBulkPost
        /// </summary>
		public void TestContactsBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _ContactApiController.ContactsBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for ContactsIdDelete
        /// </summary>
		public void TestContactsIdDelete()
		{
			// Add test code here
			// it may look like: 
			//  var result = _ContactApiController.ContactsIdDelete();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for ContactsIdGet
        /// </summary>
		public void TestContactsIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _ContactApiController.ContactsIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for ContactsIdPut
        /// </summary>
		public void TestContactsIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _ContactApiController.ContactsIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
