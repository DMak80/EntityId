using System;

namespace EntityIdLib.Uids
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EntityUidInfoAttribute : Attribute
    {
        public EntityUidInfoAttribute(string prefix, Type uidType)
        {
            Prefix = prefix ?? throw new ArgumentNullException(nameof(prefix));
            UidType = uidType ?? throw new ArgumentNullException(nameof(uidType));
        }

        public string Prefix { get; }
        public Type UidType { get; }
    }
}