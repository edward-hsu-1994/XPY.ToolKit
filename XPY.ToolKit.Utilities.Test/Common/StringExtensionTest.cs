using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XPY.ToolKit.Utilities.Common.Test {
    public class StringExtensionTest {
        [Theory(DisplayName = "字串固定大小切割測試")]
        [InlineData("0123456789", 5, "01234,56789")]
        [InlineData("0123456789", 3, "012,345,678,9")]
        [InlineData("0123456789", 1, "0,1,2,3,4,5,6,7,8,9")]
        [InlineData("0123456789", 10, "0123456789")]
        public void SplitTest(string origin, int chunkSize, string result) {
            Assert.Equal(result, string.Join(",", origin.Split(chunkSize)));
        }

        [Theory(DisplayName = "不同語系字串中加入空白間隔")]
        [InlineData("1台電腦", "1 台電腦")]
        [InlineData("Taiwan位於太平洋西岸", "Taiwan 位於太平洋西岸")]
        [InlineData("我出生於1994年", "我出生於 1994 年")]
        [InlineData("台灣的英文名稱叫做Taiwan", "台灣的英文名稱叫做 Taiwan")]
        public void SpacingTest(string origin, string result) {
            Assert.Equal(result, origin.Spacing());
        }
    }
}
