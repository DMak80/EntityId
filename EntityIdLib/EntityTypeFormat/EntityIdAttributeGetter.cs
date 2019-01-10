using System;
using System.Reflection;
using EntityIdLib.Attributes;

namespace EntityIdLib.EntityTypeFormat
{
    public class EntityIdAttributeGetter : IEntityIdAttributeGetter
    {
        public EntityIdAttribute Get(Type type)
        {
            var attrA = type.GetCustomAttribute<EntityIdTypeAttribute>();
            var attr = attrA?.Type.GetType().GetMember(attrA.Type.ToString())[0]
                .GetCustomAttribute<EntityIdAttribute>();
            return attr;
        }
    }
}