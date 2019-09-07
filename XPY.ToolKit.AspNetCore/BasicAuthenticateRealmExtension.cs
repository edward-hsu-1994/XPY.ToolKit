using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.AspNetCore {
    /// <summary>
    /// 基礎驗證擴充方法
    /// </summary>
    public static class BasicAuthenticateRealmExtension {
        /// <summary>
        /// 使用範圍HTTP基本驗證
        /// </summary>
        /// <typeparam name="TBaseAuthorizeHandler">驗證類別</typeparam>
        /// <param name="app">應用程式建構器</param>
        /// <param name="path">路徑</param>
        /// <param name="options">選項</param>
        /// <returns>應用程式建構器</returns>
        public static IApplicationBuilder UseBasicAuthenticateRealm<TBaseAuthorizeHandler>(
            this IApplicationBuilder app,
            BasicAuthenticateRealmOption options)
            where TBaseAuthorizeHandler : IBaseAuthorizeHandler {
            return app.UseMiddleware<BasicAuthenticateRealmMiddleware<TBaseAuthorizeHandler>>(
                options
            );
        }
    }
}
