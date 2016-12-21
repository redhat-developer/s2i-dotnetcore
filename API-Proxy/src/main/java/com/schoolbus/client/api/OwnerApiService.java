package com.schoolbus.client.api;

import com.schoolbus.client.api.*;
import com.schoolbus.client.model.*;

import org.apache.cxf.jaxrs.ext.multipart.Attachment;

import com.schoolbus.client.model.OwnerAttachments;
import com.schoolbus.client.model.OwnerContactAddress;
import com.schoolbus.client.model.OwnerContactPhone;
import com.schoolbus.client.model.Owner;
import com.schoolbus.client.model.OwnerNotes;

import java.util.List;

import java.io.InputStream;

import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;

@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")
public interface OwnerApiService {
      public Response ownerOwnerIdAttachmentsGet(Integer ownerId, SecurityContext securityContext);
      public Response ownerOwnerIdContactaddressesGet(Integer ownerId, SecurityContext securityContext);
      public Response ownerOwnerIdContactphonesGet(Integer ownerId, SecurityContext securityContext);
      public Response ownerOwnerIdGet(Integer ownerId, SecurityContext securityContext);
      public Response ownerOwnerIdNotesGet(Integer ownerId, SecurityContext securityContext);
}
