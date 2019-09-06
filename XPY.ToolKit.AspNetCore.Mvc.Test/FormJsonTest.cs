using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using StackExchange.Utils;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using XPY.ToolKit.AspNetCore.Mvc.Test.WebProject.Models;
using Xunit;

namespace XPY.ToolKit.AspNetCore.Mvc.Test {
    public class FormJsonTest {

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

            await Http.Request($"http://localhost:{port}/api/Test?keyword=test")
                       .SendForm(new NameValueCollection() {
                           ["loginData"] = JsonConvert.SerializeObject(new TestModel() {
                               Account = "test",
                               Password = "testpassword"
                           }),
                           ["name"] = "XuPeiYao"
                       })
                       .ExpectHttpSuccess()
                       .PostAsync();

            await webhost.StopAsync();
        }
    }
}
