using System;
using System.Collections.Generic;
using System.Linq;
using EntityIdLib.Ids;

namespace EntityIdLib.Default
{
    public class DefaultEntityIdDescGetter<T> : IEntityIdDescGetter
    {
        private readonly Dictionary<Type, EntityIdInfo> _dic;

        public DefaultEntityIdDescGetter()
        {
            _dic = UIdEnumConverter.GetIdInfos<T>()
                .ToDictionary(i => i.IdType);
        }

        public EntityIdInfo Get(Type type)
        {
            if (_dic.TryGetValue(type, out var i))
            {
                return i;
            }

            return null;
        }
    }
}