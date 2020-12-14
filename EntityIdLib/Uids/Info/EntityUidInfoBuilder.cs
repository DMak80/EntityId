using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EntityIdLib.Converters;

namespace EntityIdLib.Uids
{
    public class EntityUidInfoBuilder
    {
        public static List<EntityUidInfo> GetUidInfos<T>(Type staticConverters)
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ApplicationException($"Type {type.Name} is not enum");
            }

            var result = new List<EntityUidInfo>();

            Dictionary<Type, Type?> converters = new Dictionary<Type, Type?>();
            var tcobjs = staticConverters.GetMethods()
                .Where(m => m.ReturnType.IsSubclassOf(typeof(UidConverter)))
                .Where(m => typeof(IUid).IsAssignableFrom(m.GetParameters().FirstOrDefault()?.ParameterType ?? typeof(object)))
                .ToArray();
            
            foreach (var obj in tcobjs)
            {
                var parameter = obj.GetParameters().FirstOrDefault().ParameterType;
                var converter = obj.ReturnType;
                converters[parameter] = converter;
            }

            var objs = Enum.GetValues(type);
            foreach (var obj in objs)
            {
                var name = obj?.ToString() ?? string.Empty;
                var field = type.GetField(name);
                var attr = field?.GetCustomAttribute<EntityUidInfoAttribute>();
                if (attr == null)
                    continue;
                converters.TryGetValue(attr.UidType, out var converter);
                result.Add(new EntityUidInfo(attr.Prefix, attr.UidType, name, converter));
            }

            return result;
        }
    }
}