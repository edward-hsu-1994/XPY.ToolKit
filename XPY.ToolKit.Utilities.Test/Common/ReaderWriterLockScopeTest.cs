using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace XPY.ToolKit.Utilities.Common.Test {
    /// <summary>
    /// 讀寫鎖區塊
    /// </summary>
    public class ReaderWriterLockScopeTest {
        [Fact(DisplayName = "讀寫鎖區塊測試1")]
        public void ScopeTest1() {
            int result = 0;
            ReaderWriterLockSlim locker = new ReaderWriterLockSlim();
            Parallel.For(0, 100, (_) => {
                using (var scope = new ReaderWriterLockScope(locker, ReaderWriterLockMode.Write)) {
                    result++;
                }
            });
            Assert.Equal(100, result);
        }

        [Fact(DisplayName = "讀寫鎖區塊測試2")]
        public void ScopeTest2() {
            int result = 0;
            ReaderWriterLockSlim locker = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
            Parallel.For(0, 100, (_) => {
                using (var scope1 = new ReaderWriterLockScope(locker, ReaderWriterLockMode.Write)) {
                    result++;
                    using (var scope2 = new ReaderWriterLockScope(locker, ReaderWriterLockMode.Write)) {
                        result++;
                    }
                }
            });
            Assert.Equal(200, result);
        }

        [Fact(DisplayName = "讀寫鎖區塊測試3")]
        public void ScopeTest3() {
            int result = 0;
            ReaderWriterLockSlim locker = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
            Parallel.For(0, 100, (_) => {
                using (var scope1 = new ReaderWriterLockScope(locker, ReaderWriterLockMode.Read)) {
                    result = _;
                }
            });
        }
    }
}
