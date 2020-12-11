using System;
using System.Collections.Generic;
using System.Reflection;
using EntityIdLib.Uids;

namespace EntityIdLib.Default
{
    public class UidEnumConverter
    {
        public static List<EntityUidInfo> GetUidInfos<T, TC>()
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ApplicationException($"Type {type.Name} is not enum");
            }
            var tctype = typeof(TC);
            if (!tctype.IsEnum)
            {
                throw new ApplicationException($"Type {tctype.Name} is not enum");
            }

            var result = new List<EntityUidInfo>();
            
            Dictionary<Type, Type?> converters = new Dictionary<Type, Type?>();
            var tcobjs = Enum.GetValues(tctype);
            foreach (var obj in tcobjs)
            {
                var field = type.GetField(obj.ToString());
                var attr = field?.GetCustomAttribute<EntityUidConverterAttribute>();
                if (attr == null)
                    continue;
                converters[attr.Uid] = attr.UidConverter;
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