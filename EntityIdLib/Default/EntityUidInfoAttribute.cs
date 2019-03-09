using System;

namespace EntityIdLib.Default
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EntityUidInfoAttribute : Attribute
    {
        public EntityUidInfoAttribute(string prefix, Type uid)
        {
            Prefix = prefix;
            Uid = uid;
        }

        public string Prefix { get; }
        public Type Uid { get; }
    }
}