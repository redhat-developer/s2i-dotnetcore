// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SampleApp
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.Run(async context =>
            {
                Console.WriteLine("{0} {1}{2}{3}",
                    context.Request.Method,
                    context.Request.PathBase,
                    context.Request.Path,
                    context.Request.QueryString);
                Console.WriteLine($"Method: {context.Request.Method}");
                Console.WriteLine($"PathBase: {context.Request.PathBase}");
                Console.WriteLine($"Path: {context.Request.Path}");
                Console.WriteLine($"QueryString: {context.Request.QueryString}");

                var connectionFeature = context.Connection;
                Console.WriteLine($"Peer: {connectionFeature.RemoteIpAddress?.ToString()} {connectionFeature.RemotePort}");
                Console.WriteLine($"Sock: {connectionFeature.LocalIpAddress?.ToString()} {connectionFeature.LocalPort}");

                context.Response.ContentLength = 11;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Hello world");
            });
        }

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:8080")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            // The following section should be used to demo sockets
            //var addresses = application.GetAddresses();
            //addresses.Clear();
            //addresses.Add("http://unix:/tmp/kestrel-test.sock");

            host.Run();
        }
    }
}
