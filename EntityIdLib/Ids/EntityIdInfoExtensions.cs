using System;
using System.Linq;
using System.Reflection;
using EntityIdLib.Uids;

namespace EntityIdLib.Ids
{
    public static class EntityIdInfoExtensions
    {
        public static EntityIdInfo? ToIdInfo(this Type type)
        {
            if (type.GetInterfaces()
                .Where(i => i.IsGenericType)
                .All(i => i.GetGenericTypeDefinition() != typeof(IIdBase<,>)))
            {
                return null;
            }

            var attr = type.GetCustomAttribute<EntityIdInfoAttribute>();
            if (attr == null)
            {
                return null;
            }

            var uidInfo = attr.UidType.ToUidInfo();
            if (uidInfo == null)
            {
                return null;
            }

            return new EntityIdInfo(type, attr.IdTypeConverter, uidInfo);
        }
    }
}