using System;
using System.Collections.Concurrent;
using System.Reflection;
using EntityIdLib.Attributes;
using EntityIdLib.EntityTypeFormat;

namespace EntityIdLib.Core
{
    public static class IdBaseConverters
    {
        private static readonly ConcurrentDictionary<Type, BaseIdConverter> Converters =
            new ConcurrentDictionary<Type, BaseIdConverter>();

        public static IEntityIdAttributeGetter EntityIdAttributeGetter { get; set; }

        public static IdConverter<T> GetConverter<T, TC>(this IIdBase<T, TC> obj)
            where TC : IIdBase<T, TC>
        {
            return GetConverter<T, TC>();
        }

        public static IdConverter<T> GetConverter<T, TC>()
            where TC : IIdBase<T, TC>
        {
            return (IdConverter<T>) Converters.GetOrAdd(typeof(TC), GetConverter<T, TC>);
        }

        private static BaseIdConverter GetConverter<T, TC>(Type tc)
            where TC : IIdBase<T, TC>
        {
            var attrA = tc.GetCustomAttribute<EntityIdTypeAttribute>();
            var attr = attrA?.Type.GetType().GetMember(attrA.Type.ToString())[0]
                .GetCustomAttribute<EntityIdAttribute>();
            if (attr?.IdType == null || string.IsNullOrEmpty(attr.Prefix)) return null;

            IdPrefixChecker.CheckUniquePrefix(attr.Prefix, tc);

            if (!typeof(IdConverter<T>).IsAssignableFrom(attr.IdType))
                throw new InvalidCastException($"{attr.IdType.Name} to {typeof(IdConverter<T>).Name}");

            return (BaseIdConverter) Activator.CreateInstance(attr.IdType, attr.Prefix);
        }
    }
}