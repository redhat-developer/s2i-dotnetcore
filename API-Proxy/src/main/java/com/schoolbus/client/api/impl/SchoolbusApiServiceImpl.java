package com.schoolbus.client.api.impl;

import com.schoolbus.client.api.*;
import com.schoolbus.client.model.*;

import org.apache.cxf.jaxrs.ext.multipart.Attachment;

import com.schoolbus.client.model.SchoolBusAttachment;
import com.schoolbus.client.model.CCWData;
import com.schoolbus.client.model.SchoolBusHistory;

import java.util.List;

import java.io.InputStream;

import javax.enterprise.context.RequestScoped;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;

@RequestScoped
@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")
public class SchoolbusApiServiceImpl implements SchoolbusApiService {
      @Override
      public Response schoolbusSchoolbusIdAttachmentsGet(Integer schoolbusId, SecurityContext securityContext) {
      // do some magic!
      return Response.ok().entity("magic!").build();
  }
      @Override
      public Response schoolbusSchoolbusIdCcwdataGet(Integer schoolbusId, SecurityContext securityContext) {
      // do some magic!
      return Response.ok().entity("magic!").build();
  }
      @Override
      public Response schoolbusSchoolbusIdHistoryGet(Integer schoolbusId, SecurityContext securityContext) {
      // do some magic!
      return Response.ok().entity("magic!").build();
  }
}
