using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using StackExchange.Utils;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Xunit;

namespace XPY.ToolKit.AspNetCore.Services.Test
{
    public class ServiceTest
    {
        static int FreeTcpPort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }

        [Fact]
        public async Task WebTest()
        {
            int port = 0;
            var webhost = WebHost.CreateDefaultBuilder()
                .ConfigureKestrel(options =>
                {
                    options.ListenLocalhost(port = FreeTcpPort());
                })
                .UseStartup<Startup>()
                .Build();

            await webhost.StartAsync();

            var response = await Http.Request($"http://localhost:{port}/api/Test")
                .ExpectHttpSuccess().GetAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            await webhost.StopAsync();
        }
    }
}
