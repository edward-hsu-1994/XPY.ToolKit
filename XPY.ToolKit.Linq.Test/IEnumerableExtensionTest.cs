using System;
using System.Linq;
using Xunit;

namespace XPY.ToolKit.Linq.Test {
    public class IEnumerableExtensionTest {
        [Fact(DisplayName = "¤Á³Î¦CÁ|")]
        public void Split() {
            Assert.Equal(
                "0123456789".ToCharArray().Select(x => new char[] { x }),
                "0123456789".ToCharArray().Split(1));
        }
    }
}
