using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XPY.ToolKit.AspNetCore.Test.WebProject {
    public class TestBasicAuthenticateHandler : IBaseAuthorizeHandler {
        public async Task<bool> Authorize(string account, string password) {
            if (account == "admin" && password == "admin") {
                return true;
            }
            return false;
        }
    }
}
