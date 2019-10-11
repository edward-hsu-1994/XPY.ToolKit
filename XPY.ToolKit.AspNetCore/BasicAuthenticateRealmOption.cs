using Microsoft.AspNetCore.Http;

namespace XPY.ToolKit.AspNetCore
{
    /// <summary>
    /// 基礎驗證範圍選項
    /// </summary>
    public class BasicAuthenticateRealmOption
    {
        /// <summary>
        /// 作用路由
        /// </summary>
        public PathString Path { get; set; }

        /// <summary>
        /// 範圍
        /// </summary>
        public string Realm { get; set; }
    }
}