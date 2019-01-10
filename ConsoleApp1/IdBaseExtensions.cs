using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace ConsoleApp1
{
    public static class IdBaseExtensions
    {
        private static readonly ConcurrentDictionary<Type, BaseIdConverter> Converters =
            new ConcurrentDictionary<Type, BaseIdConverter>();

        private static IdConverter<T> GetConverter<T, TC>(this IIdBase<T, TC> obj)
            where TC : IIdBase<T, TC>
        {
            return GetConverter<T, TC>();
        }

        private static IdConverter<T> GetConverter<T, TC>()
            where TC : IIdBase<T, TC>
        {
            return (IdConverter<T>) Converters.GetOrAdd(typeof(TC), tc =>
            {
                var attrA = tc.GetCustomAttribute<EntityIdTypeAttribute>();
                var attr = attrA?.Type.GetType().GetMember(attrA.Type.ToString())[0]
                    .GetCustomAttribute<EntityIdAttribute>();
                if (attr?.IdType == null) return null;

                if (!typeof(IdConverter<T>).IsAssignableFrom(attr.IdType))
                    throw new InvalidCastException($"{attr.IdType.Name} to {typeof(IdConverter<T>).Name}");

                return (BaseIdConverter) Activator.CreateInstance(attr.IdType, attr.Prefix);
            });
        }

        public static UId ToUid<T, TC>(this IIdBase<T, TC> obj)
            where TC : IIdBase<T, TC>
        {
            return obj.GetConverter().ToUid(obj.Id);
        }

        public static TC ToId<T, TC>(this UId obj)
            where TC : IIdBase<T, TC>
        {
            return (TC) Activator.CreateInstance(typeof(TC), GetConverter<T, TC>().FromUid(obj));
        }
    }
}