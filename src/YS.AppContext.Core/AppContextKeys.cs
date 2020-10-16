using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace YS.AppContext
{
    public static class AppContextKeys
    {
        public const string User = nameof(User);
        public const string UserId = nameof(UserId);
        public const string UserName = nameof(UserName);
        public const string UserEmail = nameof(UserEmail);
        public const string RoleName = nameof(RoleName);
        public const string RoleId = nameof(RoleId);
        public const string LogicRoleIds = nameof(LogicRoleIds);
        public const string RequestIp = nameof(RequestIp);
        public const string RequestLanguage = nameof(RequestLanguage);
        public const string IsAuthenticated = nameof(IsAuthenticated);
    }
}
