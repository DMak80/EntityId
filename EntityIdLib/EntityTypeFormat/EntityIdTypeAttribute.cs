using System;

namespace EntityIdLib.EntityTypeFormat
{
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