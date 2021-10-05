using System.ComponentModel;

namespace EmpApiService.Common.Enums
{
    public enum UserRole
    {
        [Description("SuperAdmin")]
        SuperAdmin = 0,
        [Description("Admin")]
        Admin = 1,
        [Description("User")]
        User = 2
    }
}
