using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XPY.ToolKit.Utilities.Common.Test {
    public class TaskExtensionTest {
        public async Task TestAsyncMethodAction() {
            await Task.Run(() => {
                return 0;
            });
        }

        public async Task<int> TestAsyncMethodFunc() {
            return await Task.Run(() => {
                return 0;
            });
        }

        [Fact(DisplayName = "非同步函數轉換同步方法測試")]
        public void ToSyncAction() {
            TestAsyncMethodAction().ToSync();
        }

        [Fact(DisplayName = "非同步方法轉換同步函數測試")]
        public void ToSyncFunc() {
            var result = TestAsyncMethodFunc().ToSync();
            Assert.Equal(0, result);
        }
    }
}
