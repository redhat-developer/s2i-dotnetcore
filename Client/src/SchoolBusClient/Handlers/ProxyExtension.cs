using System;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SchoolBusClient.Handlers
{
    public static class ProxyExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseProxyServer(this IApplicationBuilder builder, IConfiguration configuration)
        {
            return builder.Use(next => new ProxyMiddleware(next, configuration).Invoke);
        }
    }
}
