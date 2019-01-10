using System;
using System.Reflection;
using EntityIdLib.Attributes;
using EntityIdLib.EntityTypeFormat;
using Xunit;

namespace EntityIdLib.Tests
{
    public class TestEntityIdAttributeGetter<T> : IEntityIdAttributeGetter
    {
        public EntityIdAttribute Get(Type type)
        {
            var attrA = type.GetCustomAttribute<T>();
            var attr = attrA?.Type.GetType().GetMember(attrA.Type.ToString())[0]
                .GetCustomAttribute<EntityIdAttribute>();
            return attr;
        }
    }
    
    [AttributeUsage(AttributeTargets.Struct)]
    public class EntityIdTypeAttribute<T> : Attribute
    {
        public EntityIdTypeAttribute(T type)
        {
            Type = type;
        }

        public T Type { get; }
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
        }
    }
}