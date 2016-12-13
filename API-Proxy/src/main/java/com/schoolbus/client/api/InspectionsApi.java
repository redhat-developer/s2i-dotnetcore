package com.schoolbus.client.api;

import com.schoolbus.client.model.Inspection;
import com.schoolbus.client.api.InspectionsApiService;

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

@Api(description = "the inspections API")


@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")

public class InspectionsApi  {

  @Context SecurityContext securityContext;

  @Inject InspectionsApiService delegate;


    @GET
    
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "", response = Inspection.class, responseContainer = "List", tags={ "Inspection",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = Inspection.class, responseContainer = "List"),
        @ApiResponse(code = 404, message = "Inspection not found", response = Inspection.class, responseContainer = "List") })
    public Response inspectionsGet() {
    	return delegate.inspectionsGet(securityContext);
    }

    @GET
    @Path("/{inspection-id}")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "", response = Inspection.class, tags={ "Inspection" })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = Inspection.class),
        @ApiResponse(code = 404, message = "Inspection not found", response = Inspection.class) })
    public Response inspectionsInspectionIdGet(@ApiParam(value = "Id of Inspection to fetch",required=true) @PathParam("inspection-id") Integer inspectionId) {
    	return delegate.inspectionsInspectionIdGet(inspectionId, securityContext);
    }
}
