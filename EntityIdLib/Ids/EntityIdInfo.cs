using System;
using EntityIdLib.UIds;

namespace EntityIdLib.Ids
{
    public class EntityIdInfo
    {
        public EntityIdInfo(Type idType, Type idTypeConverter, EntityUidInfo info)
        {
            IdType = idType;
            IdTypeConverter = idTypeConverter;
            Info = info;
        }

        public Type IdType { get; }
        public Type IdTypeConverter { get; }
        public EntityUidInfo Info { get; }
    }
}