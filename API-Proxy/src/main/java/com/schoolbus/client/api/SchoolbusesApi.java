package com.schoolbus.client.api;

import com.schoolbus.client.model.Inspection;
import com.schoolbus.client.model.SchoolBus;
import com.schoolbus.client.model.SchoolBusNote;
import com.schoolbus.client.api.SchoolbusesApiService;

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

@Api(description = "the schoolbuses API")


@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")

public class SchoolbusesApi  {

  @Context SecurityContext securityContext;

  @Inject SchoolbusesApiService delegate;


    @GET
    @Path("/{schoolbus-id}/inspections")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "", response = Inspection.class, responseContainer = "List", tags={ "Inspection",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = Inspection.class, responseContainer = "List"),
        @ApiResponse(code = 404, message = "SchoolBus not found", response = Inspection.class, responseContainer = "List") })
    public Response inspectionsGet(@ApiParam(value = "Id of SchoolBus to fetch Inspections for",required=true) @PathParam("schoolbus-id") Integer schoolbusId) {
    	return delegate.inspectionsGet(schoolbusId, securityContext);
    }

    @GET
    @Path("/{schoolbus-id}")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns a specific SchoolBus object", response = SchoolBus.class, tags={ "SchoolBus",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = SchoolBus.class),
        @ApiResponse(code = 404, message = "SchoolBus not found", response = SchoolBus.class) })
    public Response schoolbusesSchoolbusIdGet(@ApiParam(value = "Id of SchoolBus to fetch",required=true) @PathParam("schoolbus-id") Integer schoolbusId) {
    	return delegate.schoolbusesSchoolbusIdGet(schoolbusId, securityContext);
    }

    @GET
    @Path("/{schoolbus-id}/notes")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns notes for a particular SchoolBus.", response = SchoolBusNote.class, responseContainer = "List", tags={ "SchoolBus" })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = SchoolBusNote.class, responseContainer = "List"),
        @ApiResponse(code = 404, message = "SchoolBus not found", response = SchoolBusNote.class, responseContainer = "List") })
    public Response schoolbusesSchoolbusIdNotesGet(@ApiParam(value = "Id of SchoolBus to fetch notes for",required=true) @PathParam("schoolbus-id") Integer schoolbusId) {
    	return delegate.schoolbusesSchoolbusIdNotesGet(schoolbusId, securityContext);
    }
}
