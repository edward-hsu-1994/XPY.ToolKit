using System.Threading.Tasks;

namespace XPY.ToolKit.AspNetCore {
    /// <summary>
    /// 基礎驗證處理
    /// </summary>
    public interface IBaseAuthorizeHandler {
        /// <summary>
        /// 驗證方法
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="password">密碼</param>
        /// <returns>驗證結果</returns>
        Task<bool> Authorize(string account, string password);
    }
}