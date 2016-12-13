package com.schoolbus.client.api;

import com.schoolbus.client.model.SchoolBusAttachment;
import com.schoolbus.client.model.CCWData;
import com.schoolbus.client.model.SchoolBusHistory;
import com.schoolbus.client.api.SchoolbusApiService;

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

@Api(description = "the schoolbus API")


@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")

public class SchoolbusApi  {

  @Context SecurityContext securityContext;

  @Inject SchoolbusApiService delegate;


    @GET
    @Path("/{schoolbus-id}/attachments")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns attachments for a particular SchoolBus", response = SchoolBusAttachment.class, responseContainer = "List", tags={ "SchoolBus",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = SchoolBusAttachment.class, responseContainer = "List"),
        @ApiResponse(code = 404, message = "SchoolBus not found", response = SchoolBusAttachment.class, responseContainer = "List") })
    public Response schoolbusSchoolbusIdAttachmentsGet(@ApiParam(value = "Id of SchoolBus to fetch attachments for",required=true) @PathParam("schoolbus-id") Integer schoolbusId) {
    	return delegate.schoolbusSchoolbusIdAttachmentsGet(schoolbusId, securityContext);
    }

    @GET
    @Path("/{schoolbus-id}/ccwdata")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns CCWData for a particular Schoolbus", response = CCWData.class, tags={ "Owner",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = CCWData.class) })
    public Response schoolbusSchoolbusIdCcwdataGet(@ApiParam(value = "Id of SchoolBus to fetch CCWData for",required=true) @PathParam("schoolbus-id") Integer schoolbusId) {
    	return delegate.schoolbusSchoolbusIdCcwdataGet(schoolbusId, securityContext);
    }

    @GET
    @Path("/{schoolbus-id}/history")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns History for a particular SchoolBus", response = SchoolBusHistory.class, responseContainer = "List", tags={ "SchoolBus" })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = SchoolBusHistory.class, responseContainer = "List") })
    public Response schoolbusSchoolbusIdHistoryGet(@ApiParam(value = "Id of SchoolBus to fetch SchoolBusHistory for",required=true) @PathParam("schoolbus-id") Integer schoolbusId) {
    	return delegate.schoolbusSchoolbusIdHistoryGet(schoolbusId, securityContext);
    }
}
