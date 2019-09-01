using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.Utilities.Test.Reflection.Models {
    public enum SampleEnum {
        [SampleEnum]
        A,
        [SampleEnum]
        [SampleEnum]
        B,
        C
    }
}
