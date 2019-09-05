using System;
using System.Text;
using Xunit;

namespace XPY.ToolKit.Base58.Test {
    public class Base58ConvertTest {
        [Theory(DisplayName = "BASE58轉換")]
        [InlineData("1234", "2FwFnT")]
        [InlineData("HELLO", "99v1Y8E")]
        [InlineData("world", "EUYUqQf")]
        [InlineData("000000000", "caPUmkT1y5Dh")]
        public void ToBase58(string utf8, string base58) {
            Assert.Equal(base58, Base58Convert.ToBase58String(Encoding.UTF8.GetBytes(utf8)));
        }

        [Theory(DisplayName = "BASE58還原")]
        [InlineData("1234", "2FwFnT")]
        [InlineData("HELLO", "99v1Y8E")]
        [InlineData("world", "EUYUqQf")]
        [InlineData("000000000", "caPUmkT1y5Dh")]
        public void FromBase58(string utf8, string base58) {
            Assert.Equal(utf8, Encoding.UTF8.GetString(Base58Convert.FromBase58String(base58)));
        }

        [Fact(DisplayName = "BASE58轉換新行")]
        public void ToBase58NewLine() {
            var result = Base58Convert.ToBase58String(Encoding.UTF8.GetBytes(new string('a', 1000)),
                Base58FormattingOptions.InsertLineBreaks);

            var test = result.Split(Environment.NewLine);

            foreach (var item in test) {
                Assert.True(item.Length <= 76);
            }
        }
    }
}
