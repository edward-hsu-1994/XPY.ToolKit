using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.Utilities.Test.Reflection.Models
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class SampleEnumAttribute : Attribute
    {
    }
}
