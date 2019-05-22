using System;
using System.Net.Http.Headers;
using EntityIdLib.Uids;

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