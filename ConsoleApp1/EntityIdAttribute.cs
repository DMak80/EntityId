using System;

namespace ConsoleApp1
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EntityIdAttribute : Attribute
    {
        public EntityIdAttribute(string prefix, Type idType)
        {
            Prefix = prefix;
            IdType = idType;
        }

        public string Prefix { get; }
        public Type IdType { get; }
    }

    [AttributeUsage(AttributeTargets.Struct)]
    public class EntityIdTypeAttribute : Attribute
    {
        public EntityIdTypeAttribute(EntityType type)
        {
            Type = type;
        }

        public EntityType Type { get; }
    }
}