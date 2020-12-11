using System;

namespace EntityIdLib.Default
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EntityUidConverterAttribute : Attribute
    {
        public EntityUidConverterAttribute(Type uid, Type uidConverter)
        {
            Uid = uid;
            UidConverter = uidConverter;
        }

        public Type UidConverter { get; }
        public Type Uid { get; }
    }
}