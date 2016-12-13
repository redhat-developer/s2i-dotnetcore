package com.schoolbus.client.api;

import com.schoolbus.client.api.*;
import com.schoolbus.client.model.*;

import org.apache.cxf.jaxrs.ext.multipart.Attachment;

import com.schoolbus.client.model.UserFavorite;
import com.schoolbus.client.model.User;
import com.schoolbus.client.model.UserNotifications;

import java.util.List;

import java.io.InputStream;

import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;

@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")
public interface UsersApiService {
      public Response usersUserIdFavoritesGet(Integer userId, SecurityContext securityContext);
      public Response usersUserIdGet(Integer userId, SecurityContext securityContext);
      public Response usersUserIdNotificationsGet(Integer userId, SecurityContext securityContext);
}
