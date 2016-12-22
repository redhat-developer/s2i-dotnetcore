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
    ///  Class for testing the model RolePermission
    /// </summary>
    
    public class RolePermissionModelTests
    {
        // TODO uncomment below to declare an instance variable for RolePermission
        private RolePermission instance;

        /// <summary>
        /// Setup the test.
        /// </summary>        
        public RolePermissionModelTests()
        {
            instance = new RolePermission();
        }

    
        /// <summary>
        /// Test an instance of RolePermission
        /// </summary>
        [Fact]
        public void RolePermissionInstanceTest()
        {
            Assert.IsType<RolePermission>(instance);  
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
        /// Test the property 'Role'
        /// </summary>
        [Fact]
        public void RoleTest()
        {
            // TODO unit test for the property 'Role'
			Assert.True(true);
        }
        /// <summary>
        /// Test the property 'Permision'
        /// </summary>
        [Fact]
        public void PermisionTest()
        {
            // TODO unit test for the property 'Permision'
			Assert.True(true);
        }

	}
	
}

