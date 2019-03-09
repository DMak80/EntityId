using System;
using System.Collections.Generic;
using System.Reflection;
using EntityIdLib.Ids;
using EntityIdLib.Uids;

namespace EntityIdLib.Default
{
    public class UidEnumConverter
    {
        public static List<EntityUidInfo> GetUidInfos<T>()
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ApplicationException($"Type {type.Name} is not enum");
            }

            var result = new List<EntityUidInfo>();
            
            var objs = Enum.GetValues(type);
            foreach (var obj in objs)
            {
                var field = type.GetField(obj.ToString());
                var attr = field.GetCustomAttribute<EntityUidInfoAttribute>();
                if (attr == null)
                    continue;
                result.Add(new EntityUidInfo(attr.Prefix, attr.Uid, obj.ToString()));
            }

            return result;
        }
        
        public static List<EntityIdInfo> GetIdInfos<T>()
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ApplicationException($"Type {type.Name} is not enum");
            }

            var result = new List<EntityIdInfo>();
            
            var objs = Enum.GetValues(type);
            foreach (var obj in objs)
            {
                var field = type.GetField(obj.ToString());
                var attr = field.GetCustomAttribute<EntityIdInfoAttribute>();
                if (attr == null)
                    continue;
                result.Add(new EntityIdInfo(attr.IdType, attr.IdTypeConverter, UidCore.Instance.Get(attr.UIdType)));
            }

            return result;
        }
    }
}