using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var userId = new UserId(1);
            var uidUserId = userId.ToUid();
            var permId = new PermId("123");
            var uidPermId = permId.ToUid();
            var userId2 = uidUserId.ToId<int, UserId>(); //new UserId(uidUserId);
            var permId2 = uidPermId.ToId<string, PermId>(); //new PermId(uidPermId);
            var permId3 = uidUserId.ToId<string, PermId>(); //new PermId(uidUserId);
        }
    }

    [AttributeUsage(AttributeTargets.Struct)]
    public class EntityIdAttribute : Attribute
    {
        public EntityIdAttribute(string prefix, Type idType)
        {
            Prefix = prefix;
            IdType = idType;
        }

        public string Prefix { get; }
        public Type IdType { get; }
    }

//    public enum EntityType
//    {
//        [EntityProperties("U", typeof(IntIdConverter))]
//        User,
//
//        [EntityProperties("P", typeof(StringIdConverter))]
//        Permission
//    }

//    public static class EntityTypeExtensions
//    {
//        private static readonly Lazy<IReadOnlyDictionary<EntityType, BaseIdConverter>> _lazyDic =
//            new Lazy<IReadOnlyDictionary<EntityType, BaseIdConverter>>(() =>
//            {
//                return typeof(EntityType)
//                    .GetFields()
//                    .Where(f => f.GetCustomAttribute<EntityPropertiesAttribute>() != null)
//                    .Where(f => typeof(BaseIdConverter).IsAssignableFrom(f
//                        .GetCustomAttribute<EntityPropertiesAttribute>().IdType))
//                    .ToDictionary(f => (EntityType) f.GetValue(null), f =>
//                    {
//                        var attr = f.GetCustomAttribute<EntityPropertiesAttribute>();
//                        return (BaseIdConverter) Activator.CreateInstance(attr.IdType, attr.Prefix);
//                    });
//            });
//
//        public static IdConverter<T> GetConverter<T>(this EntityType type)
//        {
//            if (_lazyDic.Value.TryGetValue(type, out var converter)) return (IdConverter<T>) converter;
//
//            return null;
//        }
//    }

    public interface IIdBase<out T, TC>
        where TC : IIdBase<T, TC>
    {
        T Id { get; }
        UId ToUid();
    }

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
                var attr = tc.GetCustomAttribute<EntityIdAttribute>();
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


    [EntityId("U", typeof(IntIdConverter))]
    public struct UserId : IIdBase<int, UserId>
    {
        public UserId(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public UId ToUid()
        {
            return IdBaseExtensions.ToUid(this);
        }
    }

    [EntityId("P", typeof(StringIdConverter))]
    public struct PermId : IIdBase<string, PermId>
    {
        public PermId(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public UId ToUid()
        {
            return IdBaseExtensions.ToUid(this);
        }
    }

//    [EntityProperties("U", typeof(IntIdConverter))]
//    public class UserId : IdBase<int>
//    {
//        public class UserIdConverter : IntIdConverter
//        {
//            protected UserIdConverter() : base("U")
//            {
//            }
//        }
//
//        public UserId(int id) : base(id)
//        {
//        }
//
//        public UserId(UId uid) : base(uid)
//        {
//        }
//    }

//    public class PermId : IdBase<string, PermIdConverter>
//    {
//        public class UserIdConverter : IntIdConverter
//        {
//            protected UserIdConverter() : base("U")
//            {
//            }
//        }
//
//        public PermId(string key) : base(key)
//        {
//        }
//
//        public PermId(UId uid) : base(uid)
//        {
//        }
//    }
}