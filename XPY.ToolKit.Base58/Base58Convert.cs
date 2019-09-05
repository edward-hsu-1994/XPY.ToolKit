using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace XPY.ToolKit.Base58 {
    /// <summary>
    /// BASE64編碼轉換
    /// </summary>
    public static class Base58Convert {
        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent string representation
        /// that is encoded with base-58 digits.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers.</param>
        /// <returns>The string representation, in base 58, of the contents of inArray.</returns
        /// <exception cref="ArgumentNullException">inArray is null.</exception>
        public static string ToBase58String(byte[] inArray) {
            return ToBase58String(inArray, Base58FormattingOptions.None);
        }

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent string representation
        /// that is encoded with base-58 digits.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers.</param>
        /// <param name="options">System.Base58FormattingOptions.InsertLineBreaks to insert a line break every 76 characters, or System.Base58FormattingOptions.None to not insert line breaks.</param>
        /// <returns>The string representation, in base 58, of the contents of inArray.</returns
        /// <exception cref="ArgumentNullException">inArray is null.</exception>
        /// <exception cref="ArgumentException">options is not a valid System.Base58FormattingOptions value.</exception>
        public static string ToBase58String(byte[] inArray, Base58FormattingOptions options) {
            if (inArray == null) throw new ArgumentNullException(nameof(inArray));
            if (Array.IndexOf(Enum.GetValues(typeof(Base58FormattingOptions)), options) == -1) {
                throw new ArgumentException("options is not a valid System.Base58FormattingOptions value.");
            }

            var base58 = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz".ToCharArray();

            StringBuilder builder = new StringBuilder();
            var bigNumber = new BigInteger(inArray.Reverse().ToArray());

            do {
                bigNumber = BigInteger.DivRem(bigNumber, base58.Length, out BigInteger rem);
                builder.Insert(0, base58[(int)rem]);
            } while (!bigNumber.IsZero);

            if (options == Base58FormattingOptions.None) {
                return builder.ToString();
            }

            StringBuilder insertLine = new StringBuilder();

            long counter = 0;
            foreach (var c in builder.ToString()) {
                insertLine.Append(c);
                counter++;
                if (counter > 0 && counter % 76 == 0) {
                    insertLine.Append(Environment.NewLine);
                    counter = 0;
                }
            }

            return insertLine.ToString().Trim();
        }


        /// <summary>
        /// Converts the specified string, which encodes binary data as base-58 digits, to an equivalent 8-bit unsigned integer array.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>An array of 8-bit unsigned integers that is equivalent to s.</returns>
        /// <exception cref="ArgumentNullException">inArray is null.</exception>
        public static byte[] FromBase58String(string s) {
            if (s == null) {
                throw new ArgumentNullException(nameof(s));
            }

            var base58 = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz".ToCharArray();

            return s.ToCharArray()
                .Select(x => {
                    if (base58.Contains(x)) {
                        return new BigInteger(Array.IndexOf(base58, x));
                    } else {
                        return -1;
                    }
                })
                .Where(x => x != -1)
                .Aggregate((before, current) => {
                    return before * base58.Length + current;
                })
                .ToByteArray()
                .Reverse()
                .ToArray();
        }
    }
}
