using System;
using System.Collections.Generic;
using System.Linq;
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

        [Theory(DisplayName = "安全的Substring")]
        [InlineData("ABCDEFGH", 1, 5, "BCDEF")]
        [InlineData("ABCDEFGH", 0, 5, "ABCDE")]
        [InlineData("ABCDEFGH", 5, 5, "FGH")]
        [InlineData("ABCDEFGH", 7, 5, "H")]
        [InlineData("ABCDEFGH", 8, 1, "")]
        [InlineData("ABCDEFGH", 8, 100, "")]
        public void SafeSubstringTest(string origin, int startIndex, int length, string result) {
            Assert.Equal(result, origin.SafeSubstring(startIndex, length));
        }

        [Theory(DisplayName = "字串是否符合表示式")]
        [InlineData("A123456789", "[A-Z][0-9]{9}", true)]
        [InlineData("A12346789", "[A-Z][0-9]{9}", false)]
        [InlineData("A12346789", "[A-Z][0-9]{2,}", true)]
        public void IsMatchTest(string origin, string regex, bool isMatch) {
            Assert.True(origin.IsMatch(regex) == isMatch);
        }

        [Theory(DisplayName = "字串間子字串")]
        [InlineData("0123456789", "2", "3", "")]
        [InlineData("0123456789", "2", "4", "3")]
        [InlineData("0123456789", "2", "-", "")]
        [InlineData("0123456789", "9", "4", "")]
        [InlineData("0123456789", "0", "5", "1234")]
        public void InnerStringTest(string origin, string start, string end, string result) {
            Assert.Equal(result, origin.InnerString(start, end));
        }

        [Theory(DisplayName = "指定索引位置切割字串")]
        [InlineData("0123456789", "2,3", "01,2,3456789")]
        [InlineData("0123456789", "2,5,8", "01,234,567,89")]
        [InlineData("0123456789", "0,1,2,3", ",0,1,2,3456789")]
        [InlineData("0123456789", "5", "01234,56789")]
        public void SliceTest(string input, string indexes, string output) {
            Assert.Equal(output,
                string.Join(",",
                    input.Slice(indexes.Split(',').Select(int.Parse).ToArray())
                )
            );
        }

        [Theory(DisplayName = "取代指定區間的字串")]
        [InlineData("0123456789", 1, 1, "aaa", "0aaa23456789")]
        [InlineData("0123456789", 2, 5, "123", "01123789")]
        [InlineData("0123456789", 1, 8, "x", "0x9")]
        public void ReplaceRangeTest(string str, int index, int length, string newValue, string result) {
            Assert.Equal(result, str.ReplaceRange(index, length, newValue));
        }
    }
}
