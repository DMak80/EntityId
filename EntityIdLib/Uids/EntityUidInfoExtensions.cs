using System;
using System.Reflection;

namespace EntityIdLib.Uids
{
    public static class EntityUidInfoExtensions
    {
        public static EntityUidInfo? ToUidInfo(this Type type)
        {
            if (!typeof(IUid).IsAssignableFrom(type))
            {
                return null;
            }

            var attr = type.GetCustomAttribute<EntityUidInfoAttribute>();
            if (attr == null)
            {
                return null;
            }
            
            return new EntityUidInfo(attr.Prefix, type, attr.Name);
        }
    }
}