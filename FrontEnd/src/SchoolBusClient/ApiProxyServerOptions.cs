namespace SchoolBusClient
{
    public class ApiProxyServerOptions
    {
        public ApiProxyServerOptions()
        {
            Scheme = "http";
            Host = "localhost";
            Port = "80";
        }

        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
    }
}
