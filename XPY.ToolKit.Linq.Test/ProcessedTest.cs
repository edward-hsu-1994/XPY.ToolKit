using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using XPY.ToolKit.Linq.Processing;

namespace XPY.ToolKit.Linq.Test {
    public class ProcessedTest {
        [Fact(DisplayName = "IQueryable Element轉換")]
        public void ProcessedTestCase() {
            Assert.Equal(
                Enumerable.Range(1, 100).Select(x => x * 2),
                Enumerable.Range(1, 100).AsQueryable().Process(x => x * 2));
        }
    }
}
