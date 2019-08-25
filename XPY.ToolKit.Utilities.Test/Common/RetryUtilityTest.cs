using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XPY.ToolKit.Utilities.Common.Test {
    /// <summary>
    /// 重試操作方法
    /// </summary>
    public static class RetryUtilityTest {
        [Fact(DisplayName = "重試函數操作測試")]
        public static void RetryFuncTest() {
            int retry = 0;
            RetryUtility.Retry(3, () => {
                retry++;
            });
            Assert.Equal(1, retry);

            retry = 0;
            Assert.Throws<Exception>(() => {
                RetryUtility.Retry(3, () => {
                    retry++;
                    throw new Exception();
                });
            });
            Assert.Equal(3, retry);
        }

        [Fact(DisplayName = "重試方法操作測試")]
        public static void RetryTest() {
            int retry = 0;
            bool result = RetryUtility.Retry(3, () => {
                retry++;

                return true;
            });
            Assert.Equal(1, retry);
            Assert.True(result);

            retry = 0;
            Assert.Throws<Exception>(() => {
                result = RetryUtility.Retry(3, () => {
                    retry++;
                    throw new Exception();

                    return true;
                });
            });
            Assert.Equal(3, retry);

            RetryUtility.Retry(3, async () => {
                return 1;
            });
        }
    }
}
