using System;

namespace EntityIdLib.Ids
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class EntityIdInfoAttribute : Attribute
    {
        public EntityIdInfoAttribute(Type idTypeConverter, Type uidType)
        {
            IdTypeConverter = idTypeConverter ?? throw new ArgumentNullException(nameof(idTypeConverter));
            UidType = uidType ?? throw new ArgumentNullException(nameof(uidType));
        }

        public Type IdTypeConverter { get; }
        public Type UidType { get; }
    }
}