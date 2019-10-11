using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using XPY.ToolKit.AspNetCore.Services.Test.WebProject.Services;
using Xunit;

namespace XPY.ToolKit.AspNetCore.Mvc.Services.WebProject
{
    [Route("api/[Controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public void Get(
            [FromServices]TestService testService)
        {
            Assert.NotNull(testService);
        }
    }
}
