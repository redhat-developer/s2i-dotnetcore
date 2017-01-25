/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using Xunit;

namespace SchoolBusAPI.Test
{
    public class SchoolDistrictApiIntegrationTest : ApiIntegrationTestBase
    { 
		[Fact]
		/// <summary>
        /// Integration test for RegionsIdSchooldistrictsGet
        /// </summary>
		public async void TestSchooldistricts()
		{
			var response = await _client.GetAsync("/api/schooldistricts");
            response.EnsureSuccessStatusCode();
			
			// update this to test the API.
			Assert.True(true);
		}		
        
    }
}
