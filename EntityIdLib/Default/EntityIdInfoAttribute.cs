using System;
using System.Linq;
using EntityIdLib.Converters;
using EntityIdLib.Converters.Impl;
using EntityIdLib.Ids;

namespace EntityIdLib.Default
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EntityIdInfoAttribute : Attribute
    {
        public EntityIdInfoAttribute(Type uidType, Type idType, Type idTypeConverter)
        {
            IdType = idType;
            IdTypeConverter = idTypeConverter;
            UIdType = uidType;

            var iface = idType.GetInterface(typeof(IIdBase<,>).Name)
                ?? throw new ArgumentException($"Type {idType.Name} is not declare interface IIdBase");
            var basetype = iface.GetGenericArguments().FirstOrDefault()
                           ?? throw new ArgumentException($"Type {idType.Name} is not generic interface IIdBase");
            if (!typeof(IdConverter<>).MakeGenericType(basetype).IsAssignableFrom(idTypeConverter))
                    throw new ArgumentException($"{idTypeConverter.Name} cannot be cast to IdConverter<{idType.Name}>");
        }

        public Type IdType { get; }
        public Type IdTypeConverter { get; }
        public Type UIdType { get; }
    }
}