using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using XPY.ToolKit.AspNetCore.DependencyInjection;
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

        [HttpGet("cycle")]
        public void CycleDI([FromServices]Cycle<A> a)
        {
            if (a.Instance.B == null)
            {
                throw new Exception();
            }
        }
    }
}
