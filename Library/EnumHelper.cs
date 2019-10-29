using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class EnumHelper
    {
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var typeInfo = enumVal.GetType().GetTypeInfo();
            var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
            return v.GetCustomAttribute<T>();
        }

        public static string GetCommand(this Cmdlet enumVal)
        {
            var attr = GetAttributeOfType<CmdletAttribute>(enumVal);
            return attr != null ? attr.Command : string.Empty;
        }
    }
}
