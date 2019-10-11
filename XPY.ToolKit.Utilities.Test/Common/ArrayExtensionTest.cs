using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XPY.ToolKit.Utilities.Common.Test
{
    public class ArrayExtensionTest
    {
        public static IEnumerable<object[]> GetDefaultData {
            get {
                return new object[][]{
                    new object[]{ 1, new object[] { 1 } },
                    new object[]{ null, new object[] { null } },
                    new object[]{ new object[] { true }, new object[] { new object[] { true } } },
                }.ToList();
            }
        }

        [Theory(DisplayName = "實例包裝為陣列")]
        [MemberData(nameof(GetDefaultData))]
        public void BoxingToArrayTest(object elementInstance, object[] array)
        {
            Assert.Equal(elementInstance.BoxingToArray(), array);
        }

        public static IEnumerable<object[]> GetLengthsData {
            get {
                return new object[][]{
                    new object[]{ new object[,,] {
                        { { 1,2,3,4},{ 5,6,7,8} }
                    } , new int[]{ 1,2 ,4 } }
                }.ToList();
            }
        }

        [Theory(DisplayName = "取得陣列的長度")]
        [MemberData(nameof(GetLengthsData))]
        public void GetLengthsTest(Array array, int[] indexes)
        {
            Assert.Equal(array.GetLengths(), indexes);
        }

        public static IEnumerable<object[]> GetAllIndexesData {
            get {
                return new object[][]{
                    new object[]{ new object[,,] {
                        { { 1,2,3,4},{ 5,6,7,8} }
                    } , new int[][]{
                        new int[]{ 0,0,0 },
                        new int[]{ 0,0,1 },
                        new int[]{ 0,0,2 },
                        new int[]{ 0,0,3 },
                        new int[]{ 0,1,0 },
                        new int[]{ 0,1,1 },
                        new int[]{ 0,1,2 },
                        new int[]{ 0,1,3 },
                    }}
                }.ToList();
            }
        }

        [Theory(DisplayName = "取得陣列中所有維度的長度")]
        [MemberData(nameof(GetAllIndexesData))]
        public void GetAllIndexesTest(Array array, int[][] indexes)
        {
            Assert.Equal(array.GetAllIndexes(), indexes);
        }

        public static IEnumerable<object[]> FullData {
            get {
                return new object[][]{
                    new object[]{ new object[,,] {
                        { { 1,2,3,4},{ 5,6,7,8} }
                    } , new object[,,] {
                        { { -1,-1,-1,-1},{ -1,-1,-1,-1} }
                    } , -1}
                }.ToList();
            }
        }

        [Theory(DisplayName = "填滿陣列")]
        [MemberData(nameof(FullData))]
        public void FullTest(Array array, Array result, object value)
        {
            array.Full(value);
            Assert.Equal(array, result);
        }
    }
}
