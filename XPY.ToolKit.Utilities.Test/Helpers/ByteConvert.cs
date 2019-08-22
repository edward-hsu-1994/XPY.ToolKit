using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.Utilities.Test.Helpers {
    class ByteConvert {
        public static byte[] HexToBytes(string hexString) {
            byte[] byteOUT = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i = i + 2) {
                byteOUT[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return byteOUT;
        }
    }
}
