using System;

namespace EntityIdLib.Uids
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class EntityUidInfoAttribute : Attribute
    {
        public EntityUidInfoAttribute(string prefix, string name)
        {
            Prefix = prefix ?? throw new ArgumentNullException(nameof(prefix));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Prefix { get; }
        public string Name { get; }
    }
}