package com.schoolbus.client.api;

import com.schoolbus.client.model.OwnerAttachments;
import com.schoolbus.client.model.OwnerContactAddress;
import com.schoolbus.client.model.OwnerContactPhone;
import com.schoolbus.client.model.Owner;
import com.schoolbus.client.model.OwnerNotes;
import com.schoolbus.client.api.OwnerApiService;

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

@Api(description = "the owner API")


@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")

public class OwnerApi  {

  @Context SecurityContext securityContext;

  @Inject OwnerApiService delegate;


    @GET
    @Path("/{owner-id}/attachments")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns attachments for a particular Owner", response = OwnerAttachments.class, responseContainer = "List", tags={ "SchoolBus",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = OwnerAttachments.class, responseContainer = "List") })
    public Response ownerOwnerIdAttachmentsGet(@ApiParam(value = "Id of Owner to fetch attachments for",required=true) @PathParam("owner-id") Integer ownerId) {
    	return delegate.ownerOwnerIdAttachmentsGet(ownerId, securityContext);
    }

    @GET
    @Path("/{owner-id}/contactaddresses")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns address contacts for a particular Owner", response = OwnerContactAddress.class, responseContainer = "List", tags={ "Owner",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = OwnerContactAddress.class, responseContainer = "List") })
    public Response ownerOwnerIdContactaddressesGet(@ApiParam(value = "Id of Owner to fetch contact address for",required=true) @PathParam("owner-id") Integer ownerId) {
    	return delegate.ownerOwnerIdContactaddressesGet(ownerId, securityContext);
    }

    @GET
    @Path("/{owner-id}/contactphones")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns phone contacts for a particular Owner", response = OwnerContactPhone.class, responseContainer = "List", tags={ "Owner",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = OwnerContactPhone.class, responseContainer = "List") })
    public Response ownerOwnerIdContactphonesGet(@ApiParam(value = "Id of Owner to fetch contact phone for",required=true) @PathParam("owner-id") Integer ownerId) {
    	return delegate.ownerOwnerIdContactphonesGet(ownerId, securityContext);
    }

    @GET
    @Path("/{owner-id}")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns a particular Owner", response = Owner.class, responseContainer = "List", tags={ "Owner",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = Owner.class, responseContainer = "List") })
    public Response ownerOwnerIdGet(@ApiParam(value = "Id of Owner to fetch",required=true) @PathParam("owner-id") Integer ownerId) {
    	return delegate.ownerOwnerIdGet(ownerId, securityContext);
    }

    @GET
    @Path("/{owner-id}/notes")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns notes for a particular Owner", response = OwnerNotes.class, responseContainer = "List", tags={ "Owner" })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = OwnerNotes.class, responseContainer = "List") })
    public Response ownerOwnerIdNotesGet(@ApiParam(value = "Id of Owner to fetch notes for",required=true) @PathParam("owner-id") Integer ownerId) {
    	return delegate.ownerOwnerIdNotesGet(ownerId, securityContext);
    }
}
