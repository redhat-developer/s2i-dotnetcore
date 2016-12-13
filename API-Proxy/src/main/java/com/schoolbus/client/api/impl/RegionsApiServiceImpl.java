package com.schoolbus.client.api.impl;

import com.schoolbus.client.api.*;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

import javax.enterprise.context.RequestScoped;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;

@RequestScoped
@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")
public class RegionsApiServiceImpl implements RegionsApiService {
      @Override
      public Response regionsGet(SecurityContext securityContext) {
      // do some magic!
      
      
      
      return Response.ok().entity(sendGet("/regions")).build();
  }
      
      
  private String sendGet(String path) {

       try
       { 
                String server = System.getenv("BACKEND_NAME");
		String url = "http://" + server + "/api/" + path ;

		URL obj = new URL(url);
		HttpURLConnection con = (HttpURLConnection) obj.openConnection();

		// optional default is GET
		con.setRequestMethod("GET");

		int responseCode = con.getResponseCode();
		System.out.println("\nSending 'GET' request to URL : " + url);
		System.out.println("Response Code : " + responseCode);

		BufferedReader in = new BufferedReader(
		        new InputStreamReader(con.getInputStream()));
		String inputLine;
		StringBuffer response = new StringBuffer();

		while ((inputLine = in.readLine()) != null) {
			response.append(inputLine);
		}
		in.close();

		//print result
		return response.toString();
       }
       catch (Exception e)
       {
           return e.toString();
       }

    }    
      
      
      
      @Override
      public Response regionsRegionIdCitiesGet(Integer regionId, SecurityContext securityContext) {
      // do some magic!
      return Response.ok().entity("magic!").build();
  }
      @Override
      public Response regionsRegionIdGet(Integer regionId, SecurityContext securityContext) {
      // do some magic!
      return Response.ok().entity("magic!").build();
  }
      @Override
      public Response regionsRegionIdLocalareasGet(Integer regionId, SecurityContext securityContext) {
      // do some magic!
      return Response.ok().entity("magic!").build();
  }
      @Override
      public Response regionsRegionIdSchooldistrictsGet(Integer regionId, SecurityContext securityContext) {
      // do some magic!
      return Response.ok().entity("magic!").build();
  }
}
