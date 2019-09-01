using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using XPY.ToolKit.Utilities.Test.Reflection.Models;
using Xunit;

namespace XPY.ToolKit.Utilities.Reflection.Test {
    public static class EnumUtilityTest {
        [Fact(DisplayName = "取得列舉Attributes")]
        public static void GetCustomAttributesTest() {
            Assert.Single(EnumUtility.GetCustomAttributes(SampleEnum.A, typeof(SampleEnumAttribute)));
            Assert.Equal(2, EnumUtility.GetCustomAttributes(SampleEnum.B, typeof(SampleEnumAttribute)).Count());
            Assert.Empty(EnumUtility.GetCustomAttributes(SampleEnum.C, typeof(SampleEnumAttribute)));
        }

        [Fact(DisplayName = "取得列舉Attribute")]
        public static void GetCustomAttributeTest() {
            Assert.NotNull(EnumUtility.GetCustomAttribute(SampleEnum.A, typeof(SampleEnumAttribute)));
            Assert.Throws<AmbiguousMatchException>(() => {
                Assert.NotNull(EnumUtility.GetCustomAttribute(SampleEnum.B, typeof(SampleEnumAttribute)));
            });
            Assert.Null(EnumUtility.GetCustomAttribute(SampleEnum.C, typeof(SampleEnumAttribute)));
        }

        [Fact(DisplayName = "取得列舉Attributes泛型")]
        public static void GetCustomAttributesGTest() {
            Assert.Single(EnumUtility.GetCustomAttributes<SampleEnum, SampleEnumAttribute>(SampleEnum.A));
            Assert.Equal(2, EnumUtility.GetCustomAttributes<SampleEnum, SampleEnumAttribute>(SampleEnum.B).Count());
            Assert.Empty(EnumUtility.GetCustomAttributes<SampleEnum, SampleEnumAttribute>(SampleEnum.C));
        }

        [Fact(DisplayName = "取得列舉Attribute泛型")]
        public static void GetCustomAttributeGTest() {
            Assert.NotNull(EnumUtility.GetCustomAttribute<SampleEnum, SampleEnumAttribute>(SampleEnum.A));
            Assert.Throws<AmbiguousMatchException>(() => {
                Assert.NotNull(EnumUtility.GetCustomAttribute<SampleEnum, SampleEnumAttribute>(SampleEnum.B));
            });
            Assert.Null(EnumUtility.GetCustomAttribute<SampleEnum, SampleEnumAttribute>(SampleEnum.C));
        }
    }
}
