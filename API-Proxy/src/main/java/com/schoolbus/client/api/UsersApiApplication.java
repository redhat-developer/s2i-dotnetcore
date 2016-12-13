package com.schoolbus.client.api;

import java.io.IOException;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;
import java.util.jar.Manifest;
import javax.inject.Inject;
import javax.ws.rs.ApplicationPath;
import javax.ws.rs.core.Application;

import io.fabric8.utils.Manifests;
import org.apache.cxf.feature.LoggingFeature;
import org.apache.cxf.jaxrs.swagger.SwaggerFeature;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")
@ApplicationPath("/api/users")

public class UsersApiApplication extends Application{
	@Inject
	private UsersApi _UsersApi; 
	
	private static final Logger LOG = LoggerFactory.getLogger(UsersApiApplication.class);
    private static SwaggerFeature swaggerFeature;    
	
	@Override
    public Set<Object> getSingletons() {
    	
    	if (swaggerFeature == null) {
            swaggerFeature = new SwaggerFeature();
			try {
				Manifest manifest = Manifests.getManifestFromCurrentJar(getClass());
				Map<Manifests.Attribute,String> projectInfo = Manifests.getManifestEntryMap(manifest, Manifests.PROJECT_ATTRIBUTES.class);
				swaggerFeature.setTitle(      projectInfo.get(Manifests.PROJECT_ATTRIBUTES.Title));
				swaggerFeature.setDescription(projectInfo.get(Manifests.PROJECT_ATTRIBUTES.Description));
				swaggerFeature.setLicense(    projectInfo.get(Manifests.PROJECT_ATTRIBUTES.License));
				swaggerFeature.setLicenseUrl( projectInfo.get(Manifests.PROJECT_ATTRIBUTES.LicenseUrl));
				swaggerFeature.setVersion(    projectInfo.get(Manifests.PROJECT_ATTRIBUTES.Version));
				swaggerFeature.setContact(    projectInfo.get(Manifests.PROJECT_ATTRIBUTES.Contact));
			} catch (IOException e) {
				LOG.info("Could not read the project attributes from the Manifest due to " + e.getMessage());
			}
    	}
        return new HashSet<Object>(
                    Arrays.asList(
						_UsersApi,
						swaggerFeature,
						new LoggingFeature()
                )
        );
    }
}
