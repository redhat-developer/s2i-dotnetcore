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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using SchoolBusAPI;
using SchoolBusAPI.Models;
using System.Reflection;

namespace SchoolBusAPI.Test
{
    /// <summary>
    ///  Class for testing the model GroupMembership
    /// </summary>
    
    public class GroupMembershipModelTests
    {
        // TODO uncomment below to declare an instance variable for GroupMembership
        private GroupMembership instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public GroupMembershipModelTests()
        {
            instance = new GroupMembership();
        }

    
        /// <summary>
        /// Test an instance of GroupMembership
        /// </summary>
        [Fact]
        public void GroupMembershipInstanceTest()
        {
            Assert.IsType<GroupMembership>(instance);  
        }

        /// <summary>
        /// Test the property 'Id'
        /// </summary>
        [Fact]
        public void IdTest()
        {
            // TODO unit test for the property 'Id'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Active'
        /// </summary>
        [Fact]
        public void ActiveTest()
        {
            // TODO unit test for the property 'Active'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Group'
        /// </summary>
        [Fact]
        public void GroupTest()
        {
            // TODO unit test for the property 'Group'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'User'
        /// </summary>
        [Fact]
        public void UserTest()
        {
            // TODO unit test for the property 'User'
			Assert.True(true);
        }

	}
	
}

