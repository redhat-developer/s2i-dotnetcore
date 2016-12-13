package com.schoolbus.client.api;

import com.schoolbus.client.model.Region;
import com.schoolbus.client.model.City;
import com.schoolbus.client.model.LocalArea;
import com.schoolbus.client.model.SchoolDistrict;
import com.schoolbus.client.api.RegionsApiService;

import javax.ws.rs.*;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;
import javax.enterprise.context.RequestScoped;
import javax.inject.Inject;

import io.swagger.annotations.*;

import org.apache.cxf.jaxrs.ext.multipart.Attachment;

import java.util.List;

@Path("/")
@RequestScoped

@Api(description = "the regions API")


@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")

public class RegionsApi  {

  @Context SecurityContext securityContext;

  @Inject RegionsApiService delegate;


    @GET
    @Path("/")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns a list of regions for a given province", response = Region.class, responseContainer = "List", tags={ "SchoolDistrict",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = Region.class, responseContainer = "List") })
    public Response regionsGet() {
    	return delegate.regionsGet(securityContext);
    }

    @GET
    @Path("/{region-id}/cities")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns a list of cities for a given region", response = City.class, responseContainer = "List", tags={ "City",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = City.class, responseContainer = "List") })
    public Response regionsRegionIdCitiesGet(@ApiParam(value = "Id of Region to fetch Cities for",required=true) @PathParam("region-id") Integer regionId) {
    	return delegate.regionsRegionIdCitiesGet(regionId, securityContext);
    }

    @GET
    @Path("/{region-id}")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns a specific region", response = Region.class, tags={ "Region",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = Region.class) })
    public Response regionsRegionIdGet(@ApiParam(value = "Id of Regions to fetch",required=true) @PathParam("region-id") Integer regionId) {
    	return delegate.regionsRegionIdGet(regionId, securityContext);
    }

    @GET
    @Path("/{region-id}/localareas")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns a list of LocalAreas for a given region", response = LocalArea.class, responseContainer = "List", tags={ "LocalArea", "Region",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = LocalArea.class, responseContainer = "List") })
    public Response regionsRegionIdLocalareasGet(@ApiParam(value = "Id of Region to fetch SchoolDistricts for",required=true) @PathParam("region-id") Integer regionId) {
    	return delegate.regionsRegionIdLocalareasGet(regionId, securityContext);
    }

    @GET
    @Path("/{region-id}/schooldistricts")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns a list of SchoolDistricts for a given region", response = SchoolDistrict.class, responseContainer = "List", tags={ "SchoolDistrict" })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = SchoolDistrict.class, responseContainer = "List") })
    public Response regionsRegionIdSchooldistrictsGet(@ApiParam(value = "Id of Region to fetch SchoolDistricts for",required=true) @PathParam("region-id") Integer regionId) {
    	return delegate.regionsRegionIdSchooldistrictsGet(regionId, securityContext);
    }
}
