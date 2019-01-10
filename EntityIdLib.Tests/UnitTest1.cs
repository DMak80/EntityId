using System;
using System.Reflection;
using EntityIdLib.Attributes;
using Xunit;

namespace EntityIdLib.Tests
{
    public class TestEntityIdAttributeGetter : IEntityIdAttributeGetter
    {
        public EntityIdAttribute Get(Type type)
        {
            var attrA = type.GetCustomAttribute<TestEntityIdTypeAttribute>();
            var attr = attrA?.Type.GetType().GetMember(attrA.Type.ToString())[0]
                .GetCustomAttribute<EntityIdAttribute>();
            return attr;
        }
    }

    public class DirectEntityIdAttributeGetter : IEntityIdAttributeGetter
    {
        public EntityIdAttribute Get(Type type)
        {
            return type.GetCustomAttribute<EntityIdAttribute>();
        }
    }

    public enum TestEntityType
    {
    }

    [AttributeUsage(AttributeTargets.Struct)]
    public class TestEntityIdTypeAttribute : Attribute
    {
        public TestEntityIdTypeAttribute(TestEntityType type)
        {
            Type = type;
        }

        public TestEntityType Type { get; }
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
        }
    }
}