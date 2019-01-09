using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var userId = new UserId(1);
            var uidUserId = userId.UID;
            var permId = new PermId("123");
            var uidPermId = permId.UID;
            var userId2 = new UserId(uidUserId);
            var permId2 = new PermId(uidPermId);
            var permId3 = new PermId(uidUserId);
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class EntityPropertiesAttribute : Attribute
    {
        public EntityPropertiesAttribute(string prefix, Type idType)
        {
            Prefix = prefix;
            IdType = idType;
        }

        public string Prefix { get; }
        public Type IdType { get; }
    }

    public enum EntityType
    {
        [EntityProperties("U", typeof(IntIdConverter))]
        User,

        [EntityProperties("P", typeof(StringIdConverter))]
        Permission
    }

    public static class EntityTypeExtensions
    {
        private static readonly Lazy<IReadOnlyDictionary<EntityType, BaseIdConverter>> _lazyDic =
            new Lazy<IReadOnlyDictionary<EntityType, BaseIdConverter>>(() =>
            {
                return typeof(EntityType)
                    .GetFields()
                    .Where(f => f.GetCustomAttribute<EntityPropertiesAttribute>() != null)
                    .Where(f => typeof(BaseIdConverter).IsAssignableFrom(f
                        .GetCustomAttribute<EntityPropertiesAttribute>().IdType))
                    .ToDictionary(f => (EntityType) f.GetValue(null), f =>
                    {
                        var attr = f.GetCustomAttribute<EntityPropertiesAttribute>();
                        return (BaseIdConverter) Activator.CreateInstance(attr.IdType, attr.Prefix);
                    });
            });

        public static IdConverter<T> GetConverter<T>(this EntityType type)
        {
            if (_lazyDic.Value.TryGetValue(type, out var converter)) return (IdConverter<T>) converter;

            return null;
        }
    }

    public class IdBase<T, TConv>
        where TConv : IdConverter<T>
    {
        private static readonly Lazy<TConv> conv = new Lazy<TConv>(Activator.CreateInstance<TConv>);
        private UId? uid;

        protected IdBase(T key)
        {
            Key = key;
        }

        protected IdBase(UId uid) : this(Conv.FromUid(uid))
        {
            this.uid = uid;
        }

        protected static TConv Conv => conv.Value;

        public UId UID => uid ?? (uid = conv.Value.ToUid(Key)).Value;
        public T Key { get; }
    }

    public class UserId : IdBase<int, EntityType.User.GetConverter<int>()>
    {
        public UserId(int key) : base(key)
        {
        }

        public UserId(UId uid) : base(uid)
        {
        }
    }

    public class PermId : IdBase<string, PermIdConverter>
    {
        public PermId(string key) : base(key)
        {
        }

        public PermId(UId uid) : base(uid)
        {
        }
    }
}