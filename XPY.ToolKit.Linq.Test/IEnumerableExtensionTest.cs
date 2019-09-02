using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using XPY.ToolKit.Linq;

namespace XPY.ToolKit.Linq.Test {
    public partial class IEnumerableExtensionTest {
        [Theory(DisplayName = "列舉值範圍過濾")]
        [InlineData(null, 100, 100)]
        [InlineData(60, 100, 41)]
        [InlineData(60, null, 41)]
        [InlineData(60, 0, 0)]
        public void BetweenTest(int? min, int? max, int count) {
            Assert.Equal(Enumerable.Range(1, 100).Between(x => x, min, max).Count(), count);
        }

        [Fact(DisplayName = "數值過濾")]
        public void FilterTest() {
            Assert.Equal(100, Enumerable.Range(1, 100).Filter(x => x, null).Count());
            Assert.Empty(Enumerable.Range(1, 100).Filter(x => x, 0));
            Assert.Single(Enumerable.Range(1, 100).Filter(x => x, 50));
        }
    }
}
