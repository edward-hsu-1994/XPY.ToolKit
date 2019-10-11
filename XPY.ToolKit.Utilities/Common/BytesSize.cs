using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.Utilities.Common
{
    /// <summary>
    /// 常用Byte大小單位
    /// </summary>
    public static class BytesSize
    {
        #region 二進制進位
        /// <summary>
        /// Kibibyte
        /// </summary>
        public const long KiB = 1024;

        /// <summary>
        /// Mebibyte
        /// </summary>
        public const long MiB = KiB * 1024;

        /// <summary>
        /// Gibibyte
        /// </summary>
        public const long GiB = MiB * 1024;

        /// <summary>
        /// Tebibyte
        /// </summary>
        public const long TiB = GiB * 1024;

        /// <summary>
        /// Pebibyte
        /// </summary>
        public const long PiB = TiB * 1024;

        /// <summary>
        /// Exbibyte
        /// </summary>
        public const long EiB = PiB * 1024;
        #endregion

        #region 十進制進位
        /// <summary>
        /// Kilobyte
        /// </summary>
        public const long KB = 1000;

        /// <summary>
        /// Megabyte
        /// </summary>
        public const long MB = KB * 1000;

        /// <summary>
        /// Gigabyte
        /// </summary>
        public const long GB = MB * 1000;

        /// <summary>
        /// Terabyte
        /// </summary>
        public const long TB = GB * 1000;

        /// <summary>
        /// Petabyte
        /// </summary>
        public const long PB = TB * 1000;

        /// <summary>
        /// Exabyte
        /// </summary>
        public const long EB = PB * 1000;
        #endregion
    }
}
