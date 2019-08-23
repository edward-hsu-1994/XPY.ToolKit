using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using XPY.ToolKit.Utilities.Test.Helpers;
using Xunit;

namespace XPY.ToolKit.Utilities.Cryptography.Test {
    public class HashExtensionTest {
        [Theory(DisplayName = "字串轉雜湊字串測試")]
        [InlineData("1234", false, "81dc9bdb52d04dc20036dbd8313ed055")]
        [InlineData("1234", true, "81DC9BDB52D04DC20036DBD8313ED055")]
        [InlineData("abcd", false, "e2fc714c4727ee9395f324cd2e7f331f")]
        [InlineData("abcd", true, "E2FC714C4727EE9395F324CD2E7F331F")]
        public void StringToHashString(string origin, bool upper, string hashResult) {
            Assert.Equal(hashResult, origin.ToHashString<MD5>(upper));
        }

        [Theory(DisplayName = "字串轉雜湊值測試")]
        [InlineData("1234", "81dc9bdb52d04dc20036dbd8313ed055")]
        [InlineData("abcd", "e2fc714c4727ee9395f324cd2e7f331f")]
        [InlineData("0000", "4a7d1ed414474e4033ac29ccb8653d9b")]
        [InlineData("admin", "21232f297a57a5a743894a0e4a801fc3")]
        public void StringToHash(string origin, string hashResult) {
            Assert.Equal(ByteConvert.HexToBytes(hashResult), origin.ToHash<MD5>());
        }

        [Theory(DisplayName = "Stream轉雜湊字串測試")]
        [InlineData("1234", false, "81dc9bdb52d04dc20036dbd8313ed055")]
        [InlineData("1234", true, "81DC9BDB52D04DC20036DBD8313ED055")]
        [InlineData("abcd", false, "e2fc714c4727ee9395f324cd2e7f331f")]
        [InlineData("abcd", true, "E2FC714C4727EE9395F324CD2E7F331F")]
        public void StreamToHashString(string origin, bool upper, string hashResult) {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(origin))) {
                Assert.Equal(hashResult, stream.ToHashString<MD5>(upper));
            }
        }

        [Theory(DisplayName = "Stream轉雜湊值測試")]
        [InlineData("1234", "81dc9bdb52d04dc20036dbd8313ed055")]
        [InlineData("abcd", "e2fc714c4727ee9395f324cd2e7f331f")]
        [InlineData("0000", "4a7d1ed414474e4033ac29ccb8653d9b")]
        [InlineData("admin", "21232f297a57a5a743894a0e4a801fc3")]
        public void StreamToHash(string origin, string hashResult) {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(origin))) {
                Assert.Equal(ByteConvert.HexToBytes(hashResult), stream.ToHash<MD5>());
            }
        }

        [Theory(DisplayName = "ByteArray轉雜湊字串測試")]
        [InlineData("1234", true, "81DC9BDB52D04DC20036DBD8313ED055")]
        [InlineData("abcd", true, "E2FC714C4727EE9395F324CD2E7F331F")]
        [InlineData("@@##", true, "135F3C9024CB4E41CDBB49F2C1503E5A")]
        [InlineData("!!@@", true, "3F75B776C3D03B2575BA831B5D3752B5")]
        public void ByteArrayToHashString(string origin, bool upper, string hashResult) {
            var bytes = Encoding.UTF8.GetBytes(origin);
            Assert.Equal(hashResult, bytes.ToHashString<MD5>(upper));
        }

        [Theory(DisplayName = "ByteArray轉雜湊值測試")]
        [InlineData("1234", "81dc9bdb52d04dc20036dbd8313ed055")]
        [InlineData("abcd", "e2fc714c4727ee9395f324cd2e7f331f")]
        [InlineData("0000", "4a7d1ed414474e4033ac29ccb8653d9b")]
        [InlineData("admin", "21232f297a57a5a743894a0e4a801fc3")]
        public void ByteArrayToHash(string origin, string hashResult) {
            var bytes = Encoding.UTF8.GetBytes(origin);
            Assert.Equal(ByteConvert.HexToBytes(hashResult), bytes.ToHash<MD5>());
        }
    }
}
