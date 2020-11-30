using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AspNetHelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseKestrel()
                .Configure(a => a.Run(c => c.Response.WriteAsync("Hello World!")))
                .Build()
                .Run();
        }
    }
}
