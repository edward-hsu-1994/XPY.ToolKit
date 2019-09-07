using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using StackExchange.Utils;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XPY.ToolKit.AspNetCore.Test {
    public class BasicAuthenticateRealmTest {

        static int FreeTcpPort() {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }

        [Fact]
        public async Task WebTest() {
            int port = 0;
            var webhost = WebHost.CreateDefaultBuilder()
                .ConfigureKestrel(options => {
                    options.ListenLocalhost(port = FreeTcpPort());
                })
                .UseStartup<Startup>()
                .Build();

            await webhost.StartAsync();

            var response = await Http.Request($"http://localhost:{port}/api/Test")
                .ExpectHttpSuccess()
                .PostAsync();

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);


            response = await Http.Request($"http://localhost:{port}/api/Test")
                .AddHeader("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes("admin:admin"))}")
                .ExpectHttpSuccess()
                .GetAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            response = await Http.Request($"http://localhost:{port}/api/Test")
                .AddHeader("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes("error:admin"))}")
                .ExpectHttpSuccess()
                .GetAsync();

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

            await webhost.StopAsync();
        }
    }
}
