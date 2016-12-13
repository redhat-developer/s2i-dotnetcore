package com.schoolbus.client.api;

import com.schoolbus.client.model.UserFavorite;
import com.schoolbus.client.model.User;
import com.schoolbus.client.model.UserNotifications;
import com.schoolbus.client.api.UsersApiService;

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

@Api(description = "the users API")


@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")

public class UsersApi  {

  @Context SecurityContext securityContext;

  @Inject UsersApiService delegate;


    @GET
    @Path("/{user-id}/favorites")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns a user's favorites of a given context type", response = UserFavorite.class, responseContainer = "List", tags={ "Owner",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = UserFavorite.class, responseContainer = "List"),
        @ApiResponse(code = 404, message = "User not found", response = UserFavorite.class, responseContainer = "List") })
    public Response usersUserIdFavoritesGet(@ApiParam(value = "Id of User to fetch favorites for",required=true) @PathParam("user-id") Integer userId) {
    	return delegate.usersUserIdFavoritesGet(userId, securityContext);
    }

    @GET
    @Path("/{user-id}")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns data for a particular User", response = User.class, tags={ "User",  })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = User.class),
        @ApiResponse(code = 404, message = "User not found", response = User.class) })
    public Response usersUserIdGet(@ApiParam(value = "Id of User to fetch",required=true) @PathParam("user-id") Integer userId) {
    	return delegate.usersUserIdGet(userId, securityContext);
    }

    @GET
    @Path("/{user-id}/notifications")
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns a user's notifications", response = UserNotifications.class, responseContainer = "List", tags={ "User" })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = UserNotifications.class, responseContainer = "List") })
    public Response usersUserIdNotificationsGet(@ApiParam(value = "Id of User to fetch notifications for",required=true) @PathParam("user-id") Integer userId) {
    	return delegate.usersUserIdNotificationsGet(userId, securityContext);
    }
}
