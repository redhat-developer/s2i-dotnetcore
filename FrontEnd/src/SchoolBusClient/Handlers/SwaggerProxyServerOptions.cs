namespace SchoolBusClient.Handlers
{
    public class SwaggerProxyServerOptions : ProxyServerOptions
    {
        public SwaggerProxyServerOptions()
        {
            Scheme = "http";
            Host = "localhost";
            Port = "80";
            PathKey = "/swagger/";
        }
    }
}
