using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XPY.ToolKit.AspNetCore.Test.WebProject
{
    [Route("api/[Controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public void Get()
        {

        }
    }
}
