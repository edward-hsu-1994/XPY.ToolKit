using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XPY.ToolKit.Utilities.Common.Test {
    public class BytesUtilityTest {
        public static IEnumerable<object[]> TestDataSets =>
            new List<object[]>() {
                new object[]{ new byte[] { 0x00,0xFF} , true, "00FF" },
                new object[]{ new byte[] { 0x12,0x34} , true, "1234" },
                new object[]{ new byte[] { 0x97,0x1F} , false, "971f" },
                new object[]{ new byte[] { 0x07,0xF0} , false, "07f0" }
            };

        [Theory(DisplayName = "ByteArray轉16進位表示")]
        [MemberData(nameof(TestDataSets))]
        public void ToHexTest(byte[] byteArray, bool upper, string result) {
            Assert.Equal(result, BytesUtility.ToHex(byteArray, upper));
        }

        [Theory(DisplayName = "16進位表示轉ByteArray")]
        [MemberData(nameof(TestDataSets))]
        public void FromHexTest(byte[] byteArray, bool upper, string result) {
            Assert.Equal(byteArray, BytesUtility.FromHex(result));
        }
    }
}
