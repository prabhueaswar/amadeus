using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace EmpApiService.Common.Helpers
{
    public static class Utils
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                foreach (int val in Enum.GetValues(type))
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        MemberInfo[] memberInfos = type.GetMember(type.GetEnumName(val));
                        if (memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() is DescriptionAttribute descriptionAttribute)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
