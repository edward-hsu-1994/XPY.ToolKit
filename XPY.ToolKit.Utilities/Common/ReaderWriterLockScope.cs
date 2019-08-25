using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace XPY.ToolKit.Utilities.Common {
    /// <summary>
    /// 讀寫鎖區塊模式
    /// </summary>
    public enum ReaderWriterLockMode {
        Write,
        Read,
        UpgradeableRead
    }

    /// <summary>
    /// 讀寫鎖區塊
    /// </summary>
    public class ReaderWriterLockScope : IDisposable {
        ReaderWriterLockMode mode;
        ReaderWriterLockSlim locker;
        public ReaderWriterLockScope(ReaderWriterLockSlim locker, ReaderWriterLockMode mode) {
            this.locker = locker;
            this.mode = mode;
            switch (mode) {
                case ReaderWriterLockMode.Read:
                    locker.EnterReadLock();
                    break;
                case ReaderWriterLockMode.Write:
                    locker.EnterWriteLock();
                    break;
                case ReaderWriterLockMode.UpgradeableRead:
                    locker.EnterUpgradeableReadLock();
                    break;
            }
        }

        public void Dispose() {
            switch (mode) {
                case ReaderWriterLockMode.Read:
                    locker.ExitReadLock();
                    break;
                case ReaderWriterLockMode.Write:
                    locker.ExitWriteLock();
                    break;
                case ReaderWriterLockMode.UpgradeableRead:
                    locker.ExitUpgradeableReadLock();
                    break;
            }
        }
    }
}
