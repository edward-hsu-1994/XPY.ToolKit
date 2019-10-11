using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XPY.ToolKit.Utilities.Reflection;

namespace XPY.ToolKit.Utilities.Reflection.Test
{
    public class MemberInfoExtensionTest
    {
        public class MemberInfoTestClass
        {
            public string Field = "Field";
            public string Property => "Property";
            public string MethodFunc()
            {
                return "Method";
            }
            public void MethodAction()
            {
            }
        }

        [Fact(DisplayName = "取得成員資訊-欄位測試")]
        public void GetMemberInfoFieldTest()
        {
            var obj = new MemberInfoTestClass();
            Assert.Equal(typeof(MemberInfoTestClass).GetField("Field"), obj.GetMemberInfo(x => x.Field));
        }

        [Fact(DisplayName = "取得成員資訊-屬性測試")]
        public void GetMemberInfoPropertyTest()
        {
            var obj = new MemberInfoTestClass();
            Assert.Equal(typeof(MemberInfoTestClass).GetProperty("Property"), obj.GetMemberInfo(x => x.Property));
        }

        [Fact(DisplayName = "取得成員資訊-方法測試")]
        public void GetMemberInfoMethodActionTest()
        {
            var obj = new MemberInfoTestClass();
            Assert.Equal(typeof(MemberInfoTestClass).GetMethod("MethodFunc"), obj.GetMemberInfo(x => x.MethodFunc()));
        }

        [Fact(DisplayName = "取得成員資訊-函數測試")]
        public void GetMemberInfoMethodTest()
        {
            var obj = new MemberInfoTestClass();
            Assert.Equal(typeof(MemberInfoTestClass).GetMethod("MethodAction"), obj.GetMemberInfo(x => x.MethodAction()));
        }

        [Fact(DisplayName = "取得成員資訊-建構子測試")]
        public void GetMemberInfoConstructorTest()
        {
            var obj = new MemberInfoTestClass();
            Assert.Equal(typeof(MemberInfoTestClass).GetConstructor(Type.EmptyTypes), obj.GetMemberInfo(x => new MemberInfoTestClass()));
        }
    }
}
