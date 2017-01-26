namespace SchoolBusClient.Handlers
{
    public class ApiProxyServerOptions : ProxyServerOptions
    {
        public ApiProxyServerOptions()
        {
            Scheme = "http";
            Host = "localhost";
            Port = "80";
            PathKey = "/api/";
        }
    }
}
