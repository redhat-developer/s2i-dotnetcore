package com.schoolbus.client.api;

import io.fabric8.utils.Strings;
import io.fabric8.utils.Systems;
import java.net.InetSocketAddress;
import org.apache.cxf.cdi.CXFCdiServlet;
import org.eclipse.jetty.server.Server;
import org.eclipse.jetty.servlet.ServletContextHandler;
import org.eclipse.jetty.servlet.ServletHolder;
import org.jboss.weld.environment.servlet.BeanManagerResourceBindingListener;
import org.jboss.weld.environment.servlet.Listener;

@javax.annotation.Generated(value = "class com.quartech.codegen.FuseGenerator", date = "2016-12-12T18:43:27.997-08:00")
public class ApplicationStarter {

    public static void main(final String[] args) throws Exception {
        startServer().join();
    }

    public static Server startServer() throws Exception {

        // use system property first
        String port = System.getProperty("HTTP_PORT");
        if (port == null) {
            // and fallback to use environment variable
            port = System.getenv("HTTP_PORT");
        }
        if (port == null) {
            // and use port 8080 by default
            port = "8080";
        }
        Integer num = Integer.parseInt(port);
        String service = Systems.getEnvVarOrSystemProperty("WEB_CONTEXT_PATH", "WEB_CONTEXT_PATH", "");
        String servicesPath = "/servicesList";

        String servletContextPath = "/" + service;

        System.out.println("Starting REST server at:         http://localhost:" + port + servletContextPath);
        System.out.println("View the services at:            http://localhost:" + port + servletContextPath + servicesPath);
        System.out.println("View an example REST service at: http://localhost:" + port + servletContextPath + "cxfcdi/customerservice/customers/123");
        System.out.println();

		
        InetSocketAddress inetaddr = new InetSocketAddress("0.0.0.0", num);
        final Server server = new Server(inetaddr);

        // Register and map the dispatcher servlet
        final ServletHolder servletHolder = new ServletHolder(new CXFCdiServlet());

        // change default service list URI
        servletHolder.setInitParameter("service-list-path", servicesPath);

        final ServletContextHandler context = new ServletContextHandler();
        context.setContextPath("/");
        context.addEventListener(new Listener());
        context.addEventListener(new BeanManagerResourceBindingListener());

        String servletPath = "/*";
        if (Strings.isNotBlank(service)) {
            servletPath = servletContextPath + "/*";
        }
        context.addServlet(servletHolder, servletPath);

        server.setHandler(context);
        
        
        server.start();
        return server;
    }

}
