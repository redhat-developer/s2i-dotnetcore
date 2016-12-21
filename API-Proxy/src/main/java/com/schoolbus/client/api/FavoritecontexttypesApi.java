package com.schoolbus.client.api;

import com.schoolbus.client.model.FavoriteContextType;
import com.schoolbus.client.api.FavoritecontexttypesApiService;

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

@Api(description = "the favoritecontexttypes API")


@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")

public class FavoritecontexttypesApi  {

  @Context SecurityContext securityContext;

  @Inject FavoritecontexttypesApiService delegate;


    @GET
    
    
    @Produces({ "text/plain", "application/json", "text/json" })
    @ApiOperation(value = "", notes = "Returns list of available FavoriteContextTypes", response = FavoriteContextType.class, responseContainer = "List", tags={ "Owner" })
    @ApiResponses(value = { 
        @ApiResponse(code = 200, message = "OK", response = FavoriteContextType.class, responseContainer = "List") })
    public Response favoritecontexttypesGet() {
    	return delegate.favoritecontexttypesGet(securityContext);
    }
}
