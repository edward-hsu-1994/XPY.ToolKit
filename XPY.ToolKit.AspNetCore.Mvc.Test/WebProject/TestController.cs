using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using XPY.ToolKit.AspNetCore.Mvc.Test.WebProject.Models;
using Xunit;

namespace XPY.ToolKit.AspNetCore.Mvc.Test.WebProject
{
    [Route("api/[Controller]")]
    public class TestController : Controller
    {
        [HttpPost]
        public void Post(
            [FromFormJson]TestModel loginData,
            [FromQuery]string keyword,
            [FromForm]string name)
        {
            Assert.NotNull(loginData);
            Assert.NotNull(loginData.Account);
            Assert.NotNull(loginData.Password);
            Assert.NotNull(name);
            Assert.NotNull(keyword);
        }
    }
}
