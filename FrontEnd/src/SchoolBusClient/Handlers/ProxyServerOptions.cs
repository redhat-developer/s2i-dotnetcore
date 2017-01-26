namespace SchoolBusClient.Handlers
{
    public class ProxyServerOptions
    {
        public ProxyServerOptions()
        {}

        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string PathKey { get;  set; }
    }
}
